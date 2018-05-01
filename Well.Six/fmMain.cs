using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Data;
using Well.Common.Extensions;

namespace Well.Six
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            BuildColums();
            fmdetail = new Frm.fmOrderDetails();
            fmdetail.StartPosition = FormStartPosition.Manual;

            fmdetail.MinimizeBox = false;
            fmdetail.MaximizeBox = false;
        }

        public void BuildColums()
        {

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


            System.Windows.Forms.DataGridViewCellStyle dgCellStyle_MiddleCenter = new System.Windows.Forms.DataGridViewCellStyle();
            dgCellStyle_MiddleCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;

            System.Windows.Forms.DataGridViewCellStyle dgCellStyle_MiddleR = new System.Windows.Forms.DataGridViewCellStyle();
            dgCellStyle_MiddleR.Alignment = DataGridViewContentAlignment.BottomRight;

            var c0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c0.ReadOnly = true;
            c0.DataPropertyName = "Id";
            c0.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c0.HeaderText = "订单号";
            c0.MinimumWidth = 90;
            c0.Name = "order_no";
            c0.Visible = false;

            var c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c1.ReadOnly = true;
            c1.DataPropertyName = "order_no";
            c1.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c1.HeaderText = "订单号";
            c1.MinimumWidth = 90;
            c1.Name = "order_no";

            var c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c2.ReadOnly = true;
            c2.DataPropertyName = "Issue";
            c2.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c2.HeaderText = "期号";
            c2.MinimumWidth = 70;
            c2.Width = 70;
            c2.Name = "issue";


            var c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c3.ReadOnly = true;
            c3.DataPropertyName = "customername";
            c3.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c3.HeaderText = "客户";
            c3.MinimumWidth = 80;
            c3.Width = 60;
            c3.Name = "Num1_Code";


            var c4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c4.ReadOnly = true;
            c4.DataPropertyName = "childtypename";
            c4.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c4.HeaderText = "玩法";
            c4.MinimumWidth = 80;
            c4.Width = 60;
            c4.Name = "Num2_Code";

            var c5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c5.ReadOnly = true;
            c5.DataPropertyName = "total_in_money";
            c5.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c5.HeaderText = "金额";
            c5.MinimumWidth = 70;
            c5.Width = 60;
            c5.Name = "Num3_Code";

            var c6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c6.ReadOnly = true;
            c6.DataPropertyName = "CreateTime";
            c6.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c6.HeaderText = "创建时间";
            c6.MinimumWidth = 120;
            c6.Width = 60;
            c6.Name = "Num4_Code";



            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            c0,
            c1,
            c2,
            c3,
            c4,
            c5,
            c6 });
        }

        public void BindDataSource()
        {
            OrderImpl service = new OrderImpl();
            var result = service.GetList(new Model.OrderSearch() { CustomerId = cbxCustomerId.SelectedValue.ToTryInt(), Issue = txtIssue.Text.Trim() });


            if (result.Code == 0)
            {
                dataGridView1.DataSource = result.Body;
            }

        }


        public void InitControls()
        {
            Common.BindCustomers(cbxCustomerId);
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;


        }
        Frm.fmOrderDetails fmdetail;
        private void Form1_Load(object sender, EventArgs e)
        {
            InitControls();
            BindDataSource();

        }

        private void btnTM_Click(object sender, EventArgs e)
        {
            Frm.fmTM fm = new Frm.fmTM();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //TODO:加载订单
            }
        }

        private void btnLM_Click(object sender, EventArgs e)
        {
            Frm.fmLM fm = new Frm.fmLM();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void btnLX_Click(object sender, EventArgs e)
        {
            Frm.fmLX fm = new Frm.fmLX();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void btnFastTM_Click(object sender, EventArgs e)
        {
            Frm.fmFastTM fm = new Frm.fmFastTM();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void btnPTYX_Click(object sender, EventArgs e)
        {
            Frm.fmPTYX fm = new Frm.fmPTYX();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        #region 系统菜单
        private void 开奖记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmNumersList fm = new Frm.fmNumersList();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmChangePassword fm = new Frm.fmChangePassword();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        Thread thread = null;
        private void 备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var t = Task.Run(() =>
            {
                MessageEx.Show("开始");
                for (int i = 0; i < 999999999999999999; i++)
                {

                    this.Invoke(new Action(() =>
                    {
                        btnPTYX.Text = i.ToString();

                    }));
                }
                MessageEx.Show("结束");
            });
        }


        public void Test()
        {
            MessageEx.Show("开始");


            for (int i = 0; i < 999999999999999999; i++)
            {
                this.Invoke(new Action(() =>
            {
                btnPTYX.Text = i.ToString();

            }));
            }

            MessageEx.Show("结束");
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sd = ServiceNum.GetIssue();
        }

        #endregion

        #region 设置菜单

        private void 赔率设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 客户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmCustomer fm = new Frm.fmCustomer();
            fm.ShowInTaskbar = false;
            fm.MinimizeBox = false;
            fm.MaximizeBox = false;

            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        #endregion

        #region 投注菜单

        private void 特码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTM_Click(sender, e);
        }

        private void 特码快捷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFastTM_Click(sender, e);
        }

        private void 连肖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLX_Click(sender, e);
        }

        private void 连码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLM_Click(sender, e);
        }

        private void btnFastLX_Click(object sender, EventArgs e)
        {
            Frm.fmFastLX fm = new Frm.fmFastLX();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataSource();
        }

        private void 删除订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            OrderImpl service = new OrderImpl();
            if (service.DeleteOrder(sd).Body)
            {
                BindDataSource();
            }

        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmTotal fm = new Frm.fmTotal();
            fm.ShowInTaskbar = false;
            fm.MinimizeBox = false;
            fm.MaximizeBox = false;

            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (fmdetail.IsDisposed)
            {
                fmdetail = new Frm.fmOrderDetails();
                fmdetail.StartPosition = FormStartPosition.Manual;
            }
            fmdetail.SetData(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            fmdetail.Location = new Point(this.Location.X + 936, this.Location.Y + 105);
            fmdetail.Show();
            fmdetail.TopLevel = true;
            fmdetail.TopMost = true;
            this.Activate();
        }

        private void btnSB_Click(object sender, EventArgs e)
        {
            Frm.fmBS fm = new Frm.fmBS();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //TODO:加载订单
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sd = (ChildType)601;
            var ddd = sd.ToString();
        }

        private void btnDXDS_Click(object sender, EventArgs e)
        {
            Frm.fmDXDS fm = new Frm.fmDXDS();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //TODO:加载订单
            }
        }
    }
}
