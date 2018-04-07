using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Data;

namespace Well.Six
{
    public class Common
    {

        public static int CustomerId = 0;

        public static void TextBox_FilterString_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }


        public static void CheckBox_UpdateColor_Enter(object sender, EventArgs e)
        {
            CheckBox ck = sender as CheckBox;
            ck.BackColor = System.Drawing.Color.Cyan;
        }
        public static void CheckBox_UpdateColor_Leave(object sender, EventArgs e)
        {
            CheckBox ck = sender as CheckBox;
            ck.BackColor = System.Drawing.SystemColors.Control;
        }

        public static void BindCustomers(ComboBox comBox)
        {
            comBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CustomerImpl services = new CustomerImpl();
            var result = services.GetList(new Model.Customers() { IsDel = 0 });

            if (result.Code == 0)
            {
                result.Body.Insert(0, new Model.Customers() { Id = 0, Name = "请选择客户" });
                comBox.DataSource = result.Body;
                comBox.DisplayMember = "Name";
                comBox.ValueMember = "Id";

            }
        }


        public static void BindOrderType(ComboBox comBox)
        {
            comBox.DropDownStyle = ComboBoxStyle.DropDownList;
            List<dynamic> list = new List<dynamic>();
            list.Add(new { Name = "请选择", Id = 0 });
            list.Add(new { Name = "特码", Id = 1 });
            list.Add(new { Name = "连肖", Id = 10 });
            list.Add(new { Name = "连码", Id = 20 });
            list.Add(new { Name = "平特一肖", Id = 30 });
            list.Add(new { Name = "尾数", Id = 40 });
            comBox.DataSource = list;
            comBox.DisplayMember = "Name";
            comBox.ValueMember = "Id";
        }

        public static void BindChildType(ComboBox comBox)
        {
            comBox.DropDownStyle = ComboBoxStyle.DropDownList;
            List<dynamic> list = new List<dynamic>();
            list.Add(new { Name = "请选择", Id = 0 });
            list.Add(new { Name = "特码", Id = 1 });
            list.Add(new { Name = "特码连肖", Id = 10 });
            list.Add(new { Name = "连码", Id = 20 });
            list.Add(new { Name = "平特一肖", Id = 30 });
            list.Add(new { Name = "尾数", Id = 40 });
            comBox.DataSource = list;
            comBox.DisplayMember = "Name";
            comBox.ValueMember = "Id";
        }


        public static void BindCustomers(ComboBox comBox, Action<object, EventArgs> ac)
        {
            BindCustomers(comBox);
            comBox.SelectedIndexChanged += new EventHandler(ac);

            comBox.SelectedValue = Common.CustomerId;
        }

        public static void BindLXType(ComboBox comBox, Action<object, EventArgs> ac)
        {
            comBox.DropDownStyle = ComboBoxStyle.DropDownList;

            List<dynamic> list = new List<dynamic>();
            list.Add(new { Name = "请选择类型", Id = 0 });
            list.Add(new { Name = "二连肖", Id = 22 });
            list.Add(new { Name = "三连肖", Id = 23 });
            list.Add(new { Name = "四连肖", Id = 24 });
            list.Add(new { Name = "五连肖", Id = 25 });

            comBox.DataSource = list;
            comBox.DisplayMember = "Name";
            comBox.ValueMember = "Id";

            comBox.SelectedIndexChanged += new EventHandler(ac);
        }


        public static void MessageBoxShow(string text, MessageBoxIcon icon)
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, icon);
        }
    }


    public class MessageEx
    {
        public static void Show(string text)
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static void ShowWarning(string text)
        {
            MessageBox.Show(text, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string text)
        {
            MessageBox.Show(text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}