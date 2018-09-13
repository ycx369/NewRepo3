namespace ClassLibrary3
{
    class Excel1
    {
        //Excle (io流操作类)
        ///<summary>
        ///导出数据表：Excle (io流操作类)
        ///</summary>
        ///<param name="myDGV"></param>
        //public void _ToExcel2(DataGridView myDGV)
        //{
        //    string path = "";
        //    SaveFileDialog saveDialog = new SaveFileDialog();
        //    saveDialog.DefaultExt = "xls";
        //    saveDialog.Filter = "Excel97-2003 (*.xls)|*.xls|All Files (*.*)|*.*";
        //    saveDialog.ShowDialog();
        //    path = saveDialog.FileName;
        //    if (path.IndexOf(":") < 0) return; //判断是否点击取消
        //    try
        //    {
        //        Thread.Sleep(1000);
        //        StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
        //        StringBuilder sb = new StringBuilder();
        //        //写入标题
        //        for (int k = 0; k < myDGV.Columns.Count; k++)
        //        {
        //            if (myDGV.Columns[k].Visible)//导出可见的标题
        //            {
        //                //"\t"就等于键盘上的Tab,加个"\t"的意思是: 填充完后进入下一个单元格.
        //                sb.Append(myDGV.Columns[k].HeaderText.ToString().Trim() + "\t");
        //            }
        //        }
        //        sb.Append(Environment.NewLine);//换行
        //        //写入每行数值
        //        for (int i = 0; i < myDGV.Rows.Count - 1; i++)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //            for (int j = 0; j < myDGV.Columns.Count; j++)
        //            {
        //                if (myDGV.Columns[j].Visible)//导出可见的单元格
        //                {
        //                    //注意单元格有一定的字节数量限制,如果超出,就会出现两个单元格的内容是一模一样的.
        //                    //具体限制是多少字节,没有作深入研究.
        //                    sb.Append(myDGV.Rows[i].Cells[j].Value.ToString().Trim() + "\t");
        //                }
        //            }
        //            sb.Append(Environment.NewLine); //换行
        //        }
        //        sw.Write(sb.ToString());
        //        sw.Flush();
        //        sw.Close();
        //        MessageBox.Show(path + "，导出成功", "系统提示", MessageBoxButtons.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public class ExcelUnit
     
            System.Data.DataTable table11 = new System.Data.DataTable();

            //public static ExportToExcel(System.Data.DataTable table)
            //{

            //    bool fileSaved = false;

            //    //ExcelApp xlApp = new ExcelApp();

            //    Excel.Application xlApp = new Excel.Application();

            //    if (xlApp == null)
            //    {
            //        return;
            //    }

            //    Workbooks workbooks = xlApp.Workbooks;
            //    Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //    Worksheet worksheet = (Worksheet)workbook.Worksheets[1];//取得sheet1

            //    long rows = table.Rows.Count;

            //    /*下边注释的两行代码当数据行数超过行时，出现异常：异常来自HRESULT:0x800A03EC。因为：Excel 2003每个sheet只支持最大行数据

            //    //Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[table.Rows.Count+2, gridview.Columns.View.VisibleColumns.Count+1]);

            //    //fchR.Value2 = datas;*/

            //    if (rows > 65535)
            //    {

            //        long pageRows = 60000;//定义每页显示的行数,行数必须小于

            //        int scount = (int)(rows / pageRows);

            //        if (scount * pageRows < table.Rows.Count)//当总行数不被pageRows整除时，经过四舍五入可能页数不准
            //        {
            //            scount = scount + 1;
            //        }

            //        for (int sc = 1; sc <= scount; sc++)
            //        {
            //            if (sc > 1)
            //            {

            //                object missing = System.Reflection.Missing.Value;

            //                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(

            //               missing, missing, missing, missing);//添加一个sheet

            //            }

            //            else
            //            {
            //                worksheet = (Worksheet)workbook.Worksheets[sc];//取得sheet1
            //            }

            //            string[,] datas = new string[pageRows + 1, table.Columns.Count + 1];

            //            for (int i = 0; i < table.Columns.Count; i++) //写入字段
            //            {
            //                datas[0, i] = table.Columns[i].Caption;
            //            }

            //            Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, table.Columns.Count]);
            //            range.Interior.ColorIndex = 15;//15代表灰色
            //            range.Font.Bold = true;
            //            range.Font.Size = 9;

            //            int init = int.Parse(((sc - 1) * pageRows).ToString());
            //            int r = 0;
            //            int index = 0;
            //            int result;

            //            if (pageRows * sc >= table.Rows.Count)
            //            {
            //                result = table.Rows.Count;
            //            }
            //            else
            //            {
            //                result = int.Parse((pageRows * sc).ToString());
            //            }
            //            for (r = init; r < result; r++)
            //            {
            //                index = index + 1;
            //                for (int i = 0; i < table.Columns.Count; i++)
            //                {
            //                    if (table.Columns[i].DataType == typeof(string) || table.Columns[i].DataType == typeof(Decimal) || table.Columns[i].DataType == typeof(DateTime))
            //                    {
            //                        object obj = table.Rows[r][table.Columns[i].ColumnName];
            //                        datas[index, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式

            //                    }

            //                }
            //            }

            //            Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[index + 2, table.Columns.Count + 1]);

            //            fchR.Value2 = datas;
            //            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。

            //            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[index + 1, table.Columns.Count]);

            //            //15代表灰色

            //            range.Font.Size = 9;
            //            range.RowHeight = 14.25;
            //            range.Borders.LineStyle = 1;
            //            range.HorizontalAlignment = 1;

            //        }

            //    }

            //    else
            //    {

            //        string[,] datas = new string[table.Rows.Count + 2, table.Columns.Count + 1];
            //        for (int i = 0; i < table.Columns.Count; i++) //写入字段         
            //        {
            //            datas[0, i] = table.Columns[i].Caption;
            //        }

            //        Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, table.Columns.Count]);
            //        range.Interior.ColorIndex = 15;//15代表灰色
            //        range.Font.Bold = true;
            //        range.Font.Size = 9;

            //        int r = 0;
            //        for (r = 0; r < table.Rows.Count; r++)
            //        {
            //            for (int i = 0; i < table.Columns.Count; i++)
            //            {
            //                if (table.Columns[i].DataType == typeof(string) || table.Columns[i].DataType == typeof(Decimal) || table.Columns[i].DataType == typeof(DateTime))
            //                {
            //                    object obj = table.Rows[r][table.Columns[i].ColumnName];
            //                    datas[r + 1, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式

            //                }

            //            }

            //            //System.Windows.Forms.Application.DoEvents();

            //        }

            //        Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[table.Rows.Count + 2, table.Columns.Count + 1]);

            //        fchR.Value2 = datas;

            //        worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。

            //        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[table.Rows.Count + 1, table.Columns.Count]);

            //        //15代表灰色

            //        range.Font.Size = 9;
            //        range.RowHeight = 14.25;
            //        range.Borders.LineStyle = 1;
            //        range.HorizontalAlignment = 1;
            //    }

            //    //if (saveFileName != "")
            //    //{
            //    //    try
            //    //    {
            //    //        workbook.Saved = true;
            //    //        workbook.SaveCopyAs(saveFileName);
            //    //        fileSaved = true;

            //    //    }

            //    //    catch (Exception ex)
            //    //    {
            //    //        fileSaved = false;
            //    //    }

            //    //}

            //    //else
            //    //{

            //    //    fileSaved = false;

            //    //}

            //    xlApp.Quit();

            //    GC.Collect();//强行销毁 

            //}

       
    }

    }

