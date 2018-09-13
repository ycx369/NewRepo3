using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignStandard
{
    public partial class KeyProcess : Form
    {
        public KeyProcess()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofDialog = new OpenFileDialog();
            //ofDialog.AddExtension = true;
            //ofDialog.CheckFileExists = true;
            //ofDialog.CheckPathExists = true;
            ////the nextsentence must be in single line
            //ofDialog.Filter = "VCD文件(*.dat)|*.dat|Audio文件(*.avi)|*.avi|WAV文件(*.wav)|*.wav|MP3文件(*.mp3)|*.mp3|所有文件 (*.*)|*.*";
            ////ofDialog.DefaultExt = "*.mp3";
            //if (ofDialog.ShowDialog() == DialogResult.OK)
            ClassLibrary3.sqlhelper sqlhelper = new ClassLibrary3.sqlhelper();
            {
                // 2003一下版本 方法this.axMediaPlayer1.FileName = ofDialog.FileName;
                //string path1 = sqlhelper.ExecuteScalar("select Path from T_OKKEN where product_type='" + id + "'").ToString();
                this.axWindowsMediaPlayer1.URL = @"C:\Study\FeiFan\other video\进程和线程.avi";//2005用法
                                                                                          //this.axWindowsMediaPlayer1.URL = ofDialog.FileName;//2005用法
            }
        }
    }
}
