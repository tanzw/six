using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Common.Extensions;

namespace Well.Six.Frm
{
    public partial class fmNumersList : Form
    {
        public fmNumersList()
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


            BuildColums();
            BindDataSource();
        }

        public void BuildColums()
        {
            System.Windows.Forms.DataGridViewCellStyle dgCellStyle_MiddleCenter = new System.Windows.Forms.DataGridViewCellStyle();
            dgCellStyle_MiddleCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;

            System.Windows.Forms.DataGridViewCellStyle dgCellStyle_MiddleR = new System.Windows.Forms.DataGridViewCellStyle();
            dgCellStyle_MiddleR.Alignment = DataGridViewContentAlignment.BottomRight;

            var c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c1.ReadOnly = true;
            c1.DataPropertyName = "Id";
            c1.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c1.HeaderText = "序号";
            c1.MinimumWidth = 40;
            c1.Width = 40;
            c1.Name = "Id";

            var c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c2.ReadOnly = true;
            c2.DataPropertyName = "Issue";
            c2.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c2.HeaderText = "期号";
            c2.MinimumWidth = 70;
            c2.Width = 70;
            c2.Name = "Issue";


            var c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c3.ReadOnly = true;
            c3.DataPropertyName = "Display1";
            c3.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c3.HeaderText = "平码1";
            c3.MinimumWidth = 60;
            c3.Width = 60;
            c3.Name = "Num1_Code";
            c3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var c4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c4.ReadOnly = true;
            c4.DataPropertyName = "Display2";
            c4.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c4.HeaderText = "平码2";
            c4.MinimumWidth = 60;
            c4.Width = 60;
            c4.Name = "Num2_Code";

            var c5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c5.ReadOnly = true;
            c5.DataPropertyName = "Display3";
            c5.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c5.HeaderText = "平码3";
            c5.MinimumWidth = 60;
            c5.Width = 60;
            c5.Name = "Num3_Code";

            var c6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c6.ReadOnly = true;
            c6.DataPropertyName = "Display4";
            c6.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c6.HeaderText = "平码4";
            c6.MinimumWidth = 60;
            c6.Width = 60;
            c6.Name = "Num4_Code";

            var c7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c7.ReadOnly = true;
            c7.DataPropertyName = "Display5";
            c7.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c7.HeaderText = "平码5";
            c7.MinimumWidth = 60;
            c7.Width = 60;
            c7.Name = "Num5_Code";


            var c8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c8.ReadOnly = true;
            c8.DataPropertyName = "Display6";
            c8.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c8.HeaderText = "平码6";
            c8.MinimumWidth = 60;
            c8.Width = 60;
            c8.Name = "Num6_Code";

            var c9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c9.ReadOnly = true;
            c9.DataPropertyName = "Display7";
            c9.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c9.HeaderText = "特码";
            c9.MinimumWidth = 60;
            c9.Width = 60;
            c9.Name = "Num7_Code";

            var c10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            c10.ReadOnly = true;
            c10.DataPropertyName = "Create_Time";
            c10.DefaultCellStyle = dgCellStyle_MiddleCenter;
            c10.HeaderText = "开奖日期";
            c10.MinimumWidth = 120;
            c10.Width = 60;
            c10.Name = "CreateTime";

            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            c1,
            c2,
            c9,
            c3,
            c4,
            c5,
            c6,
            c7,
            c8,
            c10});
        }

        public void BindDataSource()
        {
            Well.Data.WinNumberImpl service = new Data.WinNumberImpl();
            dataGridView1.DataSource = service.GetList(new Model.WinNumber() { }).Body;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Frm.fmNumberEdit fm = new fmNumberEdit();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                BindDataSource();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Frm.fmNumberEdit fm = new fmNumberEdit(dataGridView1.CurrentRow.Cells[0].Value.ToTryInt());
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                BindDataSource();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Well.Data.WinNumberImpl service = new Data.WinNumberImpl();
            service.Run(dataGridView1.CurrentRow.Cells[1].Value.ToString());
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
