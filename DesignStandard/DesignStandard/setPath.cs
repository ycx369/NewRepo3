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
    public partial class setPath : Form
    {
        public setPath()

        {
            InitializeComponent();

            //comboBox1.DisplayMember = "123";
        }
        private void setPath_Load(object sender, EventArgs e)
        {
            ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();
            comboBox1.DataSource = helper.SelectMysqlreturnDataset("select DISTINCT Product from T_OKKEN").Tables[0];
            comboBox1.ValueMember = "product";
        }
        ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();
        // 更新路径，保存确认
        private void button1_Click(object sender, EventArgs e)
        {

            string pathText = textBox1.Text;

            //if (textBox1.Text.Contains('/'))
            //textBox2.Text = textBox1.Text;
            if (MessageBox.Show("是否确定更新为当前路径", "更新确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int count = helper.ExcuteSqlreturnInt("UPDATE T_OKKEN set path='" + textBox1.Text + "' where Product ='" + comboBox1.Text + "'");
                MessageBox.Show(count.ToString());
                if (count != 0)
                {
                    MessageBox.Show("Save成功！");
                }
                else
                {
                    MessageBox.Show("Save失败！");
                }
            }
            else
            {

            }
            //okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button1.Text + "'").Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + comboBox1.Text + "'").Tables[0];
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        }
        //创建文件夹
        private void button2_Click(object sender, EventArgs e)
        {
            string id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string path1 = helper.ExecuteScalar("select Path from T_OKKEN where product_type='" + id + "'").ToString();
            string creatPath = path1 + @"\" + id;
            //MessageBox.Show(creatPath);
            //Directory.CreateDirectory(creatPath);
            bool exist = Directory.Exists(creatPath);
            if (exist == false && textBox2.Text!="")
            {
                Directory.CreateDirectory(creatPath);
                MessageBox.Show("创建成功！");
            }
            else
            {
                MessageBox.Show("文件夹已存在或路径未设置！");
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //textBox2.Text = helper.ExecuteScalar("select path from T_OKKEN where Product='" + comboBox1.Text + "'").ToString();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int countPath = Convert.ToInt32(helper.ExecuteScalar("select count(path) from T_OKKEN where Product='" + comboBox1.Text + "'"));

            if (countPath != 0)
            {
                textBox2.Text = helper.ExecuteScalar("select path from T_OKKEN where Product='" + comboBox1.Text + "'").ToString();

            }

            else
            {
                textBox2.Text = "";
            }
            //textBox2.Text = comboBox1.Text;

            //int 
            //object tt = helper.ExecuteScalar("select path from T_OKKEN where Product='" + comboBox1.Text + "'").ToString();
            ////object cc=
            //if (tt == null)
            //    textBox2.Text = "The path have not set yet.";
            //else
            //{
            //    textBox2.Text = helper.ExecuteScalar("select path from T_OKKEN where Product='" + comboBox1.Text + "'").ToString();
            //}
            //MessageBox.Show(tt.ToString());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.AddExtension = true;
            ofDialog.CheckFileExists = true;
            ofDialog.CheckPathExists = true;
            //the nextsentence must be in single line
            ofDialog.Filter = "VCD文件(*.dat)|*.dat|Audio文件(*.avi)|*.avi|WAV文件(*.wav)|*.wav|MP3文件(*.mp3)|*.mp3|所有文件 (*.*)|*.*";
            ofDialog.DefaultExt = "*.mp3";
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                // 2003一下版本 方法this.axMediaPlayer1.FileName = ofDialog.FileName;
                this.axWindowsMediaPlayer1.URL = @"C:\Study\FeiFan\other video\进程和线程.avi";//2005用法
                //this.axWindowsMediaPlayer1.URL = ofDialog.FileName;//2005用法

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = @"C:\Study\FeiFan\other video\进程和线程.avi";


          
            }
        }
    }


