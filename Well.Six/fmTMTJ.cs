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



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataSource();
        }

        private void BindDataSource()
        {

            OrderImpl service = new OrderImpl();
            var result = service.GetTJ(cbxCustomerId.SelectedValue.ToTryInt(), txtIssue.Text.Trim());
            if (result.Code == 0)
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
    }
}
