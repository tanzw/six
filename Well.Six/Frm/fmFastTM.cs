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
    public partial class fmFastTM : Form
    {
        public fmFastTM()
        {
            InitializeComponent();
        }
        List<CodeNum> list = Well.Data.ServiceNum.GetNumsArray();
        List<OrderTM> orderDetails = new List<OrderTM>();

        TMOdds tm = null;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCode.Text) && list.Count(x => x.Value == txtCode.Text.Trim()) == 0)
            {
                MessageEx.ShowWarning("号码不符合規則,請重新輸入");
                txtCode.Text = "";
                txtCode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                MessageEx.ShowWarning("請輸入金額!");
                txtMoney.Focus();
                return;
            }
            var item = new ListViewItem();
            item.UseItemStyleForSubItems = false;
            item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
            item.SubItems.Add(txtCode.Text.Trim());
            item.SubItems.Add(tm.Num_PL.ToMoney());
            item.SubItems.Add(txtMoney.Text.Trim());
            listView1.Items.Add(item);
            orderDetails.Add(new OrderTM()
            {
                Code = txtCode.Text.Trim(),
                Id = Guid.NewGuid().ToString("n"),
                Index = listView1.Items.Count + 1,
                InMoney = Convert.ToDecimal(txtMoney.Text.Trim()),
                Odds = tm.Num_PL,
                OutMoney = tm.Num_PL * Convert.ToDecimal(txtMoney.Text.Trim()),
                Remarks = "",
                Status = (int)ResultStatus.Wait,
                Flag = 1
            });
            txtCode.Text = "";
            txtCode.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string OrderId = Guid.NewGuid().ToString("n");
            Order<OrderTM> order = new Order<OrderTM>()
            {
                Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Create_User_Id = "0",
                Customer_Id = cbxCustomer.SelectedValue.ToString().ToTryInt(),
                Id = OrderId,
                IsDel = 0,
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.特码,
                Child_Type = (int)ChildType.特码快捷,
                Total_In_Money = orderDetails.Sum(x => x.InMoney),
                Total_Out_Money = 0,
                Update_Time = "",
                Update_User_Id = "",
                OrderDetails = orderDetails
            };
            order.OrderDetails.ForEach(x =>
            {
                x.OrderId = OrderId;
            });


            OrderImpl services = new OrderImpl();
            if (services.AddOrderTM(order).Code == 0)
            {
                MessageEx.Show("投注成功");
                listView1.Items.Clear();
                txtMoney.Text = "";
                txtCode.Text = "";
                orderDetails.Clear();
            }
            else
            {
                MessageEx.ShowError("投注失敗");
            }

        }


        private void BuildColumn()
        {

        }

        private void fmFastTM_Load(object sender, EventArgs e)
        {
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;
            this.txtMoney.KeyPress += new KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            Common.BindCustomers(cbxCustomer, (sender1, e1) =>
            {
                OddsImpl oddservice = new OddsImpl();
                var r = oddservice.GetList(cbxCustomer.SelectedValue.ToTryInt());
                var oddsList = r.Body.FirstOrDefault(x => x.OrderType == (int)ChildType.特码);
                tm = Newtonsoft.Json.JsonConvert.DeserializeObject<TMOdds>(oddsList.strJson);
                Common.CustomerId = cbxCustomer.SelectedValue.ToTryInt();
            });
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
        }

        private void fmFastTM_KeyDown(object sender, KeyEventArgs e)
        {
            // 组合键

            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)         //Ctrl+F1
            {
                btnOK_Click(null, null);
            }
        }
    }
}
