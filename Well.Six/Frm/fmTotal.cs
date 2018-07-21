using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Data;
using Well.Common.Extensions;
using Microsoft.Office.Interop.Excel;

namespace Well.Six.Frm
{
    public partial class fmTotal : Form
    {
        public fmTotal()
        {
            InitializeComponent();
        }

        List<Model.TotalDetails> list1 = null;
        List<Model.TotalDetails> list2 = null;

        public void BindDataSource()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;


            TotalImpl service = new TotalImpl();
            var result = service.GetTotalDetailsList(new Model.OrderSearch() { CustomerId = cbxCustomerId.SelectedValue.ToTryInt(), Issue = txtIssue.Text.Trim() });
            if (result.Code == 0)
            {
                list1 = result.Body;
                dataGridView1.DataSource = result.Body;
            }
            result = service.GetTotalList(new Model.OrderSearch() { CustomerId = cbxCustomerId.SelectedValue.ToTryInt(), Issue = txtIssue.Text.Trim() });
            if (result.Code == 0)
            {
                list2 = result.Body;
                dataGridView2.DataSource = result.Body;
            }

        }

        private void fmTotal_Load(object sender, EventArgs e)
        {
            Common.BindCustomers(cbxCustomerId);
            WinNumberImpl service = new WinNumberImpl();
            txtIssue.Text = service.GetNewIssue(true).Body;
            BindDataSource();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataSource();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;

            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        //关闭ToolStripMenuItem_Click(null, null);
                        this.Close();
                        break;
                    case Keys.Enter:
                        btnSearch_Click(null, null);

                        break;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xlsx";
            saveDialog.FileName = txtIssue.Text.Trim();
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            workbook.Worksheets.Add();
            workbook.Worksheets.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            Microsoft.Office.Interop.Excel.Worksheet worksheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[2];
            Microsoft.Office.Interop.Excel.Worksheet worksheet2 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[3];
            int columnIndex = 0;
            int currentRow = 0;
            int beginColumn = 0;
            int endColumn = 0;

            #region 客户统计
            for (int i = 0; i < list2.Count; i++)
            {

                if (i == 0)
                {
                    currentRow = 1;
                    beginColumn = 2;
                    endColumn = 7;
                }
                else
                {
                    currentRow = 1;
                    beginColumn = 1 + i * 5 + columnIndex * 3;
                    endColumn = beginColumn + 5;
                }
                //写入客户姓名
                MergeCells(worksheet, currentRow, beginColumn, currentRow, endColumn, list2[i].CustomerName);


                //写入标题
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    worksheet.Cells[2, beginColumn + j] = dataGridView1.Columns[j].HeaderText;
                    Range range = worksheet.Range[worksheet.Cells[2, beginColumn + j], worksheet.Cells[2, beginColumn + j]];
                    range.Font.Size = 18;
                    range.Font.Bold = true;
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                }
                //写入内容
                var temp = list1.Where(x => x.CustomerId == list2[i].CustomerId).ToList();
                for (int j = 0; j < temp.Count; j++)
                {
                    worksheet.Cells[3 + j, beginColumn + 0] = temp[j].Issue;
                    worksheet.Cells[3 + j, beginColumn + 1] = temp[j].OrderTypeName;
                    worksheet.Cells[3 + j, beginColumn + 2] = temp[j].InMoney;
                    worksheet.Cells[3 + j, beginColumn + 3] = temp[j].ReturnMoney;
                    worksheet.Cells[3 + j, beginColumn + 4] = temp[j].OutMoney;
                    worksheet.Cells[3 + j, beginColumn + 5] = temp[j].total;

                    Range range = worksheet.Range[worksheet.Cells[3 + j, beginColumn + 0], worksheet.Cells[3 + j, beginColumn + 5]];
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    currentRow = 3 + j;
                }
                //写入合计
                worksheet.Cells[currentRow + 1, beginColumn + 0] = list2[i].Issue;
                worksheet.Cells[currentRow + 1, beginColumn + 1] = "合计";
                worksheet.Cells[currentRow + 1, beginColumn + 2] = list2[i].InMoney;
                worksheet.Cells[currentRow + 1, beginColumn + 3] = list2[i].ReturnMoney;
                worksheet.Cells[currentRow + 1, beginColumn + 4] = list2[i].OutMoney;
                worksheet.Cells[currentRow + 1, beginColumn + 5] = list2[i].total;
                Range range1 = worksheet.Range[worksheet.Cells[currentRow + 1, beginColumn + 0], worksheet.Cells[currentRow + 1, beginColumn + 5]];
                range1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range1.Font.ColorIndex = 3;
                range1.Font.Bold = true;

                columnIndex = columnIndex + 1;
            }

            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            #endregion

