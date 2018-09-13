using System;
//using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ClassLibrary3
{
    public  class Excell
    {
        //public void ToExcel(DataGridView dataGridView1)
        //{
        //    try
        //    {
        //        //没有数据的话就不往下执行  
        //        if (dataGridView1.Rows.Count == 0)
        //            return;
        //        //实例化一个Excel.Application对象  
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        //        //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
        //        excel.Visible = true;

        //        //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
        //        excel.Application.Workbooks.Add(true);
        //        //生成Excel中列头名称  
        //        for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //        {
        //            if (dataGridView1.Columns[i].Visible == true)
        //            {
        //                excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
        //            }

        //        }
        //        //把DataGridView当前页的数据保存在Excel中  
        //        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //            for (int j = 0; j < dataGridView1.Columns.Count; j++)
        //            {
        //                if (dataGridView1.Columns[j].Visible == true)
        //                {
        //                    if (dataGridView1[j, i].ValueType == typeof(string))
        //                    {
        //                        excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
        //                    }
        //                    else
        //                    {
        //                        excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
        //                    }
        //                }

        //            }
        //        }

        //        //设置禁止弹出保存和覆盖的询问提示框
        //        excel.DisplayAlerts = false;
        //        excel.AlertBeforeOverwriting = false;

        //        //保存工作簿  
        //        excel.Application.Workbooks.Add(true).Save();
        //        //保存excel文件  
        //        excel.Save("D:" + "\\KKHMD.xls");

        //        //确保Excel进程关闭  
        //        excel.Quit();
        //        excel = null;
        //        GC.Collect();//如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出
        //        MessageBox.Show("文件已经成功导出！", "信息提示");

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "错误提示");
        //    }

        //}
        //public void DataGridViewToExcel(DataGridView dgv)
        //{
        //    #region   验证可操作性     

        //    //申明保存对话框      
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    //默然文件后缀      
        //    dlg.DefaultExt = "xlsx";
        //    //文件后缀列表      
        //    dlg.Filter = "EXCEL文件(*.XLS)|*.xlsx";
        //    //默然路径是系统当前路径      
        //    dlg.InitialDirectory = Directory.GetCurrentDirectory();
        //    //打开保存对话框      
        //    if (dlg.ShowDialog() == DialogResult.Cancel) return;
        //    //返回文件路径      
        //    string fileNameString = dlg.FileName;
        //    //验证strFileName是否为空或值无效      
        //    if (fileNameString.Trim() == " ")
        //    { return; }
        //    //定义表格内数据的行数和列数      
        //    int rowscount = dgv.Rows.Count;
        //    int colscount = dgv.Columns.Count;
        //    //行数必须大于0      
        //    if (rowscount <= 0)
        //    {
        //        MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //列数必须大于0      
        //    if (colscount <= 0)
        //    {
        //        MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //行数不可以大于65536      
        //    if (rowscount > 65536)
        //    {
        //        MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //列数不可以大于255      
        //    if (colscount > 255)
        //    {
        //        MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //验证以fileNameString命名的文件是否存在，如果存在删除它      
        //    FileInfo file = new FileInfo(fileNameString);
        //    if (file.Exists)
        //    {
        //        try
        //        {
        //            file.Delete();
        //        }
        //        catch (Exception error)
        //        {
        //            MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    #endregion
        //    Microsoft.Office.Interop.Excel.Application objExcel = null;
        //    Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
        //    Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
        //    try
        //    {
        //        //申明对象      
        //        objExcel = new Microsoft.Office.Interop.Excel.Application();
        //        objWorkbook = objExcel.Workbooks.Add(Missing.Value);
        //        objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
        //        //设置EXCEL不可见      
        //        objExcel.Visible = false;

        //        //向Excel中写入表格的表头      
        //        int displayColumnsCount = 1;
        //        for (int i = 0; i <= dgv.ColumnCount - 1; i++)
        //        {
        //            if (dgv.Columns[i].Visible == true && dgv.Columns[i].HeaderText.Trim() != "删除" && dgv.Columns[i].HeaderText.Trim() != "")
        //            {
        //                objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
        //                displayColumnsCount++;
        //            }
        //        }
        //        //设置进度条      
        //        //tempProgressBar.Refresh();
        //        //tempProgressBar.Visible = true;
        //        //tempProgressBar.Minimum = 1;
        //        //tempProgressBar.Maximum = dgv.RowCount;
        //        //tempProgressBar.Step = 1;
        //        //向Excel中逐行逐列写入表格中的数据      
        //        for (int row = 0; row <= dgv.RowCount - 1; row++)
        //        {
        //            //tempProgressBar.PerformStep();

        //            displayColumnsCount = 1;
        //            for (int col = 0; col < colscount; col++)
        //            {
        //                if (dgv.Columns[col].Visible == true && dgv.Columns[col].HeaderText != "删除" && dgv.Columns[col].HeaderText.Trim() != "")
        //                {
        //                    try
        //                    {
        //                        string Val = dgv.Rows[row].Cells[col].Value.ToString().Trim();
        //                        if (Val.Length > 8)
        //                        {
        //                            Val = "'" + Val;//加单引号
        //                        }
        //                        objExcel.Cells[row + 2, displayColumnsCount] = Val;
        //                        displayColumnsCount++;
        //                    }
        //                    catch (Exception)
        //                    {

        //                    }

        //                }
        //            }
        //        }
        //        //隐藏进度条      
        //        //tempProgressBar.Visible = false;
        //        //保存文件      
        //        objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        //                Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
        //                Missing.Value, Missing.Value);
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    finally
        //    {
        //        //关闭Excel应用      
        //        if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
        //        if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
        //        if (objExcel != null) objExcel.Quit();

        //        objsheet = null;
        //        objWorkbook = null;
        //        objExcel = null;
        //    }
        //    MessageBox.Show(fileNameString + "导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //}
        ///<summary>
        ///导出数据表：Excle
        ///</summary>
        ///<param name="myDGV"></param>
        public void ToExcel(DataGridView myDGV)
        {
            string path = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xlsx";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.ShowDialog();
            path = saveDialog.FileName;
            if (path.IndexOf(":") < 0) return; //判断是否点击取消
            try
            {
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }
                Excel.Workbooks workbooks = xlApp.Workbooks;
                Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                int colIndex = 0;
                //写入标题
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    if (myDGV.Columns[i].Visible)//用作于不导出隐藏列
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = myDGV.Columns[i].HeaderText;
                        //worksheet.Cells[1, i] = myDGV.Columns[i].HeaderText;
                    }
                }
                //写入数值
                for (int r = 0; r < myDGV.Rows.Count - 1; r++)
                {
                    colIndex = 0;
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        if (myDGV.Columns[i].Visible)
                        {
                            colIndex++;
                            worksheet.Cells[r + 2, colIndex] = myDGV.Rows[r].Cells[i].Value;
                        }
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                //worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
                if (path != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(path);
                        //fileSaved = true;
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n\r" + ex.Message);
                    }
                }
                xlApp.Quit();
                GC.Collect();//强行销毁
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL

                MessageBox.Show(path + "，导出成功", "系统提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
