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

namespace Well.Six
{
    public partial class fmTMTJ : Form
    {
        public fmTMTJ()
        {
            InitializeComponent();


            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle() { Font = new Font("宋体", 12) };
            dataGridView1.DefaultCellStyle = CellStyle;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;


            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            textBox2.Text = "3000";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataSource();
        }

        private void BindDataSource()
        {

            OrderImpl service = new OrderImpl();
            var result = service.GetTJ(cbxCustomerId.SelectedValue.ToTryInt(), txtIssue.Text.Trim(), textBox1.Text.Trim());
            if (result.Code == 0 && result.Body.Count > 0)
            {
                dataGridView1.DataSource = result.Body;


                var maxV = result.Body.Max(x => x.Money);
                var minV = result.Body.Min(x => x.Money);
                decimal v = minV;

                List<KV> list = new List<KV>();

                var tagMoney = 0 - Convert.ToDecimal(textBox2.Text.Trim());

                while (v > 0 && v <= maxV)
                {

                    var totalWPMoney = 0M;
                    var totalMoney = 0M;
                    var fsMoney = 0M;

                    result.Body.ForEach(x =>
                    {
                        totalMoney += x.Money;
                        if (x.Money > v)
                        {
                            totalWPMoney += (x.Money - v);
                        }
                    });
                    fsMoney = totalMoney * 0.12M;
                    //总下注金额-总返水金额+外抛返水金额-中奖金额=盈利金额
                    var vv = totalMoney - fsMoney - (totalWPMoney - (totalWPMoney * 0.12M)) - (v * 43M);
                    list.Add(new KV() { V = v, Money = vv, WPMoney = totalWPMoney });
                    v = v + 10;
                }
                var tsum = result.Body.Sum(x => x.Money);
                KV dd = null;
                if (list.Count(x => x.Money < tagMoney) > 0)
                {
                    dd = list.Where(x => x.Money < tagMoney).OrderByDescending(x => x.Money).Take(1).ToList()[0];
                    label5.Text = "最高接:" + dd.V + ",盈亏：" + dd.Money;

                }
                else
                {
                    dd = new KV() { V = maxV, Money = (tsum - tsum * 0.12M - maxV * 43), WPMoney = 0 };
                    label5.Text = "最高接:" + maxV + ",盈亏：" + (tsum - tsum * 0.12M - maxV * 43);
                }
                label6.Text = "总特：" + tsum + ",外抛:" + dd.WPMoney + "剩余：" + (tsum - dd.WPMoney) + ",返水：" + ((tsum - dd.WPMoney) * 0.12M);
                var sdsd = Convert.ToDecimal((((tsum - dd.WPMoney) - ((tsum - dd.WPMoney) * 0.12M)) / 43).ToMoney(ObjectExtensions.MoneyPattern.Rounding));
                var sd1 = 49 - result.Body.Count() + result.Body.Count(x => x.Money < sdsd);
                var sd2 = 49;
                var sd3 = Convert.ToDecimal(sd1) / Convert.ToDecimal(sd2);
                label7.Text = "小于等于不亏：" + sdsd + ",机率:" + (sd3 * 100).ToMoney(ObjectExtensions.MoneyPattern.Rounding) + "%";
                //tempList.ForEach(x =>
                //{
                //    Math.Abs(x.Money) - tagMoney;
                //});
                //WinNumberImpl winService = new WinNumberImpl();
                //var ddd = winService.GetModel(new Model.WinNumber() { Issue = txtIssue.Text.Trim() });
                //var sssss = result.Body.FirstOrDefault(x => x.Code2 == ddd.Body.Num7_Code).Money;
                //if (sssss > dd.V)
                //{
                //    label8.Text = "中：" + dd.V + ",赔：" + dd.V * 43 + ",盈亏:"+ (tsum - tsum * 0.12M - dd.V * 43);
                //}
                //else
                //{
                //    label8.Text = "中：" + sssss + ",赔：" + sssss * 43 + ",盈亏:"+ (tsum - tsum * 0.12M - sssss * 43); 
                //}

            }
            else
            {
                dataGridView1.DataSource = result.Body;
            }

        }

        private void fmTMTJ_Load(object sender, EventArgs e)
        {
            Common.BindCustomers(cbxCustomerId);
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;
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
    }

    public class KV
    {
        /// <summary>
        /// 最高下注金额
        /// </summary>
        public decimal V { get; set; }

        /// <summary>
        /// 盈亏金额
        /// </summary>

        public decimal Money { get; set; }

        /// <summary>
        /// 外抛金额
        /// </summary>

        public decimal WPMoney { get; set; }
    }
}
