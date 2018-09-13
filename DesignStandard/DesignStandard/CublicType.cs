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
    public partial class CublicType : Form
    {
        public CublicType()
        {
            InitializeComponent();
        }
        ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();

        private void button1_Click(object sender, EventArgs e)
        {
            designfiles design = new designfiles();
            design.ShowDialog();
            DirectoryInfo TheFolder = new DirectoryInfo(@"c:\\123");
            //foreach (FileInfo NextFile in TheFolder.GetFiles());
            //{



            //}
        }

        private void 路径设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setPath setpath = new setPath();
            setpath.ShowDialog();
        }
    }
}
