using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DesignStandard
{
    public partial class process1 : Form
    {
        public process1()
        {
            InitializeComponent();
        }
        int ab = 1;
        ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();
        AxWMPLib.AxWindowsMediaPlayer wmp = new AxWMPLib.AxWindowsMediaPlayer();
        float X;
        float Y;
        private void button2_Click(object sender, EventArgs e)
        {
            // if (ab==1)
            // {
            //     //KeyProcess keyprocess = new KeyProcess();
            //     //keyprocess.ShowDialog();
            //     this.Width = 800;
            //     wmp.Visible = true;
            //     wmp.Left = dataGridView1.Right;
            //     wmp.Size = new Size(400, 360);
            //     wmp.Location = new Point(1, 5);
            //     panel1.Controls.Add(wmp);
            //     ab = 2;
            // }
            //else if (ab == 2)
            // {
            //     //KeyProcess keyprocess = new KeyProcess();
            //     //keyprocess.ShowDialog();
            //     this.Width = 400;
            //     wmp.Dispose();
            //     ab = 1;
            // }
            // tiaozheng();
            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("SELECT Process,Product,Type FROM keyprocess").Tables[0];


        }
        private void process1_Load(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(Form1_Resize);//窗体调整大小时引发事件
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            setTag(this);//调用方法
            label2.Left = label1.Right;
            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select process,product,type from Keyprocess").ToString();
            string path1 = helper.ExecuteScalar("select PathProcess from T_OKKEN where product_type='" + label2.Text + "'").ToString();
            MessageBox.Show(path1);
            DirectoryInfo dir = new DirectoryInfo(@"c:\\123");
            FileInfo[] fil = dir.GetFiles();

            process1 pro = new process1();



            foreach (FileInfo f in fil)
            {
                long size = f.Length;
                //listBox1.Items.Add(f.Name);//添加文件路径到列表中  
            }



        }

        private void tiaozheng()
        {
            this.Resize += new EventHandler(Form1_Resize);//窗体调整大小时引发事件
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            setTag(this);//调用方法
        }
        private void setTag(Control cons)
        {
            //遍历窗体中的控件
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void 流程图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FlowChart flow = new FlowChart();
            flow.label1.Text = toolStripMenuItem2.Text;
            flow.ShowDialog();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FlowChart flow = new FlowChart();
            flow.label1.Text = toolStripMenuItem3.Text;
            flow.ShowDialog();
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
                float a = Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                con.Width = (int)a;//宽度
                a = Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;//左边距离
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }
        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            //MessageBox.Show(newx.ToString());
            float newy = this.Height / Y;//窗体高度缩放比例
            setControls(newx, newy, this);//随窗体改变控件大小
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();//窗体标题栏文本
        }

        private void 视频路径设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.AddExtension = true;
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;
            ofDialog.Filter = "VCD文件(*.dat)|*.dat|Audio文件(*.avi)|*.avi|WAV文件(*.wav)|*.wav|MP3文件(*.mp3)|*.mp3|所有文件 (*.*)|*.*";
            ofDialog.DefaultExt = "*.mp3";
            //if(this.dataGridView1.CurrentRow.Cells[0].Value.ToString() !="" )
            //{

            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofDialog = new OpenFileDialog();
            //ofDialog.AddExtension = true;
            //ofDialog.CheckFileExists = true;
            //ofDialog.CheckPathExists = true;
            //ofDialog.Filter = "VCD文件(*.dat)|*.dat|Audio文件(*.avi)|*.avi|WAV文件(*.wav)|*.wav|MP3文件(*.mp3)|*.mp3|所有文件 (*.*)|*.*";
            //ofDialog.DefaultExt = "*.mp3";

            if (this.dataGridView1.CurrentRow.Cells[0].Value.ToString() != "")
            {
                
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = true; fileDialog.Title = "请选择文件";
                fileDialog.Filter = "所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = fileDialog.FileName;
                    MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = fileDialog.FileName;
                  
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string abc = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int kk = helper.ExcuteSqlreturnInt("update keyprocess set Parth=‘" + textBox1.Text + "’where process='" + abc + "' ");
            if (kk != 0 && kk != null)
            {
                MessageBox.Show("kk");
            }
        }
    }
}
