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

namespace Well.Six.Frm
{
    public partial class fmQBZ : Form
    {
        public fmQBZ()
        {
            InitializeComponent();
            txtMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
        }


        List<OddsData> oddsList = null;
        private void fmQBZ_Load(object sender, EventArgs e)
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
                    OddsImpl oddservice = new OddsImpl();
                    oddsList = oddservice.GetList(cbox.SelectedValue.ToTryInt()).Body;
                    Common.CustomerId = cbox.SelectedValue.ToTryInt();
                }
            });
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<CodeNum> numlist = Well.Data.ServiceNum.GetNumsArray();
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
            if (string.IsNullOrWhiteSpace(txtMoney.Text.Trim()))
            {
                MessageEx.ShowWarning("请输入金额");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode1.Text) && numlist.Count(x => x.Value == txtCode1.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode2.Text) && numlist.Count(x => x.Value == txtCode2.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode3.Text) && numlist.Count(x => x.Value == txtCode3.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode4.Text) && numlist.Count(x => x.Value == txtCode4.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode5.Text) && numlist.Count(x => x.Value == txtCode5.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode6.Text) && numlist.Count(x => x.Value == txtCode6.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode7.Text) && numlist.Count(x => x.Value == txtCode7.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode8.Text) && numlist.Count(x => x.Value == txtCode8.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode9.Text) && numlist.Count(x => x.Value == txtCode9.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCode10.Text) && numlist.Count(x => x.Value == txtCode10.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合规则,请重新输入");
                return;
            }

            #endregion
            string OrderId = Guid.NewGuid().ToString("n");
            List<OrderTM> list = new List<OrderTM>();
            string str = "";
            int count = 0;
            foreach (var item in this.panel1.Controls)
            {
                if (item is TextBox)
                {
                    var cc = item as TextBox;
                    if (!string.IsNullOrWhiteSpace(cc.Text))
                    {
                        str += cc.Text.Trim() + "、";
                        count = count + 1;
                    }

                }
            }
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
            if (count < 5)
            {
                MessageEx.ShowWarning("输入号码最少5个");
                return;
            }

            var odds = oddsList.FirstOrDefault(x => x.ChildType == GetChildType(count));
            if (odds == null)
            {
                MessageEx.ShowWarning("未设置客户赔率");
                return;
            }
            var detail = new OrderTM();
            detail.ChildType = GetChildType(count);
            detail.Code = str;
            detail.Flag = 1;
            detail.Id = Guid.NewGuid().ToString("n");
            detail.InMoney = Convert.ToDecimal(txtMoney.Text.Trim());
            detail.Odds = odds.PL;
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
                Order_Type = (int)OrderType.全不中,
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (var item in this.panel1.Controls)
            {
                if (item is TextBox)
                {
                    var cc = item as TextBox;
                    cc.Text = "";

                }
            }
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

        private int GetChildType(int count)
        {
            var result = 0;
            switch (count)
            {
                case 5:
                    result = (int)ChildType.五不中;
                    break;
                case 6:
                    result = (int)ChildType.六不中;
                    break;
                case 7:
                    result = (int)ChildType.七不中;
                    break;
                case 8:
                    result = (int)ChildType.八不中;
                    break;
                case 9:
                    result = (int)ChildType.九不中;
                    break;
                case 10:
                    result = (int)ChildType.十不中;
                    break;
            }
            return result;
        }
    }
}
