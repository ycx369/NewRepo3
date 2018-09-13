using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignStandard
{
    public partial class designfiles : Form
    {
        public designfiles()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //DirectoryInfo TheFolder = new DirectoryInfo(@"c:\\123");
            DirectoryInfo dir = new DirectoryInfo(@"c:\\123");
            FileInfo[] fil = dir.GetFiles();
            //DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                //int size = Convert.ToInt32(f.Length);  
                long size = f.Length;
                listBox1.Items.Add(f.Name);//添加文件路径到列表中  
            }

        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string a = this.listBox1.SelectedItem.ToString();
            //open file
            System.Diagnostics.Process.Start(@"c:\123\" + a + "");
            //FileStream fs = new FileStream(@"c:\\123\\1.txt", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs);
            //sr.ReadLine();
            //sr.Close();
            //fs.Close();
            //MessageBox.Show("c:\\123\\" + a + "");
        }

        private void designfiles_Load(object sender, EventArgs e)
        {
            listBox1.Text = "";
            //DirectoryInfo dir = new DirectoryInfo(@"c:\\123");
            //FileInfo[] fil = dir.GetFiles();
            //foreach (FileInfo f in fil)
            //{

            //    long size = f.Length;
            //    listBox1.Items.Add(f.Name);//添加文件路径到列表中  
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\\123");
            FileInfo[] fil = dir.GetFiles();
            foreach (FileInfo f in fil)
            {

                long size = f.Length;
                listBox1.Items.Add(f.Name);//添加文件路径到列表中  

            }

            //    private void button1_Click_1(object sender, EventArgs e)
            //    {
            //        DirectoryInfo dir = new DirectoryInfo(@"c:\\123");
            //        FileInfo[] fil = dir.GetFiles();
            //        foreach (FileInfo f in fil)
            //        {

            //            long size = f.Length;
            //            listBox1.Items.Add(f.Name);//添加文件路径到列表中  
            //        }
            //}
        }



        private void tabControl1_Click(object sender, EventArgs e)
        {
            //switch (this.tabControl1.SelectedIndex)
            //{
            //    case 0:
            //        listBox1.Items.Clear();
            //        DirectoryInfo dir = new DirectoryInfo(@"c:\\123");
            //        FileInfo[] fil = dir.GetFiles();
            //        foreach (FileInfo f in fil)
            //        {

            //            long size = f.Length;
            //            listBox1.Items.Add(f.Name);//添加文件路径到列表中  
            //        }
            //            break;
            //    case 1:
            //        listBox1.Items.Clear();
            //        DirectoryInfo dir1 = new DirectoryInfo(@"c:\\1234");
            //        FileInfo[] fil1 = dir1.GetFiles();
            //        foreach (FileInfo f in fil1)
            //        {

            //            long size = f.Length;
            //            listBox1.Items.Add(f.Name);//添加文件路径到列表中  
            //        }
            //        break;
            //        break;
            //    case 2:

            //        break;
            //    case 3:

            //        break;
            //    case 4:

            //        break;


            }

        }


    }


    

