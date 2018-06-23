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

namespace Well.Six.Frm
{
    public partial class fmOrderDetails : Form
    {
        OrderImpl service = new OrderImpl();
        public fmOrderDetails()
        {
            InitializeComponent();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Scrollable = true;
            listView1.MultiSelect = false;
        }

        public void SetData(string id)
        {
            listView1.Items.Clear();

            var result = service.GetModel(id);
            if (result.Body != null)
            {
                lbCount.Text = "0";
                lbCustomerName.Text = result.Body.CustomerName;
                lbMoney.Text = result.Body.Total_In_Money.ToString();
                lbType.Text = result.Body.ChildTypeName;

                if (result.Body.OrderType == (int)OrderType.特码 || result.Body.OrderType == (int)OrderType.尾数 || result.Body.OrderType == (int)OrderType.平特 || result.Body.OrderType == (int)OrderType.尾数 || result.Body.OrderType == (int)OrderType.波色 || result.Body.OrderType == (int)OrderType.大小单双 || result.Body.OrderType == (int)OrderType.合肖 || result.Body.OrderType == (int)OrderType.单平 || result.Body.OrderType == (int)OrderType.全不中)
                {
                    var TMlList = service.GetOrderTMList(id);
                    lbCount.Text = TMlList.Body.Count.ToString();

                    if (result.Body.OrderType == (int)OrderType.波色 || result.Body.OrderType == (int)OrderType.大小单双)
                    {
                        TMlList.Body.ForEach(x =>
                        {
                            var item = new ListViewItem();
                            item.UseItemStyleForSubItems = true;
                            if (x.Status == (int)ResultStatus.Win)
                            {
                                item.BackColor = Color.Red;
                                item.ForeColor = Color.White;
                            }
                            item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
                            item.SubItems.Add(x.Sort.ToString());
                            var sd = (ChildType)x.ChildType;
                            var sd1 = (OrderType)result.Body.OrderType;
                            item.SubItems.Add(sd1.ToString());
                            item.SubItems.Add(sd.ToString());
                            item.SubItems.Add(x.Odds.ToString());
                            item.SubItems.Add(x.InMoney.ToString());
                            listView1.Items.Add(item);
                        });
                    }
                    else
                    {
                        TMlList.Body.ForEach(x =>
                        {
                            var item = new ListViewItem();
                            item.UseItemStyleForSubItems = true;
                            item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
                            if (x.Status == (int)ResultStatus.Win)
                            {
                                item.BackColor = Color.Red;
                                item.ForeColor = Color.White;
                            }
                            item.SubItems.Add(x.Sort.ToString());
                            var sd = (ChildType)x.ChildType;
                            item.SubItems.Add(sd.ToString());
                            item.SubItems.Add(x.Code.ToString());
                            item.SubItems.Add(x.Odds.ToString());
                            item.SubItems.Add(x.InMoney.ToString());
                            listView1.Items.Add(item);
                        });
                    }

                }
                else if (result.Body.OrderType == (int)OrderType.连肖 || result.Body.OrderType == (int)OrderType.连码)
                {
                    var LXLMlList = service.GetOrderLXLMList(id);
                    lbCount.Text = LXLMlList.Body.Count.ToString();

                    LXLMlList.Body.ForEach(x =>
                    {
                        var item = new ListViewItem();
                        item.UseItemStyleForSubItems = true;
                        if (x.Status == (int)ResultStatus.Win)
                        {
                            item.BackColor = Color.Red;
                            item.ForeColor = Color.White;
                        }
                        item.SubItems[0].Text = (listView1.Items.Count + 1).ToString();
                        item.SubItems.Add(x.Sort.ToString());
                        var str = "";
                        if (x.Remarks == null)
                        {
                            if (!string.IsNullOrWhiteSpace(x.Zodiac1))
                            {
                                str += x.Zodiac1;
                            }
                            if (!string.IsNullOrWhiteSpace(x.Zodiac2))
                            {
                                str += "、" + x.Zodiac2;
                            }
                            if (!string.IsNullOrWhiteSpace(x.Zodiac3))
                            {
                                str += "、" + x.Zodiac3;
                            }
                            if (!string.IsNullOrWhiteSpace(x.Zodiac4))
                            {
                                str += "、" + x.Zodiac4;
                            }
                            if (!string.IsNullOrWhiteSpace(x.Zodiac5))
                            {
                                str += "、" + x.Zodiac5;
                            }
                        }
                        else
                        {
                            str = x.Remarks;
                        }
                        var sd = (ChildType)x.ChildType;
                        item.SubItems.Add(sd.ToString());

                        item.SubItems.Add(str);
                        item.SubItems.Add(x.Odds.ToString());
                        item.SubItems.Add(x.InMoney.ToString());
                        listView1.Items.Add(item);
                    });


                }
            }
        }
    }
}
