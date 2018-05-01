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
    public partial class fmPTYX : Form
    {
        public fmPTYX()
        {
            InitializeComponent();
            InitOptions();
            InitOptions2();
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
            int InitRX = 400;

            int CurrentX = InitLX;
            int CurrentY = InitY;

            for (int i = 0; i < dic.Count; i++)
            {

                Label lbName = new Label();
                lbName.Text = dic[i + 1];
                lbName.Tag = i + 1;
                lbName.Size = new Size(17, 12);
                lbName.AutoSize = true;
                lbName.Name = "Code";
                lbName.Location = new Point(CurrentX, CurrentY);

                this.tabPage1.Controls.Add(lbName);
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
                    this.tabPage1.Controls.Add(lbCode);
                }

                Label lbPL = new Label();
                lbPL.Text = "00.00";
                lbPL.Tag = lbName.Tag;
                lbPL.Size = new Size(17, 12);
                lbPL.AutoSize = true;
                lbPL.Name = "PL";
                lbPL.Location = new Point(CurrentX + lbName.Width + CodeWidth * 5 + 5 * interval, CurrentY);
                this.tabPage1.Controls.Add(lbPL);

                TextBox txt = new TextBox();
                txt.TabIndex = i + 2;
                txt.Name = "TXT";
                txt.Tag = lbName.Tag;
                txt.Size = new Size(60, 12);
                txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
                //txt.Enter += new System.EventHandler(Common.CheckBox_UpdateColor_Enter);
                //txt.Leave += new System.EventHandler(Common.CheckBox_UpdateColor_Leave);
                txt.Location = new Point(CurrentX + lbName.Width + CodeWidth * 5 + 5 * interval + lbPL.Width, CurrentY - 3);
                this.tabPage1.Controls.Add(txt);

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

        private void InitOptions2()
        {
            // var NumsAllArray = Well.Data.ServiceNum.GetNumArray();

            var NumsAllArray = Well.Data.ServiceNum.GetNumsArray();

            var dic = Well.Data.ServiceNum.GetZodiacArray();
            int interval = 25;
            int InitLX = 17;
            int InitY = 38;
            int InitRX = 400;

            int CurrentX = InitLX;
            int CurrentY = InitY;

            for (int i = 0; i < 10; i++)
            {

                Label lbName = new Label();
                lbName.Text = string.Format("{0}尾", i);
                lbName.Tag = i;
                lbName.Size = new Size(17, 12);
                lbName.AutoSize = true;
                lbName.Name = "Code";
                lbName.Location = new Point(CurrentX, CurrentY);

                this.tabPage2.Controls.Add(lbName);
                var temp = NumsAllArray.Where(x => x.Value.EndsWith(i.ToString())).ToList();
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
                    this.tabPage2.Controls.Add(lbCode);
                }

                Label lbPL = new Label();
                lbPL.Text = "00.00";
                lbPL.Tag = lbName.Tag;
                lbPL.Size = new Size(17, 12);
                lbPL.AutoSize = true;
                lbPL.Name = "PL";
                lbPL.Location = new Point(CurrentX + lbName.Width + CodeWidth * 5 + 5 * interval, CurrentY);
                this.tabPage2.Controls.Add(lbPL);

                TextBox txt = new TextBox();
                txt.TabIndex = i + 2;
                txt.Name = "TXT";
                txt.Tag = lbName.Tag;
                txt.Size = new Size(60, 12);
                txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
                //txt.Enter += new System.EventHandler(Common.CheckBox_UpdateColor_Enter);
                //txt.Leave += new System.EventHandler(Common.CheckBox_UpdateColor_Leave);
                txt.Location = new Point(CurrentX + lbName.Width + CodeWidth * 5 + 5 * interval + lbPL.Width, CurrentY - 3);
                this.tabPage2.Controls.Add(txt);

                var K = i + 1;
                if (K < 5)
                {
                    CurrentX = InitLX;
                    CurrentY = InitY + (interval * K) + lbName.Height * K;
                }
                else
                {
                    CurrentX = InitRX;
                    CurrentY = InitY + (interval * (K - 5) + lbName.Height * (K - 5));
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var controls = this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Find("TXT", false);
            foreach (var c in controls)
            {
                if (c is TextBox)
                {
                    var txt = c as TextBox;
                    txt.Text = "";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var container = this.tabControl1.TabPages[tabControl1.SelectedIndex];
            var controls_txt = container.Controls.Find("TXT", false);

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
            var flag = false;
            foreach (var control in controls_txt)
            {

                if (control is TextBox)
                {
                    var c = control as TextBox;
                    if (!string.IsNullOrWhiteSpace(c.Text))
                    {
                        flag = true;
                    }
                }
            }
            if (flag == false)
            {
                MessageEx.ShowWarning("请输入内容,内容不能为空");
                return;
            }


            #endregion


            var OrderId = Guid.NewGuid().ToString("n");
            var list = new List<OrderTM>();
            var index = 1;
            foreach (var control in controls_txt)
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
                        O.Flag = 1;

                        O.Sort = index;

                        var Code = container.Controls.Find("Code", false).FirstOrDefault(x => x.Tag == c.Tag);
                        if (Code != null)
                        {
                            var lbCode = Code as Label;
                            O.Code = lbCode.Text;
                            O.Remarks = lbCode.Text;
                        }
                        else
                        {
                            continue;
                        }

                        var PL = container.Controls.Find("PL", false).FirstOrDefault(x => x.Tag == c.Tag);
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
                        index = index + 1;
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
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.平特,
                Child_Type = (int)ChildType.平特,
                Total_In_Money = list.Sum(x => x.InMoney),
                Total_Out_Money = 0,
                Update_Time = "",
                Update_User_Id = "",
                OrderDetails = list
            };
            fmConfirmOther fm = new fmConfirmOther();
            fm.InitForm(order);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                OrderImpl services = new OrderImpl();
                if (services.AddOrderTM(order).Code == 0)
                {
                    MessageEx.Show("成功");
                    btnReset_Click(sender, e);
                }
                else
                {
                    MessageEx.ShowWarning("失败");
                }
            }
        }

        private void btnOK_ws_Click(object sender, EventArgs e)
        {
            var container = this.tabControl1.TabPages[tabControl1.SelectedIndex];
            var controls_txt = container.Controls.Find("TXT", false);

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
            var flag = false;
            foreach (var control in controls_txt)
            {

                if (control is TextBox)
                {
                    var c = control as TextBox;
                    if (!string.IsNullOrWhiteSpace(c.Text))
                    {
                        flag = true;
                    }
                }
            }
            if (flag == false)
            {
                MessageEx.ShowWarning("请输入内容,内容不能为空");
                return;
            }


            #endregion


            var OrderId = Guid.NewGuid().ToString("n");
            var list = new List<OrderTM>();
            var index = 1;
            foreach (var control in controls_txt)
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
                        O.Sort = index;
                        var Code = container.Controls.Find("Code", false).FirstOrDefault(x => x.Tag == c.Tag);
                        if (Code != null)
                        {
                            var lbCode = Code as Label;
                            O.Code = lbCode.Tag.ToString();
                            O.Remarks = O.Code;
                        }
                        else
                        {
                            continue;
                        }

                        var PL = container.Controls.Find("PL", false).FirstOrDefault(x => x.Tag == c.Tag);
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
                        index = index + 1;
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
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.尾数,
                Child_Type = (int)ChildType.尾数,
                Total_In_Money = list.Sum(x => x.InMoney),
                Total_Out_Money = 0,
                Update_Time = "",
                Update_User_Id = "",
                OrderDetails = list
            };

            OrderImpl services = new OrderImpl();
            if (services.AddOrderTM(order).Code == 0)
            {
                MessageEx.Show("成功");
                btnReset_Click(sender, e);
            }
            else
            {
                MessageEx.ShowWarning("失败");
            }
        }


        private void fmPTYX_Load(object sender, EventArgs e)
        {
            Common.BindCustomers(this.cbox, (sender1, e1) =>
            {

                var controls_pytx = this.tabPage1.Controls.Find("PL", false);
                var controls_ws = this.tabPage2.Controls.Find("PL", false);
                if (this.cbox.SelectedIndex == 0)
                {
                    foreach (var control in controls_pytx)
                    {
                        if (control is Label)
                        {
                            var t = control as Label;
                            t.Text = "00.00";
                        }
                    }

                    foreach (var control in controls_ws)
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
                    var oddsList_pyyx = r.Body.FirstOrDefault(x => x.OrderType == (int)ChildType.平特);
                    var ptyx = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(oddsList_pyyx.strJson);
                    Common.CustomerId = cbox.SelectedValue.ToTryInt();
                    foreach (var control in controls_pytx)
                    {
                        if (control is Label)
                        {
                            var t = control as Label;
                            t.Text = ptyx.List.FirstOrDefault(x => x.Key == t.Tag.ToTryInt()).Value.ToMoney();

                        }
                    }


                    var oddsList_ws = r.Body.FirstOrDefault(x => x.OrderType == (int)OrderType.尾数);
                    if (oddsList_ws != null)
                    {
                        var ws = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(oddsList_ws.strJson);
                        foreach (var control in controls_ws)
                        {
                            if (control is Label)
                            {
                                var t = control as Label;
                                t.Text = ws.List.FirstOrDefault(x => x.Key == t.Tag.ToTryInt()).Value.ToMoney();

                            }
                        }
                    }
                }


            });
        }


        private void btnReset_ws_Click(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
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
                        switch (this.tabControl1.SelectedIndex)
                        {
                            case 0:
                                btnOK_Click(null, null);
                                break;
                            case 1:
                                btnOK_ws_Click(null, null);
                                break;
                        }

                        break;
                }
            }
            return false;
        }
    }
}
