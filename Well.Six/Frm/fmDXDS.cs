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
using Well.Data;
using Well.Model;
using Well.Six;

namespace Well.Six.Frm
{
    public partial class fmDXDS : Form
    {
        public fmDXDS()
        {
            InitializeComponent();


            txthd.Tag = (int)ChildType.合单;
            txths.Tag = (int)ChildType.合双;
            txthda.Tag = (int)ChildType.合大;
            txthx.Tag = (int)ChildType.合小;
            txthxd.Tag = (int)ChildType.合小单;
            txthxs.Tag = (int)ChildType.合小双;
            txthdd.Tag = (int)ChildType.合大单;
            txthds.Tag = (int)ChildType.合大双;


            txttd.Tag = (int)ChildType.特单;
            txtts.Tag = (int)ChildType.特双;
            txttda.Tag = (int)ChildType.特大;
            txttx.Tag = (int)ChildType.特小;
            txttxd.Tag = (int)ChildType.特小单;
            txttxs.Tag = (int)ChildType.特小双;
            txttdd.Tag = (int)ChildType.特大单;
            txttds.Tag = (int)ChildType.特大双;




            lbhd.Tag = txthd.Tag;
            lbhs.Tag = txths.Tag;
            lbhda.Tag = txthda.Tag;
            lbhx.Tag = txthx.Tag;
            lbhxd.Tag = txthxd.Tag;
            lbhxs.Tag = txthxs.Tag;
            lbhdd.Tag = txthdd.Tag;
            lbhds.Tag = txthds.Tag;

            lbtd.Tag = txttd.Tag;
            lbts.Tag = txtts.Tag;
            lbtda.Tag = txttda.Tag;
            lbtx.Tag = txttx.Tag;
            lbtxd.Tag = txttxd.Tag;
            lbtxs.Tag = txttxs.Tag;
            lbtdd.Tag = txttdd.Tag;
            lbtds.Tag = txttds.Tag;

            lbNamehd.Tag = txthd.Tag;
            lbNamehs.Tag = txths.Tag;
            lbNamehda.Tag = txthda.Tag;
            lbNamehx.Tag = txthx.Tag;
            lbNamehxd.Tag = txthxd.Tag;
            lbNamehxs.Tag = txthxs.Tag;
            lbNamehdd.Tag = txthdd.Tag;
            lbNamehds.Tag = txthds.Tag;

            lbNametd.Tag = txttd.Tag;
            lbNamets.Tag = txtts.Tag;
            lbNametda.Tag = txttda.Tag;
            lbNametx.Tag = txttx.Tag;
            lbNametxd.Tag = txttxd.Tag;
            lbNametxs.Tag = txttxs.Tag;
            lbNametdd.Tag = txttdd.Tag;
            lbNametds.Tag = txttds.Tag;



            txthd.Name = "txt";
            txths.Name = "txt";
            txthda.Name = "txt";
            txthx.Name = "txt";
            txthxd.Name = "txt";
            txthxs.Name = "txt";
            txthdd.Name = "txt";
            txthds.Name = "txt";

            txttd.Name = "txt";
            txtts.Name = "txt";
            txttda.Name = "txt";
            txttx.Name = "txt";
            txttxd.Name = "txt";
            txttxs.Name = "txt";
            txttdd.Name = "txt";
            txttds.Name = "txt";


            lbhd.Name = "pl";
            lbhs.Name = "pl";
            lbhda.Name = "pl";
            lbhx.Name = "pl";
            lbhxd.Name = "pl";
            lbhxs.Name = "pl";
            lbhdd.Name = "pl";
            lbhds.Name = "pl";

            lbtd.Name = "pl";
            lbts.Name = "pl";
            lbtda.Name = "pl";
            lbtx.Name = "pl";
            lbtxd.Name = "pl";
            lbtxs.Name = "pl";
            lbtdd.Name = "pl";
            lbtds.Name = "pl";


            lbNamehd.Name = "code";
            lbNamehs.Name = "code";
            lbNamehda.Name = "code";
            lbNamehx.Name = "code";
            lbNamehxd.Name = "code";
            lbNamehxs.Name = "code";
            lbNamehdd.Name = "code";
            lbNamehds.Name = "code";


            lbNametd.Name = "code";
            lbNamets.Name = "code";
            lbNametda.Name = "code";
            lbNametx.Name = "code";
            lbNametxd.Name = "code";
            lbNametxs.Name = "code";
            lbNametdd.Name = "code";
            lbNametds.Name = "code";


            txthd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txths.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txthda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txthx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txthxd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txthxs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txthdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txthds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);


