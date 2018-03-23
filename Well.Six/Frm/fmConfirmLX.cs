using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Well.Data;
using Well.Model;

namespace Well.Six.Frm
{
    public partial class fmConfirmLX : Form
    {

        public fmConfirmLX()
        {
            InitializeComponent();
        }

        bool isInit = false;

        public fmConfirmLX(Dictionary<int, decimal> _list, int _OrderType, int _custormeiId, decimal _money)
        {
            InitializeComponent();
        }

        private Order<OrderLXLM> OrderLXLM
        {
            get; set;
        }

        private Order<OrderLXLM> OrderTM
        {
            get; set;
        }

        public void InitForm<T>(Order<T> order)
        {
            BindData(order.OrderDetails);


        }


        private void BindData(object dataSource)
        {
            //dataGridView1.a

            dataGridView1.AutoGenerateColumns = false;
            //dv.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dv.RowHeadersDefaultCellStyle = new DataGridViewCellStyle() { Font = new Font("宋体", 15, FontStyle.Bold), BackColor = Color.FromArgb(176, 203, 240) };
            dataGridView1.RowHeadersWidth = 25;
            dataGridView1.AllowUserToAddRows = false;
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle() { Font = new Font("宋体", 9) };
            dataGridView1.DefaultCellStyle = CellStyle;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.DataSource = dataSource;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void fmConfirmLX_Load(object sender, EventArgs e)
        {

        }


    }
}
