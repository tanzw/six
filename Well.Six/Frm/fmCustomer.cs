using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Common.Extensions;
using Well.Common.Result;
using Well.Model;
using Well.Data;

namespace Well.Six.Frm
{
    public partial class fmCustomer : Form
    {
        int CustomerId = 0;
        CustomerImpl service = new CustomerImpl();



        public fmCustomer()
        {
            InitializeComponent();
        }


        private void LoadList()
        {
            listView1.Items.Clear();
            var result = service.GetList(new Customers() { IsDel = 0 });
            if (result.Code == 0)
            {
                listView1.GridLines = true;
                listView1.FullRowSelect = true;
                listView1.View = View.Details;
                listView1.Scrollable = true;
                listView1.MultiSelect = false;
                result.Body.ForEach(x =>
                {
                    var item = new ListViewItem();
                    item.UseItemStyleForSubItems = false;
                    item.SubItems[0].Text = "0";
                    //item.SubItems[0].ForeColor = defaultForeColor;
                    //item.SubItems[0].Font = font;
                    item.SubItems.Add(x.Id.ToString());
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.Phone);
                    item.SubItems.Add(x.Remarks);
                    listView1.Items.Add(item);
                });
            }
        }
        private void fmCustomer_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fmCustomerEdit fm = new fmCustomerEdit();
            fm.ShowInTaskbar = false;
            fm.MinimizeBox = false;
            fm.MaximizeBox = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                CustomerId = listView1.SelectedItems[0].SubItems[1].Text.ToTryInt();
                fmCustomerEdit fm = new fmCustomerEdit(CustomerId);
                fm.ShowInTaskbar = false;
                fm.MinimizeBox = false;
                fm.MaximizeBox = false;
                fm.StartPosition = FormStartPosition.CenterParent;
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    LoadList();
                }
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                CustomerId = listView1.SelectedItems[0].SubItems[1].Text.ToTryInt();
                if (MessageBox.Show("确定删除?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (service.LogicDel(new Customers() { Id = CustomerId }).Code == 0)
                    {
                        LoadList();
                    }
                    else
                    {
                        MessageBox.Show("删除失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                CustomerId = listView1.SelectedItems[0].SubItems[1].Text.ToTryInt();
                fmOdds fm = new fmOdds(CustomerId);
                fm.ShowInTaskbar = false;
                fm.MinimizeBox = false;
                fm.MaximizeBox = false;
                fm.StartPosition = FormStartPosition.CenterParent;
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    LoadList();
                }
            }
        }
    }
}
