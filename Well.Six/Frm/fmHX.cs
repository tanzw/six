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
using Well.Model;

namespace Well.Six.Frm
{
    public partial class fmHX : Form
    {
        public fmHX()
        {
            InitializeComponent();
            radioButton1.Tag = (int)ChildType.六肖;
            radioButton2.Tag = (int)ChildType.五肖;
            radioButton3.Tag = (int)ChildType.四肖;
            radioButton4.Tag = (int)ChildType.三肖;
            radioButton5.Tag = (int)ChildType.二肖;

            txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 检测输入
            if (this.cbox.SelectedIndex == 0)
            {
                MessageEx.ShowWarning("请选择客户");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIssue.Text))
            {
                MessageEx.ShowWarning("请输入期号");
                return;
            }
            if (txtIssue.Text.Trim().Length != 7)
            {
                MessageEx.ShowWarning("请输入正确的期号");
                return;
            }
            if (GetRadioChecked() <= 1)
            {
                MessageEx.ShowWarning("请选择合肖类型");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMoney.Text.Trim()))
            {
                MessageEx.ShowWarning("请输入金额");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
            {
                MessageEx.ShowWarning("请输入生肖");
                return;
            }
            else
            {
                if (radioButton1.Checked && txt.Text.Trim().Length != 6)
                {
                    MessageEx.ShowWarning("生肖个数不正确");
                    return;
                }
                if (radioButton2.Checked && txt.Text.Trim().Length != 5)
                {
                    MessageEx.ShowWarning("生肖个数不正确");
                    return;
                }
                if (radioButton3.Checked && txt.Text.Trim().Length != 4)
                {
                    MessageEx.ShowWarning("生肖个数不正确");
                    return;
                }
                if (radioButton4.Checked && txt.Text.Trim().Length != 3)
                {
                    MessageEx.ShowWarning("生肖个数不正确");
                    return;
                }
                if (radioButton5.Checked && txt.Text.Trim().Length != 2)
                {
                    MessageEx.ShowWarning("生肖个数不正确");
                    return;
                }
                var str = txt.Text.Trim();
                var l = ServiceNum.GetZodiacArray();
                var flag = false;
                foreach (var s in str)
                {
                    var ss = s.ToString();
                    if (l.Count(x => x.Value == ss) == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    MessageEx.ShowWarning("输入的生肖不正确,请输入正确的生肖");
                    return;
                }
            }

            #endregion
            string OrderId = Guid.NewGuid().ToString("n");
            List<OrderTM> list = new List<OrderTM>();

            var detail = new OrderTM();
            detail.ChildType = GetRadioChecked();
            detail.Code = txt.Text.Trim();
            detail.Flag = 1;
            detail.Id = Guid.NewGuid().ToString("n");
            detail.InMoney = Convert.ToDecimal(txtMoney.Text.Trim());
            detail.Odds = 0;
            detail.OrderId = OrderId;
            detail.OutMoney = detail.Odds * detail.InMoney;
            detail.Remarks = detail.Code;
            detail.Sort = 1;
            detail.Status = (int)ResultStatus.Wait;
            list.Add(detail);

            Order<OrderTM> order = new Order<OrderTM>()
            {
                Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Create_User_Id = "0",
                Customer_Id = cbox.SelectedValue.ToString().ToTryInt(),
                Id = OrderId,
                IsDel = 0,
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.合肖,
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
                btnCancel_Click(null, null);
            }
            else
            {
                MessageBox.Show("失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }


        }

        private int GetRadioChecked()
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton3.Checked == false
                    && radioButton4.Checked == false && radioButton5.Checked == false)
            {
                return 0;
            }
            else
            {
                if (radioButton1.Checked)
                {
                    return (int)radioButton1.Tag;
                }
                else if (radioButton2.Checked)
                {
                    return (int)radioButton2.Tag;
                }
                else if (radioButton3.Checked)
                {
                    return (int)radioButton3.Tag;
                }
                else if (radioButton4.Checked)
                {
                    return (int)radioButton4.Tag;
                }
                else if (radioButton5.Checked)
                {
                    return (int)radioButton5.Tag;
                }
                else
                {
                    return 1;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            txtMoney.Text = "";
        }

        private void fmHX_Load(object sender, EventArgs e)
        {
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;

            Common.BindCustomers(cbox, (sender1, e1) =>
            {
                if (this.cbox.SelectedIndex == 0)
                {

                }
                else
                {

                    Common.CustomerId = cbox.SelectedValue.ToTryInt();
                }
            });
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

        private void button1_Click(object sender, EventArgs e)
        {
            txt.Text = "牛马羊鸡狗猪";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt.Text = "鼠虎兔龙蛇猴";
        }
    }
}
