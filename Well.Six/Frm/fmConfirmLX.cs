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
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        bool isInit = false;

        public fmConfirmLX(Dictionary<int, decimal> _list, int _OrderType, int _custormeiId, decimal _money)
        {
            InitializeComponent();
        }




        public void InitForm(OrderMain order)
        {
            switch (order.Child_Type)
            {
                case (int)ChildType.特码:
                    var TM = order as Order<OrderTM>;
                    lbCount.Text = TM.OrderDetails.Count.ToString();
                    lbMoney.Text = TM.Total_In_Money.ToString();
                    BindData(TM.OrderDetails);
                    break;
                case (int)ChildType.二连肖:
                case (int)ChildType.三连肖:
                case (int)ChildType.四连肖:
                case (int)ChildType.五连肖:
                case (int)ChildType.二全中:
                case (int)ChildType.三全中:
                case (int)ChildType.四全中:
                case (int)ChildType.三中三:
                    var lblm = order as Order<OrderLXLM>;
                    lbCount.Text = lblm.OrderDetails.Count.ToString();
                    lbMoney.Text = lblm.Total_In_Money.ToString();
                    BindData(lblm.OrderDetails);
                    break;

            }

            //  


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
                        btnOK_Click(null, null);
                        break;
                }
            }
            return false;
        }

    }
}
