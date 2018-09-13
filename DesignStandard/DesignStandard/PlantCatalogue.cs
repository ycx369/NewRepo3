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
    public partial class PlantCatalogue : Form
    {
        public PlantCatalogue()
        {
            InitializeComponent();
        }
        ClassLibrary3.sqlhelper helper = new ClassLibrary3.sqlhelper();

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    CublicType okken = new CublicType();
        //    okken.label1.Text = button1.Text + " Cubicle";
        //    okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button1.Text + "'").Tables[0];
        //    okken.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    //okken.dataGridView1.Font = new Font("微软雅黑", 9);
        //    okken.ShowDialog();

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //CublicType okken = new CublicType();
        //    ////okken.ShowDialog();
        //    ////MessageBox.Show (this.button1.Text);
        //    //okken.label1.Text = button2.Text + " Cubicle";
        //    //okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type,Description from T_OKKEN where Product='" + button2.Text + "'").Tables[0];
        //    //okken.ShowDialog();

        //    CublicType okken = new CublicType();
        //    okken.label1.Text = button2.Text + " Cubicle";
        //    okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button2.Text + "'").Tables[0];
        //    okken.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    okken.ShowDialog();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    CublicType okken = new CublicType();
        //    okken.label1.Text = button3.Text + " Cubicle";
        //    okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button3.Text + "'").Tables[0];
        //    okken.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    okken.ShowDialog();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    CublicType okken = new CublicType();
        //    okken.label1.Text = button4.Text + " Cubicle";
        //    okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button4.Text + "'").Tables[0];
        //    okken.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    okken.ShowDialog();
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    CublicType okken = new CublicType();
        //    okken.label1.Text = button5.Text + " Cubicle";
        //    okken.dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button5.Text + "'").Tables[0];
        //    okken.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    okken.ShowDialog();
        //}

        //private void OKKEN_Click(object sender, EventArgs e)
        //{
        //    label1.Text = tabPage1.Text + " Cubicle";
        //    dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + button1.Text + "'").Tables[0];
        //    dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    designfiles desg = new designfiles();
        //    string abc = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    desg.label1.Text = abc +" " +button6.Text + " Files";
        //    desg.ShowDialog();
        //}

        private void PlantCatalogue_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource= helper.SelectMysqlreturnDataset("select name from product ").Tables[0];
            comboBox1.ValueMember = "name";
            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + comboBox1.Text + "'").Tables[0];
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //foreach (DataRow row in dt.Rows)
            {

                SqlDataAdapter adp = new SqlDataAdapter("select name from product", helper.Sqlconnstring);

                //comboBox1.DataSource = helper.SelectMysqlreturnDataset("select name from product ").Tables[0];
                //dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select name from product ").Tables[0];
                //dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
              
                //listBox2.Items.Add(row[0].ToString());
            }
            //label1.Text = tabPage1.Text + " Cubicle";
        }

        //private void comboBox1_Click(object sender, EventArgs e)
        //{
            
        //    dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + comboBox1.Text + "'").Tables[0];
        //    dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        //    dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //MessageBox.Show("x");
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + comboBox1.Text + "'").Tables[0];
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //designfiles des1 = new designfiles();
            OkkenBOM okbom1 = new OkkenBOM();
            string abc = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //des1.label1.Text = abc + " Files";
            okbom1.label1.Text=abc;
            okbom1.ShowDialog();
            
            //des1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //routing1 rou1 = new routing1();
            Routing rou1 = new Routing();
            string abc = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            rou1.label1.Text = abc;
            rou1.ShowDialog();
            //rou1.label1.Text = abc + " Files";
            //rou1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            process1 pro = new process1();
            string abc= this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pro.label1.Text = comboBox1.Text;
            pro.label2.Text = abc + " WI Introduction";
            pro.ShowDialog();
        }

        //private void tabPage2_Click(object sender, EventArgs e)
        //{

        //    label2.Text = tabPage2.Text + " Cubicle";
        //    dataGridView2.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage2.Text + "'").Tables[0];
        //    dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //}

        //private void tabPage1_Click(object sender, EventArgs e)
        //{
        //    label1.Text = tabPage1.Text + " Cubicle";
        //    dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage1.Text + "'").Tables[0];
        //    dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //}

        //private void OKKEN_Click(object sender, EventArgs e)
        //{

        //}

        //private void OKKEN_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (this.OKKEN.SelectedIndex)
        //    {
        //        case 0:
        //            label1.Text = tabPage1.Text + " Cubicle";
        //            dataGridView1.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage1.Text + "'").Tables[0];
        //            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //            break;
        //        case 1:
        //            label2.Text = tabPage2.Text + " Cubicle";
        //            dataGridView2.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage2.Text + "'").Tables[0];
        //            dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //            break;
        //        case 2:
        //            label3.Text = tabPage3.Text + " Cubicle";
        //            dataGridView3.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage3.Text + "'").Tables[0];
        //            dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //            break;
        //        //case 3:
        //        //    label4.Text = tabPage4.Text + " Cubicle";
        //        //    dataGridView4.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage4.Text + "'").Tables[0];
        //        //    dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //        //    break;
        //        //case 4:
        //        //    label5.Text = tabPage5.Text + " Cubicle";
        //        //    dataGridView5.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage5.Text + "'").Tables[0];
        //        //    dataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //            break;


        //    }

        //}

        ////private void button10_Click(object sender, EventArgs e)
        ////{
        ////    setPath setpath1 = new setPath();
        ////    setpath1.ShowDialog();
        ////}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //   ClassLibrary3.Excell exc = new ClassLibrary3.Excell();
        //    exc.ToExcel(dataGridView1);
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    routing1 rou1= new routing1();
        //    string abc = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    rou1.label1.Text = abc + button7.Text + " Files";
        //    rou1.ShowDialog();
        //}

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    process1 pro1 = new process1();
        //    string abc = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //    pro1.label1.Text = abc + button8.Text + " Files";
        //    pro1.ShowDialog();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //    Excel1.ExcelUnit Exc1 = new Excel1.ExcelUnit();
        //    //    //Excel1.ExportToExcel(dataGridView1);
        //}



        //private void tabPage3_Click(object sender, EventArgs e)
        //{
        //    label3.Text = tabPage3.Text + " Cubicle";
        //    dataGridView3.DataSource = helper.SelectMysqlreturnDataset("select Product_Type ,Description from T_OKKEN where Product='" + tabPage3.Text + "'").Tables[0];
        //    dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        //}



    }
}
