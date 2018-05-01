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
    public partial class fmLM : Form
    {
        public fmLM()
        {
            InitializeComponent();
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

                CheckBox ck = new CheckBox();
                ck.AutoSize = true;
                ck.TabIndex = i;
                ck.Name = "CK";
                ck.Tag = lbNum.Tag;
                ck.Enter += new System.EventHandler(Common.CheckBox_UpdateColor_Enter);
                ck.Leave += new System.EventHandler(Common.CheckBox_UpdateColor_Leave);



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
                PointX = PointX + 100 * (currentColumn - 1);
                lbNum.Location = new Point(PointX, PointY);
                ck.Location = new Point(PointX + 45, PointY + 4);
                PointY = PointY + interval + lbNum.Height;

                this.groupBox3.Controls.Add(lbNum);


                this.groupBox3.Controls.Add(ck);

            }

        }

        private void fmLM_Load(object sender, EventArgs e)
        {
            this.txtMoney.KeyPress += new KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);

            InitOption();

            Common.BindCustomers(this.cbox, (sender1, e1) =>
            {
                var controls = this.groupBox2.Controls.Find("PL", false);

                if (this.cbox.SelectedIndex == 0)
                {
                    lbEZE.Text = "0";
                    lbTP.Text = "0";
                    lbSQZ.Text = "0";
                    lbSZE.Text = "0";
                    lbSZS.Text = "0";
                }
                else
                {
                    OddsImpl oddservice = new OddsImpl();
                    var r = oddservice.GetList(cbox.SelectedValue.ToTryInt());
                    var oddsList = r.Body.FirstOrDefault(x => x.OrderType == (int)OrderType.连码);
                    var ptyx = Newtonsoft.Json.JsonConvert.DeserializeObject<LMOdds>(oddsList.strJson);
                    Common.CustomerId = cbox.SelectedValue.ToTryInt();
                    lbEZE.Text = ptyx.EQZ.ToString();
                    lbTP.Text = ptyx.TP.ToString();
                    lbSQZ.Text = ptyx.SQZ.ToString();
                    lbSZE.Text = ptyx.SZE.ToString();
                    lbSZS.Text = ptyx.SZS.ToString();
                }
            });

            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var v = 0;
            var childtype = 0;
            var pl = 0M;

            if (radioButton5.Checked)
            {
                v = 3;
                childtype = (int)ChildType.三中三;
                pl = Convert.ToDecimal(lbSZS.Text);
            }
            if (radioButton6.Checked)
            {
                v = 3;
                childtype = (int)ChildType.三全中;
                pl = Convert.ToDecimal(lbSQZ.Text);
            }
            if (radioButton7.Checked)
            {
                v = 2;
                childtype = (int)ChildType.二全中;
                pl = Convert.ToDecimal(lbEZE.Text);
            }
            if (radioButton8.Checked)
            {
                v = 2;
                childtype = (int)ChildType.特碰;
                pl = Convert.ToDecimal(lbTP.Text);
            }

            //需要组合的号码
            List<string> InCombinationList = new List<string>();
            #region  获取输入
            var controls = this.groupBox3.Controls.Find("CK", false);
            var r = 0;
            foreach (var control in controls)
            {
                if (control is CheckBox)
                {
                    var ck = control as CheckBox;
                    if (ck.Checked)
                    {
                        r += 1;
                        var sd = this.groupBox3.Controls.Find("Code", false);
                        var lb = sd.FirstOrDefault(x => x.Tag == ck.Tag);
                        if (lb != null)
                        {
                            var lbCode = lb as Label;
                            InCombinationList.Add(lbCode.Text);
                        }

                    }
                }
            }
            #endregion

            #region 检测输入

            if (!radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked && !radioButton8.Checked)
            {
                MessageEx.ShowWarning("请选择连码类型");
                return;
            }

            if (cbox.SelectedIndex == 0)
            {
                MessageEx.ShowWarning("请选择客户");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                MessageEx.ShowWarning("请输入金额");
                return;
            }

            if (r < v)
            {
                MessageEx.ShowWarning("内容不正确,请重新选择");
                return;
            }

            #endregion



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
                Order_Type = (int)OrderType.连码,
                Child_Type = childtype,
                Update_Time = "",
                Update_User_Id = ""
            };

            //生成号码组合
            List<string[]> ListCombination = PermutationAndCombination<string>.GetCombination(InCombinationList.ToArray(), v); //求全部的3-3组合

            //根据号码组合创建订单明细
            int index = 1;
            foreach (string[] arr in ListCombination)
            {
                OrderLXLM detail = new OrderLXLM();
                int childIndex = 0;
                var str = "";
                foreach (string item in arr)
                {
                    switch (childIndex)
                    {
                        case 0:
                            detail.Code1 = item.ToString();
                            break;
                        case 1:
                            detail.Code2 = item.ToString();
                            break;
                        case 2:
                            detail.Code3 = item.ToString();
                            break;
                        case 3:
                            detail.Code4 = item.ToString();
                            break;
                    }

                    str += item + "、";
                    childIndex = childIndex + 1;
                }
                detail.Id = Guid.NewGuid().ToString("n");
                detail.Sort = index;
                detail.Remarks = str.Remove(str.Length - 1, 1);
                detail.OrderId = OrderId;
                detail.Odds = pl;
                detail.ChildType = childtype;
                detail.InMoney = Convert.ToDecimal(txtMoney.Text);
                detail.OutMoney = detail.InMoney * detail.Odds;
                if (childtype == (int)ChildType.三中三)
                {
                    detail.MinOdds = Convert.ToDecimal(lbSZE.Text);
                    detail.MinOutMoney = detail.InMoney * detail.MinOdds;
                    detail.MaxOdds = pl;
                    detail.MaxOutMoney = detail.InMoney * detail.MaxOdds;
                }
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


        private void btnReset_Click(object sender, EventArgs e)
        {
            var controls = this.groupBox3.Controls.Find("CK", false);
            foreach (var control in controls)
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
