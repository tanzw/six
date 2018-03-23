using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Data;

namespace Well.Six.UControls
{
    public partial class ULM : UserControl
    {
        public ULM()
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
                PointX = PointX + 200 * (currentColumn - 1);


                lbNum.Location = new Point(PointX, PointY);

                ck.Location = new Point(PointX + 45, PointY + 4);
                PointY = PointY + interval + lbNum.Height;

                this.Controls.Add(lbNum);


                this.Controls.Add(ck);

            }

        }
    }
}
