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
using Well.Common.Extensions;
using Well.Common.Result;

namespace Well.Six.Frm
{
    public partial class fmTM : Form
    {
        public fmTM()
        {
            InitializeComponent();

            InitOption();
            //宋体, 15pt, style = Bold, Italic


        }

        public void InitOption()
        {
            var PointX = 20;
            var PointY = 20;
            var interval = 5;
            var currentColumn = 0;
            for (int i = 1; i < 50; i++)
            {
                Label lbNum = new Label();
                lbNum.Text = i.ToString().PadLeft(2, '0');
                lbNum.Size = new Size(35, 20);
                lbNum.Tag = lbNum.Text;
                lbNum.BackColor = ServiceNum.GetNumColor(i);
                lbNum.Name = "Code";
                lbNum.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));

                Label lbPL = new Label();
                lbPL.Text = "43.00";
                lbPL.Size = new Size(60, 20);
                lbPL.Tag = lbNum.Text;
                lbPL.Name = "PL";
                //  lbPL.BackColor = Color.Yellow;
                lbPL.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                TextBox txt = new TextBox();
                txt.Tag = lbNum.Text;
                txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
                txt.Size = new Size(45, 30);


                if (i == 1 || i == 11 || i == 21 || i == 31 || i == 41)
                {
                    PointY = 20;
                }
                PointX = 20;
                if (i % 10 > 0)
                {
                    currentColumn = i / 10 + 1;
                }
                else
                {
                    currentColumn = i / 10;
                }
                PointX = PointX + 155 * (currentColumn - 1);


                lbNum.Location = new Point(PointX, PointY);
                lbPL.Location = new Point(PointX + 35, PointY);
                txt.Location = new Point(PointX + 30 + 65, PointY);

                PointY = PointY + interval + lbNum.Height;

                this.groupBox2.Controls.Add(lbNum);

                this.groupBox2.Controls.Add(lbPL);

                this.groupBox2.Controls.Add(txt);

            }

        }

        private void fmTM_Load(object sender, EventArgs e)
        {
            Common.BindCustomers(this.cbox);
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var OrderId = Guid.NewGuid().ToString("n");
            var list = new List<OrderTM>();
            foreach (var control in this.groupBox2.Controls)
            {
                if (control is TextBox)
                {
                    var c = control as TextBox;
                    if (!string.IsNullOrWhiteSpace(c.Text))
                    {
                        OrderTM O = new OrderTM();
                        O.Id = Guid.NewGuid().ToString("N");
                        O.OrderId = OrderId;
                        O.InMoney = Convert.ToDecimal(c.Text);

                        O.Status = (int)ResultStatus.Wait;

                        var Code = this.groupBox2.Controls.Find("Code", false).FirstOrDefault(x => x.Tag == c.Tag);
                        if (Code != null)
                        {
                            var lbCode = Code as Label;
                            O.Code = lbCode.Text;
                        }
                        else
                        {
                            continue;
                        }

                        var PL = this.groupBox2.Controls.Find("PL", false).FirstOrDefault(x => x.Tag == c.Tag);
                        if (PL != null)
                        {
                            var lbPL = PL as Label;
                            O.Odds = Convert.ToDecimal(lbPL.Text);
                        }
                        else
                        {
                            continue;
                        }
                        O.OutMoney = O.Odds * O.InMoney;
                        list.Add(O);
                    }
                }

            }
            var order = new Order<OrderTM>()
            {
                Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Create_User_Id = "0",
                Customer_Id = cbox.SelectedValue.ToString().ToTryInt(),
                Id = OrderId,
                IsDel = 0,
                Issue = ServiceNum.GetIssue(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.特码,
                Total_In_Money = list.Sum(x => x.InMoney),
                Total_Out_Money = 0,
                Update_Time = "",
                Update_User_Id = "",
                OrderDetails = list
            };

            OrderImpl services = new OrderImpl();
            if (services.AddOrderTM(order).Code == 0)
            {
                MessageBox.Show("成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

        }
        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var control in this.groupBox2.Controls)
            {
                if (control is TextBox)
                {
                    var t = control as TextBox;
                    t.Text = "";
                }
            }
        }
    }
}
