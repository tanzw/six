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

namespace Well.Six.Frm
{
    public partial class fmTotal : Form
    {
        public fmTotal()
        {
            InitializeComponent();
        }

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
                dataGridView1.DataSource = result.Body;
            }
            result = service.GetTotalList(new Model.OrderSearch() { CustomerId = cbxCustomerId.SelectedValue.ToTryInt(), Issue = txtIssue.Text.Trim() });
            if (result.Code == 0)
            {
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


    }
}
