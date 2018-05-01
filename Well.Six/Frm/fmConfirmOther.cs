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
using Well.Model;

namespace Well.Six.Frm
{
    public partial class fmConfirmOther : Form
    {
        public fmConfirmOther()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "投注确认";
        }

        public void InitForm(OrderMain order)
        {
            switch (order.Order_Type)
            {
                case (int)OrderType.波色:
                case (int)OrderType.大小单双:
                case (int)OrderType.尾数:
                case (int)OrderType.平特:
                    var TM = order as Order<OrderTM>;
                    lbCount.Text = TM.OrderDetails.Count.ToString();
                    lbMoney.Text = TM.Total_In_Money.ToString();
                    BindData(TM.OrderDetails);
                    break;
            }
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
