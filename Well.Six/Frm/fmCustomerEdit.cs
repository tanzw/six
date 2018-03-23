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
    public partial class fmCustomerEdit : Form
    {
        #region 成员
        int CustomerId = 0;
        CustomerImpl service = new CustomerImpl();
        #endregion

        #region 委托
        //声明委托
        public delegate void QueryList();
        //定义委托事件
        public event QueryList OnQueryListHandler = null;
        #endregion

        public fmCustomerEdit()
        {
            InitializeComponent();
        }

        public fmCustomerEdit(int id)
        {
            InitializeComponent();
            CustomerId = id;
        }

        private void fmCustomerEdit_Load(object sender, EventArgs e)
        {
            if (CustomerId != 0)
            {
                var result = service.GetModel(new Customers() { Id = CustomerId });
                if (result.Body != null)
                {
                    txtName.Text = result.Body.Name;
                    txtPhone.Text = result.Body.Phone;
                    txtRemarks.Text = result.Body.Remarks;
                }
                else
                {
                    MessageBox.Show("数据不存在", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CustomerId != 0)
            {
                var result = service.Update(new Customers()
                {
                    Id = CustomerId,
                    IsDel = 0,
                    Name = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Remarks = txtRemarks.Text
                });
                if (result.Code == 0)
                {
                    MessageBox.Show("更新客户信息成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("更新客户信息失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var result = service.Add(new Customers()
                {
                    IsDel = 0,
                    Name = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Remarks = txtRemarks.Text
                });
                if (result.Code == 0)
                {
                    MessageBox.Show("新增客户信息成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("新增客户信息失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }


    }
}
