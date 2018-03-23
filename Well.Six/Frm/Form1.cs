using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well.Six.Frm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitOptions();
            InitOptions2();
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
                txt.Name = "CK";
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
                txt.Name = "CK";
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

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
