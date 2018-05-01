using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Common.Extensions;
using Well.Model;
using Well.Data;

namespace Well.Six.UControls
{
    public partial class ULX : UserControl
    {
        public ULX()
        {
            InitializeComponent();
        }

        private void ULX_Load(object sender, EventArgs e)
        {

        }

        #region 公有属性
        int _OrderType = 0;
        int _ChildType = 0;
        public int OrderType
        {
            get { return _OrderType; }
            set { _OrderType = value; }
        }
        public int ChildType
        {
            get { return _ChildType; }
            set { _ChildType = value; }
        }
        public int MinCount
        {
            get
            {
                var v = 0;
                switch (_OrderType)
                {
                    case 12:
                        v = 2;
                        break;
                    case 13:
                        v = 3;
                        break;
                    case 14:
                        v = 4;
                        break;
                    case 15:
                        v = 5;
                        break;
                    default:
                        v = 2;
                        break;
                }
                return v;
            }
        }

        #endregion

        #region 窗体初始化

        public void InitControls()
        {
            //   this.BackColor = Color.Yellow;



            this.txtMoney.KeyPress += new KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            InitOptions();
            Common.BindCustomers(this.cbox, (sender1, e1) =>
            {
                var controls = this.groupBox2.Controls.Find("PL", false);

                if (this.cbox.SelectedIndex == 0)
                {
                    foreach (var control in controls)
                    {
                        if (control is Label)
                        {
                            var t = control as Label;
                            t.Text = "00.00";
                        }
                    }
                }
                else
                {
                    OddsImpl oddservice = new OddsImpl();
                    var r = oddservice.GetList(cbox.SelectedValue.ToTryInt());
                    var oddsList = r.Body.FirstOrDefault(x => x.OrderType == ChildType);
                    var ptyx = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(oddsList.strJson);
                    Common.CustomerId = cbox.SelectedValue.ToTryInt();
                    foreach (var control in controls)
                    {
                        if (control is Label)
                        {
                            var t = control as Label;
                            t.Text = ptyx.List.FirstOrDefault(x => x.Key == t.Tag.ToTryInt()).Value.ToMoney();

                        }
                    }
                }
            });

            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;
        }

        private void InitOptions()
        {
            // var NumsAllArray = Well.Data.ServiceNum.GetNumArray();

            var NumsAllArray = Well.Data.ServiceNum.GetNumsArray();

            var dic = Well.Data.ServiceNum.GetZodiacArray();
            int interval = 25;
            int InitLX = 17;
            int InitY = 38;
            int InitRX = 419;

            int CurrentX = InitLX;
            int CurrentY = InitY;

            for (int i = 0; i < dic.Count; i++)
            {

                Label lbName = new Label();
                lbName.Text = dic[i + 1];
                lbName.Tag = i + 1;
                lbName.Size = new Size(17, 12);
                lbName.AutoSize = true;

                lbName.Location = new Point(CurrentX, CurrentY);

                this.groupBox2.Controls.Add(lbName);
                var temp = NumsAllArray.Where(x => x.Zodiac == dic[i + 1]).ToList();
                int CodeWidth = 0;
                for (int j = 0; j < temp.Count; j++)
                {
                    Label lbCode = new Label();
                    lbCode.Text = temp[j].Value;
                    lbCode.Tag = lbCode.Text;
                    lbCode.BackColor = temp[j].CodeColor;
                    lbCode.AutoSize = true;
                    lbCode.Size = new Size(17, 12);
                    CodeWidth = lbCode.Width;
                    var newX = CurrentX + lbName.Width + CodeWidth * j + j * interval;
                    lbCode.Location = new Point(newX, CurrentY);
                    this.groupBox2.Controls.Add(lbCode);
                }

                Label lbPL = new Label();
                lbPL.Text = "00.00";
                lbPL.Tag = lbName.Tag;
                lbPL.Size = new Size(17, 12);
                lbPL.AutoSize = true;
                lbPL.Name = "PL";
                lbPL.Location = new Point(CurrentX + lbName.Width + CodeWidth * 5 + 5 * interval, CurrentY);
                this.groupBox2.Controls.Add(lbPL);

                CheckBox ck = new CheckBox();
                ck.AutoSize = true;
                ck.TabIndex = i + 2;
                ck.Name = "CK";
                ck.Tag = lbName.Tag;
                ck.Enter += new System.EventHandler(Common.CheckBox_UpdateColor_Enter);
                ck.Leave += new System.EventHandler(Common.CheckBox_UpdateColor_Leave);
                ck.Location = new Point(CurrentX + lbName.Width + 15 + CodeWidth * 5 + 5 * interval + lbPL.Width, CurrentY + 5);
                this.groupBox2.Controls.Add(ck);

                var K = i + 1;
                if (K < 6)
                {
                    CurrentX = InitLX;
                    CurrentY = InitY + (interval * K) + lbName.Height * K;
                }
                else
                {
                    CurrentX = InitRX;
                    CurrentY = InitY + (interval * (K - 6) + lbName.Height * (K - 6));
                }
            }
        }

        #endregion

