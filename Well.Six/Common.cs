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
