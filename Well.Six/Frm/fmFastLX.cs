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
    public partial class fmFastLX : Form
    {
        List<string> charList = new List<string>();
        LXOdds odds = null;
        List<OrderLXLM> orderDetails = new List<OrderLXLM>();
        Dictionary<int, string> zodiacArray = null;
        List<int> tempList = new List<int>();


        public fmFastLX()
        {

            InitializeComponent();
            charList.Add("1");
            charList.Add("2");
            charList.Add("3");
            charList.Add("Q");
            charList.Add("W");
            charList.Add("E");
            charList.Add("A");
            charList.Add("S");
            charList.Add("D");
            charList.Add("Z");
            charList.Add("X");
            charList.Add("C");
            charList.Add("q");
            charList.Add("w");
            charList.Add("e");
            charList.Add("a");
            charList.Add("s");
            charList.Add("d");
            charList.Add("z");
            charList.Add("x");
            charList.Add("c");
            zodiacArray = ServiceNum.GetZodiacArray();

        }



        private void fmFastLX_KeyDown(object sender, KeyEventArgs e)
        {
            // 组合键

            if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Control)         //Ctrl+F1
            {
                btnOK_Click(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void fmFastLX_Load(object sender, EventArgs e)
        {
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;
            this.txtMoney.KeyPress += new KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            Common.BindLXType(comboBox1, (sender1, e1) =>
            {
                if (cbxCustomer.SelectedIndex == 0 || comboBox1.SelectedIndex == 0)
                {
                    return;
                }
                OddsImpl oddservice = new OddsImpl();
                var r = oddservice.GetList(cbxCustomer.SelectedValue.ToTryInt());
                var oddsList = r.Body.FirstOrDefault(x => x.OrderType == comboBox1.SelectedValue.ToTryInt());
                odds = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(oddsList.strJson);
            });
            Common.BindCustomers(cbxCustomer, (sender1, e1) =>
            {
                if (cbxCustomer.SelectedIndex == 0 || comboBox1.SelectedIndex == 0)
                {
                    return;
                }
                OddsImpl oddservice = new OddsImpl();
                var r = oddservice.GetList(cbxCustomer.SelectedValue.ToTryInt());
                var oddsList = r.Body.FirstOrDefault(x => x.OrderType == comboBox1.SelectedValue.ToTryInt());
                odds = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(oddsList.strJson);
                Common.CustomerId = cbxCustomer.SelectedValue.ToTryInt();
            });
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 检测输入
            if (comboBox1.SelectedIndex == 0)
            {
                MessageEx.ShowWarning("请选择连肖类型");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageEx.ShowWarning("请输入组合代码");
                txtCode.Text = "";
                txtCode.Focus();
                return;
            }
            else
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    if (txtCode.Text.Trim().Length != 2)
                    {
                        MessageEx.ShowWarning("您输入的组合代码不符合规则,请重新输入");
                        txtCode.Focus();
                        return;
                    }
                }

                if (comboBox1.SelectedIndex == 2)
                {
                    if (txtCode.Text.Trim().Length != 3)
                    {
                        MessageEx.ShowWarning("您输入的组合代码不符合规则,请重新输入");
                        txtCode.Focus();
                        return;
                    }
                }

                if (comboBox1.SelectedIndex == 3)
                {
                    if (txtCode.Text.Trim().Length != 4)
                    {
                        MessageEx.ShowWarning("您输入的组合代码不符合规则,请重新输入");
                        txtCode.Focus();
                        return;
                    }
                }

                if (comboBox1.SelectedIndex == 5)
                {
                    if (txtCode.Text.Trim().Length != 5)
                    {
                        MessageEx.ShowWarning("您输入的组合代码不符合规则,请重新输入");
                        txtCode.Focus();
                        return;
                    }
                }

                bool flag = true;

                foreach (var itemss in txtCode.Text.Trim())
                {
                    if (!charList.Contains(itemss.ToString()))
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                {
                    MessageEx.ShowWarning("您输入的组合代码不符合规则,请重新输入");
                    txtCode.Focus();
                    return;
                }
            }


            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                MessageEx.ShowWarning("請輸入金額!");
                txtMoney.Focus();
                return;
            }
            #endregion
            var detail = new OrderLXLM();
            detail.Id = Guid.NewGuid().ToString("n");
            detail.Status = (int)ResultStatus.Wait;
            detail.Sort = listView1.Items.Count + 1;

            detail.InMoney = Convert.ToDecimal(txtMoney.Text);


            var item = new ListViewItem();
            item.UseItemStyleForSubItems = false;
            item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
            string str = "";
            int charIndex = 0;
            foreach (var itemss in txtCode.Text.Trim())
            {

                string sd = itemss.ToString().Replace("1", "鼠").Replace("2", "牛").Replace("3", "虎")
                    .Replace("Q", "兔").Replace("q", "兔")
                    .Replace("W", "龙").Replace("w", "龙")
                    .Replace("E", "蛇").Replace("e", "蛇")
                    .Replace("A", "马").Replace("a", "马")
                    .Replace("S", "羊").Replace("s", "羊")
                    .Replace("D", "猴").Replace("d", "猴")
                    .Replace("Z", "鸡").Replace("z", "鸡")
                    .Replace("X", "狗").Replace("x", "狗")
                    .Replace("C", "猪").Replace("c", "猪");
                var code = zodiacArray.First(x => x.Value == sd).Key;
                tempList.Add(code);

                str += sd + "、";
                switch (charIndex)
                {
                    case 0:
                        detail.Code1 = code.ToString();
                        detail.Zodiac1 = sd;
                        break;
                    case 1:
                        detail.Code2 = code.ToString();
                        detail.Zodiac2 = sd;
                        break;
                    case 2:
                        detail.Code3 = code.ToString();
                        detail.Zodiac3 = sd;
                        break;
                    case 3:
                        detail.Code4 = code.ToString();
                        detail.Zodiac4 = sd;
                        break;
                    case 4:
                        detail.Code5 = code.ToString();
                        detail.Zodiac5 = sd;
                        break;
                }

                charIndex = charIndex + 1;
            }
            detail.ChildType = comboBox1.SelectedValue.ToTryInt();
            detail.Odds = GetMinOdds(odds.List, tempList);
            detail.OutMoney = detail.InMoney * detail.Odds;
            str = str.Substring(0, str.Length - 1);
            detail.Remarks = str;
            orderDetails.Add(detail);
            item.SubItems.Add(str);

            item.SubItems.Add(detail.Odds.ToMoney());
            item.SubItems.Add(txtMoney.Text.Trim());
            listView1.Items.Insert(0, item);
            tempList.Clear();
            txtCode.Text = "";
            txtCode.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string OrderId = Guid.NewGuid().ToString("n");

            Order<OrderLXLM> order = new Order<OrderLXLM>()
            {
                Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Create_User_Id = "0",
                Customer_Id = cbxCustomer.SelectedValue.ToString().ToTryInt(),
                Id = OrderId,
                IsDel = 0,
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.连肖,
                Child_Type = comboBox1.SelectedValue.ToTryInt(),
                Update_Time = "",
                Update_User_Id = "",
                OrderDetails = orderDetails,
                Total_In_Money = orderDetails.Sum(x => x.InMoney),
                Total_Out_Money = 0
            };
            order.OrderDetails.ForEach(x => { x.OrderId = OrderId; });
            OrderImpl service = new OrderImpl();
            if (service.AddOrderLXLM(order).Code == 0)
            {
                MessageEx.Show("投注成功");
                listView1.Items.Clear();
                txtMoney.Text = "";
                txtCode.Text = "";
                orderDetails.Clear();
            }
            else
            {
                MessageEx.ShowError("投注失败");
            }
        }

        private decimal GetMinOdds(Dictionary<int, decimal> dic, List<int> l)
        {
            var temp = new List<decimal>();

            foreach (var item in l)
            {
                temp.Add(dic[item]);
            }

            return temp.OrderBy(x => x).FirstOrDefault();
        }
    }
}