            txttd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txtts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txttda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txttx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txttxd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txttxs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txttdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);
            txttds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Common.TextBox_FilterString_KeyPress);


        }

        private void InitControls()
        {
            var result = ServiceNum.GetColorArray();

            var red = Color.Red;
            var blue = Color.Blue;
            var green = Color.LimeGreen;
            result.Remove(49);

            #region 特大

            var list = result.Where(x => x.Key > 24);
            var xInn = 23;
            int index = 0;
            foreach (var item in list)
            {

                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 26);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }

            #endregion

            #region 特小

            list = result.Where(x => x.Key < 25);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 48);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }

            #endregion

            #region 特单

            list = result.Where(x => x.Key % 2 != 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 70);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region  特双
            list = result.Where(x => x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 92);
                //lb.Location = new Point(448 + xInn * index, 26);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 特大单
            list = result.Where(x => x.Key > 24 && x.Key % 2 != 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 114);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region  特小单
            list = result.Where(x => x.Key <= 24 && x.Key % 2 != 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 136);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region  特大双
            list = result.Where(x => x.Key > 24 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 158);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }
            #endregion


            #region  特小双
            list = result.Where(x => x.Key <= 24 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 180);
                this.groupBox2.Controls.Add(lb);
                index = index + 1;
            }
            #endregion



            #region 合大


            list = result;
            var num = 0;
            var sum = 0;
            index = 0;
            var hxIndex = 0;
            var hdIndex = 0;
            var hsIndex = 0;
            var hddIndex = 0;
            var hxdIndex = 0;
            var hdsIndex = 0;
            var hxsIndex = 0;

            for (int i = 1; i <= 48; i++)
            {
                num = i;
                while (num > 0)
                {
                    sum += num % 10;//每次的余数都是末尾的数字
                    num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                }

                if (sum > 6)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * index, 26);
                    this.groupBox3.Controls.Add(lb);
                    index = index + 1;
                }
                if (sum <= 6)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hxIndex, 48);
                    this.groupBox3.Controls.Add(lb);
                    hxIndex = hxIndex + 1;
                }
                if (sum % 2 != 0)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hdIndex, 70);
                    this.groupBox3.Controls.Add(lb);
                    hdIndex = hdIndex + 1;
                }
                if (sum % 2 == 0)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hsIndex, 92);
                    this.groupBox3.Controls.Add(lb);
                    hsIndex = hsIndex + 1;
                }

                if (sum > 6 && sum % 2 != 0)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hddIndex, 114);
                    this.groupBox3.Controls.Add(lb);
                    hddIndex = hddIndex + 1;
                }
                else if (sum > 6 && sum % 2 == 0)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hdsIndex, 136);
                    this.groupBox3.Controls.Add(lb);
                    hdsIndex = hdsIndex + 1;
                }
                else if (sum <= 6 && sum % 2 != 0)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hxdIndex, 158);
                    this.groupBox3.Controls.Add(lb);
                    hxdIndex = hxdIndex + 1;
                }
                else if (sum <= 6 && sum % 2 == 0)
                {
                    Label lb = new Label();
                    lb.Text = i.ToString().PadLeft(2, '0');
                    lb.BackColor = list.FirstOrDefault(x => x.Key == i).Value;
                    lb.Width = 19;
                    lb.Height = 12;
                    lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    lb.Location = new Point(151 + xInn * hxsIndex, 180);
                    this.groupBox3.Controls.Add(lb);
                    hxsIndex = hxsIndex + 1;
                }
                sum = 0;
                num = 0;
            }

            index = 0;

            #endregion
        }


        private void fmDXDS_Load(object sender, EventArgs e)
        {
            InitControls();
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
                    var r = oddservice.GetList(cbox.SelectedValue.ToTryInt());
                    var oddsList = r.Body.FirstOrDefault(x => x.OrderType == (int)OrderType.大小单双);
                    if (oddsList != null)
                    {
                        var tm = Newtonsoft.Json.JsonConvert.DeserializeObject<BSOdds>(oddsList.strJson);


                        tm.List.ToList().ForEach(x =>
                        {
                            switch (x.Key)
                            {
                                #region 特大单双
                                case (int)ChildType.特单:
                                    lbtd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特双:
                                    lbts.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特大:
                                    lbtda.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特小:
                                    lbtx.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特大单:
                                    lbtdd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特大双:
                                    lbtds.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特小单:
                                    lbtxd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.特小双:
                                    lbtxs.Text = x.Value.ToString();
                                    break;

                                #endregion

                                #region  合大小单双

                                case (int)ChildType.合单:
                                    lbhd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合双:
                                    lbhs.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合大:
                                    lbhda.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合小:
                                    lbhx.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合大单:
                                    lbhdd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合大双:
                                    lbhds.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合小单:
                                    lbhxd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.合小双:
                                    lbhxs.Text = x.Value.ToString();
                                    break;

                                    #endregion
                            }

                        });
                        Common.CustomerId = cbox.SelectedValue.ToTryInt();
                    }
                }
            });
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string OrderId = Guid.NewGuid().ToString("n");

            #region  检测输入
            bool flag = false;
            var controls1 = this.Controls.Find("txt", true);
            foreach (var c in controls1)
            {
                if (c is TextBox)
                {
                    var cc = c as TextBox;
                    if (!string.IsNullOrWhiteSpace(cc.Text))
                    {
                        flag = true;
                    }

                }
            }


            if (!flag)
            {
                MessageEx.ShowWarning("请输入号码的金额");
                return;
            }

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
            #endregion


            var list = new List<OrderTM>();
            var index = 0;
            foreach (var c in controls1)
            {
                if (c is TextBox)
                {
                    var cc = c as TextBox;
                    if (!string.IsNullOrWhiteSpace(cc.Text))
                    {
                        OrderTM O = new OrderTM();
                        O.Id = Guid.NewGuid().ToString("N");
                        O.OrderId = OrderId;
                        O.InMoney = Convert.ToDecimal(cc.Text);
                        O.Flag = 1;
                        O.ChildType = int.Parse(cc.Tag.ToString());
                        O.Status = (int)ResultStatus.Wait;

                        var Code = this.Controls.Find("code", true).FirstOrDefault(x => x.Tag == c.Tag);
                        if (Code != null)
                        {
                            var lbCode = Code as Label;
                            O.Code = lbCode.Tag.ToString();
                            index = index + 1;
                        }
                        else
                        {
                            continue;
                        }
                        O.Remarks = Code.Text;
                        O.Sort = index;
                        var PL = this.Controls.Find("pl", true).FirstOrDefault(x => x.Tag == c.Tag);
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

            Order<OrderTM> order = new Order<OrderTM>()
            {
                Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Create_User_Id = "0",
                Customer_Id = cbox.SelectedValue.ToString().ToTryInt(),
                Id = OrderId,
                IsDel = 0,
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = (int)OrderType.大小单双,
                Total_In_Money = list.Sum(x => x.InMoney),
                Total_Out_Money = 0,
                Update_Time = "",
                Update_User_Id = "",
                OrderDetails = list
            };

            Frm.fmConfirmOther fmConfigm = new fmConfirmOther();
            fmConfigm.InitForm(order);
            if (fmConfigm.ShowDialog() == DialogResult.OK)
            {
                OrderImpl services = new OrderImpl();
                if (services.AddOrderTM(order).Code == 0)
                {
                    MessageBox.Show("成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    btnReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var controls1 = this.Controls.Find("txt", true);
            foreach (var c in controls1)
            {
                if (c is TextBox)
                {
                    var cc = c as TextBox;
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
    }
}
