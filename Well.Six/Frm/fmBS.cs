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

namespace Well.Six.Frm
{
    public partial class fmBS : Form
    {
        public fmBS()
        {
            InitializeComponent();
        }


        private void InitControls()
        {
            var result = ServiceNum.GetColorArray();

            var red = Color.Red;
            var blue = Color.Blue;
            var green = Color.LimeGreen;

            #region 红波

            var list = result.Where(x => x.Value == red);
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

            #region 蓝波

            list = result.Where(x => x.Value == blue);
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

            #region 绿波

            list = result.Where(x => x.Value == green);
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

            #region 半波--红大
            list = result.Where(x => x.Value == red && x.Key > 25);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 26);
                //lb.Location = new Point(448 + xInn * index, 26);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--红小
            list = result.Where(x => x.Value == red && x.Key <= 25);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 26);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--红单
            list = result.Where(x => x.Value == red && x.Key % 2 != 0);
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
                //lb.Location = new Point(448 + xInn * index, 26);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--红双
            list = result.Where(x => x.Value == red && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 48);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion


            #region 半波--蓝大
            list = result.Where(x => x.Value == blue && x.Key > 25);
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
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--蓝小
            list = result.Where(x => x.Value == blue && x.Key <= 25);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 70);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--蓝单
            list = result.Where(x => x.Value == blue && x.Key % 2 != 0);
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
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--蓝双
            list = result.Where(x => x.Value == blue && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 92);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--绿大
            list = result.Where(x => x.Value == green && x.Key > 25);
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
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--绿小
            list = result.Where(x => x.Value == green && x.Key <= 25);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 114);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--绿单
            list = result.Where(x => x.Value == green && x.Key % 2 != 0);
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
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半波--绿双
            list = result.Where(x => x.Value == green && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 136);
                this.groupBox3.Controls.Add(lb);
                index = index + 1;
            }
            #endregion


            #region 半半波--红大单
            list = result.Where(x => x.Value == red && x.Key > 25 && x.Key % 2 != 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(151 + xInn * index, 26);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--红大双
            list = result.Where(x => x.Value == red && x.Key > 25 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 26);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--红小单
            list = result.Where(x => x.Value == red && x.Key <= 25 && x.Key % 2 != 0);
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
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--红小双
            list = result.Where(x => x.Value == red && x.Key <= 25 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 48);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--蓝大单
            list = result.Where(x => x.Value == blue && x.Key > 25 && x.Key % 2 != 0);
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
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--蓝大双
            list = result.Where(x => x.Value == blue && x.Key > 25 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 70);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--蓝小单
            list = result.Where(x => x.Value == blue && x.Key <= 25 && x.Key % 2 != 0);
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
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--蓝小双
            list = result.Where(x => x.Value == blue && x.Key <= 25 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 92);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--绿大单
            list = result.Where(x => x.Value == green && x.Key > 25 && x.Key % 2 != 0);
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
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--绿大双
            list = result.Where(x => x.Value == green && x.Key > 25 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 114);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--绿小单
            list = result.Where(x => x.Value == green && x.Key <= 25 && x.Key % 2 != 0);
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
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion

            #region 半半波--绿小双
            list = result.Where(x => x.Value == green && x.Key <= 25 && x.Key % 2 == 0);
            index = 0;
            foreach (var item in list)
            {
                Label lb = new Label();
                lb.Text = item.Key.ToString().PadLeft(2, '0');
                lb.BackColor = item.Value;
                lb.Width = 19;
                lb.Height = 12;
                lb.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lb.Location = new Point(496 + xInn * index, 136);
                this.groupBox4.Controls.Add(lb);
                index = index + 1;
            }
            #endregion
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void fmBS_Load(object sender, EventArgs e)
        {
            InitControls();
            WinNumberImpl winService = new WinNumberImpl();
            txtIssue.Text = winService.GetNewIssue().Body;

            Common.BindCustomers(cbox, (sender1, e1) =>
            {

            });
        }
    }
}