        #region 按钮事件
        public void btnOK_Click(object sender, EventArgs e)
        {
            #region 检测输入
            if (this.cbox.SelectedIndex == 0)
            {
                MessageEx.ShowWarning("请选择客户");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtMoney.Text))
            {
                MessageEx.ShowWarning("请输入单注金额");
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

            #endregion

            #region 获取输入
            Dictionary<int, decimal> list = new Dictionary<int, decimal>();
            foreach (var control in this.groupBox2.Controls)
            {
                if (control is CheckBox)
                {
                    var ck = control as CheckBox;
                    if (ck.Checked)
                    {
                        var sdsdsdsd = this.groupBox2.Controls.Find("PL", false);
                        var lb = this.groupBox2.Controls.Find("PL", false).FirstOrDefault(x => x.Tag == ck.Tag);
                        if (lb != null)
                        {
                            var l = lb as Label;
                            list.Add(ck.Tag.ToTryInt(), Convert.ToDecimal(l.Text));
                        }

                    }
                }
            }
            #endregion

            if (list.Count < MinCount)
            {
                MessageEx.ShowWarning("内容不正确,请重新下注");
            }
            else
            {
                Frm.fmConfirmLX fm = new Frm.fmConfirmLX();

                #region 创建订单对象
                string OrderId = Guid.NewGuid().ToString("n");

                //订单主体
                var order = new Order<OrderLXLM>()
                {
                    Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Create_User_Id = "0",
                    Customer_Id = cbox.SelectedValue.ToString().ToTryInt(),
                    Id = OrderId,
                    IsDel = 0,
                    Issue = txtIssue.Text.Trim(),
                    Order_No = ServiceNum.GetOrderNo(),
                    Order_Type = OrderType,
                    Child_Type = ChildType,
                    Update_Time = "",
                    Update_User_Id = ""
                };

                //需要组合的号码
                List<int> InCombinationList = new List<int>();
                foreach (var item in list)
                {
                    InCombinationList.Add(item.Key);
                }

                //生成号码组合
                List<int[]> ListCombination = PermutationAndCombination<int>.GetCombination(InCombinationList.ToArray(), MinCount); //求全部的3-3组合

                //根据号码组合创建订单明细
                int index = 1;
                foreach (int[] arr in ListCombination)
                {
                    OrderLXLM detail = new OrderLXLM();
                    int childIndex = 0;
                    var str = "";
                    foreach (int item in arr)
                    {
                        switch (childIndex)
                        {
                            case 0:
                                detail.Code1 = item.ToString();
                                detail.Zodiac1 = ServiceNum.GetNumZodiac(item);
                                break;
                            case 1:
                                detail.Code2 = item.ToString();
                                detail.Zodiac2 = ServiceNum.GetNumZodiac(item);
                                break;
                            case 2:
                                detail.Code3 = item.ToString();
                                detail.Zodiac3 = ServiceNum.GetNumZodiac(item);
                                break;
                            case 3:
                                detail.Code4 = item.ToString();
                                detail.Zodiac4 = ServiceNum.GetNumZodiac(item);
                                break;
                            case 4:
                                detail.Code5 = item.ToString();
                                detail.Zodiac5 = ServiceNum.GetNumZodiac(item);
                                break;
                        }

                        str += ServiceNum.GetNumZodiac(item) + "、";
                        childIndex = childIndex + 1;
                    }
                    detail.Id = Guid.NewGuid().ToString("n");
                    detail.Sort = index;
                    detail.ChildType = ChildType;
                    detail.Remarks = str.Remove(str.Length - 1, 1);
                    detail.OrderId = OrderId;
                    detail.Odds = GetMinOdds(list, InCombinationList);
                    detail.InMoney = Convert.ToDecimal(txtMoney.Text);
                    detail.OutMoney = detail.InMoney * detail.Odds;
                    detail.Status = (int)ResultStatus.Wait;
                    detail.Flag = 1;
                    order.OrderDetails.Add(detail);
                    index = index + 1;
                }

                order.Total_In_Money = order.OrderDetails.Sum(x => x.InMoney);
                order.Total_Out_Money = 0.00M;
                #endregion

                fm.InitForm(order);

                if (fm.ShowDialog() == DialogResult.OK)
                {
                    OrderImpl service = new OrderImpl();
                    if (service.AddOrderLXLM(order).Code == 0)
                    {
                        MessageEx.Show("下单成功");
                        btnReset_Click(null, null);
                    }
                    else
                    {
                        MessageEx.Show("下单失败");
                    }

                }
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            //txtMoney.Text = "";
            //  cbox.SelectedIndex = 0;
            foreach (var control in this.groupBox2.Controls)
            {
                if (control is CheckBox)
                {
                    var ck = control as CheckBox;
                    if (ck.Checked)
                    {
                        ck.Checked = false;
                    }
                }
            }

        }

        #endregion

        private void cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox.SelectedIndex == 0)
            {
                var controls = this.groupBox1.Controls.Find("PL", false);
                foreach (var control in controls)
                {
                    if (control is Label)
                    {
                        var pl = control as Label;
                        pl.Text = "00.00";
                    }
                }
            }
            else
            {
                var controls = this.groupBox1.Controls.Find("PL", false);
                foreach (var control in controls)
                {
                    if (control is Label)
                    {
                        var pl = control as Label;
                        pl.Text = "1.00";
                    }
                }
            }
        }
    }
}