            #region 每个订单详情
            TotalImpl service = new TotalImpl();
            List<Model.OrderResult> list3 = service.GetOrderResult(new Model.OrderSearch() { Issue = txtIssue.Text.Trim() }).Body;
            currentRow = 0;
            int currentColumn = 0;
            for (int i = 0; i < list3.Count; i++)
            {


                if (i % 10 == 0)
                {
                    currentRow = 0 + 1;
                    currentColumn = (i / 10) * 2 + 2;
                }
                else
                {
                    currentRow = currentRow + 1;
                }

                worksheet1.Cells[currentRow, currentColumn] = (list3[i].Sort + list3[i].OrderTypeName);
                worksheet1.Cells[currentRow, currentColumn + 1] = list3[i].Money;

                Range range = worksheet1.Range[worksheet1.Cells[currentRow, currentColumn], worksheet1.Cells[currentRow, currentColumn]];
                range.Font.Bold = true;

                Range range1 = worksheet1.Range[worksheet1.Cells[currentRow, currentColumn + 1], worksheet1.Cells[currentRow, currentColumn + 1]];
                range1.Font.ColorIndex = 3;
            }
            worksheet1.Columns.EntireColumn.AutoFit();//列宽自适应

            #endregion

            #region 总统计
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                worksheet2.Cells[1, 2 + i] = dataGridView2.Columns[i].HeaderText;
                Range range = worksheet2.Range[worksheet2.Cells[1, 2 + i], worksheet2.Cells[1, 2 + i]];
                range.Font.Size = 18;
                range.Font.Bold = true;
                range.Interior.ColorIndex = 46;
                range.Interior.Pattern = -4105;
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            }

            currentRow = 1;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                currentRow = currentRow + 1;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    worksheet2.Cells[currentRow, 2 + j] = dataGridView2.Rows[i].Cells[j].Value;
                    Range range = worksheet2.Range[worksheet2.Cells[currentRow, 2 + j], worksheet2.Cells[currentRow, 2 + j]];
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                }
            }

            worksheet2.Cells[currentRow + 1, 2 + 0] = txtIssue.Text;
            worksheet2.Cells[currentRow + 1, 2 + 1] = "合计";
            worksheet2.Cells[currentRow + 1, 2 + 2] = list2.Sum(x => x.InMoney);
            worksheet2.Cells[currentRow + 1, 2 + 3] = list2.Sum(x => x.ReturnMoney);
            worksheet2.Cells[currentRow + 1, 2 + 4] = list2.Sum(x => x.OutMoney);
            worksheet2.Cells[currentRow + 1, 2 + 5] = list2.Sum(x => x.total);
            Range range2 = worksheet2.Range[worksheet2.Cells[currentRow + 1, 2], worksheet2.Cells[currentRow + 1, 2 + 5]];
            range2.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range2.Font.Bold = true;
            range2.Font.ColorIndex = 3;

            worksheet2.Columns.EntireColumn.AutoFit();//列宽自适应
            #endregion

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;

                    workbook.SaveCopyAs(saveFileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + saveDialog.FileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 合并单元格，并赋值，对指定WorkSheet操作
        /// </summary>
        /// <param name="sheetIndex">WorkSheet索引</param>
        /// <param name="beginRowIndex">开始行索引</param>
        /// <param name="beginColumnIndex">开始列索引</param>
        /// <param name="endRowIndex">结束行索引</param>
        /// <param name="endColumnIndex">结束列索引</param>
        /// <param name="text">合并后Range的值</param>
        public void MergeCells(Microsoft.Office.Interop.Excel.Worksheet workSheet, int beginRowIndex, int beginColumnIndex, int endRowIndex, int endColumnIndex, string text)
        {
            Microsoft.Office.Interop.Excel.Range range = workSheet.Range[workSheet.Cells[beginRowIndex, beginColumnIndex], workSheet.Cells[endRowIndex, endColumnIndex]];

            range.ClearContents(); //先把Range内容清除，合并才不会出错
            range.MergeCells = true;

            range.Value2 = text;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.Interior.ColorIndex = 46;
            range.Interior.Pattern = -4105;
            range.Font.Bold = true;
            range.Font.Size = 24;
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }
    }
}
