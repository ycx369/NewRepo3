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
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Visio;
using System.IO;


namespace DesignStandard
{
    public partial class FlowChart : Form
    {
        public FlowChart()
        {
            InitializeComponent();
        }
        float X;
        float Y;
       
        private void button1_Click(object sender, EventArgs e)
        {
            axDrawingControl1.Document.SaveAs(@"C:\work\Programme\Standard System all\Standard system files\115.vsd");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            axDrawingControl1.Document.SaveAs(@"C:\work\Programme\Standard System all\Standard system files\115.vsd");
        }

        private void FlowChart_Load(object sender, EventArgs e)
        {
            if (label1.Text == "115")
            {
                axDrawingControl1.Src = @"C:\work\Programme\Standard System all\Standard system files\115.vsd";
                axDrawingControl1.Window.ShowGrid = 0;
                axDrawingControl1.Window.Zoom = 1;
                
            }
            else if(label1.Text=="70-2")
            {
                axDrawingControl1.Src = @"C:\work\Programme\Standard System all\Standard system files\70-2.vsd";
                axDrawingControl1.Window.ShowGrid = 0;
                axDrawingControl1.Window.Zoom = 1;
            }
            //axDrawingControl1.Src = @"C:\work\Programme\Standard System all\Standard system files\115.vsd";
            //axDrawingControl1.Window.ShowGrid = 0;
            ////axDrawingControl1.Window.ShowRulers = 0;
            ////axDrawingControl1.Window.ShowGuides = 0;
            ////axDrawingControl1.Window.ShowPageTabs = false;
            //axDrawingControl1.Window.Zoom = 1;
            this.Resize += new EventHandler(FlowChart_Resize);//窗体调整大小时引发事件
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            setTag(this);//调用方法
            this.Text= label1.Text + "Flow Chart";
            
            label2.Left = label1.Right;
            label2.Text = "Flow Chart";

            
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
                //con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }
        void FlowChart_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = this.Height / Y;//窗体高度缩放比例
            setControls(newx, newy, this);//随窗体改变控件大小
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();//窗体标题栏文本
        }

    }
}

