using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DesignStandard
{
    public partial class OkkenBOM : Form
    {
        public OkkenBOM()
        {
            InitializeComponent();

        }

        ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();
        int num = 1;
       
        //ClassLibrary3.DBHelper dbhelper = new ClassLibrary3.DBHelper();


        private void OkkenBOM_Load(object sender, EventArgs e)
        {


            //dataGridView1.DataSource = helper.SelectMysqlreturnDataset("SELECT * FROM [" + label1.Text + "]").Tables[0];
            dataGridView1.DataSource = ClassLibrary3.DBHelper.GetDatasByAdapter("SELECT * FROM [" + label1.Text + "]").Tables[0];
            string pathR = helper.ExecuteScalar("SELECT Path from T_OKKEN where Product_Type= '" + label1.Text + "' ").ToString();
  

        }
#region 2D图纸列表展示

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (num==1)
            {
                string pathR = helper.ExecuteScalar("SELECT Path from T_OKKEN where Product_Type= '" + label1.Text + "' ").ToString();
               
                this.dataGridView1.Width = 450;
                this.listBox1.Visible = true;
                DirectoryInfo dir = new DirectoryInfo(@pathR);
                string name = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                listBox1.Items.Clear();
                FileInfo[] fil = dir.GetFiles();
                foreach (FileInfo f in fil)
                {
                    if (f.Name.Contains(name))
                    {
                        listBox1.Items.Add(f.Name);//添加文件路径到列表中 
                        num = 2;
                    }

                }
                int a = listBox1.Items.Count;
                if (a == 0)
                {
                    listBox1.Items.Add("No Files!");
                    num = 2;
                }
            }
           else if (num==2)
            {
                
                listBox1.Visible = false;
                dataGridView1.Width =650;
                dataGridView1.ScrollBars = ScrollBars.Both;
                num = 1;
            }
        }
        #endregion

#region 列表双击打开文件
        private void listBox1_DoubleClick(object sender, EventArgs e)   
        {
            string pathR = helper.ExecuteScalar("SELECT Path from T_OKKEN where Product_Type= '" + label1.Text + "' ").ToString();
            if (listBox1.Text.ToString() != "")
            {
                string a = this.listBox1.SelectedItem.ToString();
                //System.Diagnostics.Process.Start(@"c:\123\" + a + "");
                string pathT = pathR;
                string test = string.Join(@"\", pathR, a);
                System.Diagnostics.Process.Start(@test);
            }
        }

#endregion
        private void 设置路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setPath setP = new setPath();
            setP.ShowDialog();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  //列表筛查
        {
            if (e.KeyChar == 13)
            {

                int row = dataGridView1.Rows.Count;//得到总行数 
                int cell = dataGridView1.Rows[1].Cells.Count;//得到总列数
                int abc = 0;
                for (int i = 0; i < row; i++)
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == textBox1.Text)
                        {
                            //对比TexBox中的值是否与dataGridView中的值相同（上面这句） 
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[1];//定位到相同的单元格 
                            dataGridView1.Rows[i].Selected = true;//定位到行 
                            abc = 1;
                            break;                                     //Tools.SetGetRow = i + 1; return;//返回
                        }

                    }
                if (abc == 0)
                {
                    MessageBox.Show("该物料不存在");
                }
            }
        }

 
    }


}


