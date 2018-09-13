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

namespace DesignStandard
{
    public partial class Routing : Form
    {
        public Routing()
        {
            InitializeComponent();
        }
        ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();
        private void Routing_Load(object sender, EventArgs e)
        {
            //string abctxt = "OK" + label1.Text + "";
            //MessageBox.Show(abctxt);
            //dataGridView1.DataSource = helper.SelectMysqlreturnDataset("SELECT * FROM routing where cubicle="+abctxt+"").Tables[0];
            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("SELECT * FROM routing where cubicle='OK" + label1.Text + "'").Tables[0];

    
        }

        private void button4_Click(object sender, EventArgs e)
        {
  
            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("SELECT * FROM routing where cubicle='OK"+ label1.Text +"'").Tables[0];

        }
    }
}
