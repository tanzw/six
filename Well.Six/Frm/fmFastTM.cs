﻿using System;
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
        int childType = 0;
        int orderType = 0;
        public fmFastTM(int _ordertype, int _childtype)
        {
            InitializeComponent();
            childType = _childtype;
            orderType = _ordertype;
            if (childType == (int)ChildType.单平)
            {
                this.Text = "单平快捷投注";
            }
            else
            {
                this.Text = "特码快捷投注";
            }
        }
        List<CodeNum> list = Well.Data.ServiceNum.GetNumsArray();
        List<OrderTM> orderDetails = new List<OrderTM>();

        OddsData tm = null;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cbxCustomer.SelectedIndex == 0)
            {
                MessageEx.ShowWarning("请选择客户");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCode.Text) || (list.Count(x => x.Value == txtCode.Text.Trim()) == 0 && list.Count(x => x.Zodiac == txtCode.Text.Trim()) == 0))
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

            if (isUpdate)
            {
                updateModel.Code = txtCode.Text.Trim();
                updateModel.InMoney = Convert.ToDecimal(txtMoney.Text.Trim());
                updateModel.Odds = tm.PL;
                updateModel.OutMoney = tm.PL * updateModel.InMoney;
                listView1.SelectedItems[0].SubItems[1].Text = updateModel.Code;
                listView1.SelectedItems[0].SubItems[2].Text = updateModel.Odds.ToMoney();
                listView1.SelectedItems[0].SubItems[3].Text = updateModel.InMoney.ToString();

            }
            else
            {
                var count = list.Count(x => x.Zodiac == txtCode.Text.Trim());
                if (count != 0)
                {
                    var totalinmoney = Convert.ToDecimal(txtMoney.Text.Trim());

                    var inmoney = totalinmoney / count;

                    list.Where(x => x.Zodiac == txtCode.Text.Trim()).ToList().ForEach(x =>
                    {
                        var item = new ListViewItem();
                        item.UseItemStyleForSubItems = true;
                        item.Font = new Font("宋体", 14);
                        item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
                        item.SubItems.Add(x.Value);
                        item.SubItems.Add(tm.PL.ToMoney());
                        item.SubItems.Add(inmoney.ToMoney());
                        listView1.Items.Insert(0, item);
                        orderDetails.Add(new OrderTM()
                        {
                            Code = x.Value,
                            Id = Guid.NewGuid().ToString("n"),
                            Sort = listView1.Items.Count,
                            ChildType = childType,
                            InMoney = inmoney,
                            Odds = tm.PL,
                            OutMoney = tm.PL * inmoney,
                            Remarks = "",
                            Status = (int)ResultStatus.Wait,
                            Flag = 1
                        });

                    });
                }
                else
                {

                    var item = new ListViewItem();
                    item.UseItemStyleForSubItems = true;
                    item.Font = new Font("宋体", 14);
                    item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
                    item.SubItems.Add(txtCode.Text.Trim());
                    item.SubItems.Add(tm.PL.ToMoney());
                    item.SubItems.Add(txtMoney.Text.Trim());
                    listView1.Items.Insert(0, item);
                    orderDetails.Add(new OrderTM()
                    {
                        Code = txtCode.Text.Trim(),
                        Id = Guid.NewGuid().ToString("n"),
                        Sort = listView1.Items.Count,
                        ChildType = childType,
                        InMoney = Convert.ToDecimal(txtMoney.Text.Trim()),
                        Odds = tm.PL,
                        OutMoney = tm.PL * Convert.ToDecimal(txtMoney.Text.Trim()),
                        Remarks = "",
                        Status = (int)ResultStatus.Wait,
                        Flag = 1
                    });
                }
            }
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
                Sort = textBox1.Text.ToTryInt(),
                Issue = txtIssue.Text.Trim(),
                Order_No = ServiceNum.GetOrderNo(),
                Order_Type = orderType,
                Child_Type = childType,
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
                textBox1.Text = (textBox1.Text.Trim().ToTryInt() + 1).ToString();
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
                if (cbxCustomer.SelectedIndex != 0)
                {
                    OrderImpl orderservice = new OrderImpl();
                    textBox1.Text = orderservice.GetMaxIndex(cbxCustomer.SelectedValue.ToString(), txtIssue.Text.Trim()).Body.ToString();
                }

                OddsImpl oddservice = new OddsImpl();
                var r = oddservice.GetList(cbxCustomer.SelectedValue.ToTryInt());
                tm = r.Body.FirstOrDefault(x => x.ChildType == childType);
                if (tm == null)
                {
                    MessageEx.ShowWarning("未设置客户赔率");
                    tm = new OddsData();
                    tm.CustomerId = cbxCustomer.SelectedValue.ToTryInt();
                    tm.PL = 00.00M;
                    tm.FS = 0M;
                }
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
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                var dd = this.listView1.SelectedIndices;
                if (dd.Count > 0)
                {

                    listView1.Items.RemoveAt(dd[0]);
                }
            }

        }

        bool isUpdate = false;
        OrderTM updateModel = null;
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //listView1.Items.Find();
                var index = this.listView1.SelectedItems[0].SubItems[0].Text.ToTryInt();
                updateModel = orderDetails.FirstOrDefault(x => x.Sort == index);
                txtCode.Text = updateModel.Code;
                txtMoney.Text = updateModel.InMoney.ToString();
                isUpdate = true;
            }
        }

        private void btnSX_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            txtCode.Text = btn.Text;
        }

        private void txtMoney_Enter(object sender, EventArgs e)
        {
            this.txtMoney.SelectAll();
        }
    }
}
