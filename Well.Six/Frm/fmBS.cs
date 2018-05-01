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
    public partial class fmBS : Form
    {
        public fmBS()
        {
            InitializeComponent();

            txthb.Tag = (int)ChildType.红波;
            txthd.Tag = (int)ChildType.红单;
            txths.Tag = (int)ChildType.红双;
            txthda.Tag = (int)ChildType.红大;
            txthx.Tag = (int)ChildType.红小;
            txthxd.Tag = (int)ChildType.红小单;
            txthxs.Tag = (int)ChildType.红小双;
            txthdd.Tag = (int)ChildType.红大单;
            txthds.Tag = (int)ChildType.红大双;

            txtlb.Tag = (int)ChildType.绿波;
            txtld.Tag = (int)ChildType.绿单;
            txtls.Tag = (int)ChildType.绿双;
            txtlda.Tag = (int)ChildType.绿大;
            txtlx.Tag = (int)ChildType.绿小;
            txtlxd.Tag = (int)ChildType.绿小单;
            txtlxs.Tag = (int)ChildType.绿小双;
            txtldd.Tag = (int)ChildType.绿大单;
            txtlds.Tag = (int)ChildType.绿大双;

            txtlanb.Tag = (int)ChildType.蓝波;
            txtland.Tag = (int)ChildType.蓝单;
            txtlans.Tag = (int)ChildType.蓝双;
            txtlanda.Tag = (int)ChildType.蓝大;
            txtlanx.Tag = (int)ChildType.蓝小;
            txtlanxd.Tag = (int)ChildType.蓝小单;
            txtlanxs.Tag = (int)ChildType.蓝小双;
            txtlandd.Tag = (int)ChildType.蓝大单;
            txtlands.Tag = (int)ChildType.蓝大双;


            lbhb.Tag = txthb.Tag;
            lbhd.Tag = txthd.Tag;
            lbhs.Tag = txths.Tag;
            lbhda.Tag = txthda.Tag;
            lbhx.Tag = txthx.Tag;
            lbhxd.Tag = txthxd.Tag;
            lbhxs.Tag = txthxs.Tag;
            lbhdd.Tag = txthdd.Tag;
            lbhds.Tag = txthds.Tag;

            lblb.Tag = txtlb.Tag;
            lbld.Tag = txtld.Tag;
            lbls.Tag = txtls.Tag;
            lblda.Tag = txtlda.Tag;
            lblx.Tag = txtlx.Tag;
            lblxd.Tag = txtlxd.Tag;
            lblxs.Tag = txtlxs.Tag;
            lbldd.Tag = txtldd.Tag;
            lblds.Tag = txtlds.Tag;

            lblanb.Tag = txtlanb.Tag;
            lbland.Tag = txtland.Tag;
            lblans.Tag = txtlans.Tag;
            lblanda.Tag = txtlanda.Tag;
            lblanx.Tag = txtlanx.Tag;
            lblanxd.Tag = txtlanxd.Tag;
            lblanxs.Tag = txtlanxs.Tag;
            lblandd.Tag = txtlandd.Tag;
            lblands.Tag = txtlands.Tag;

            lbNamehb.Tag = txthb.Tag;
            lbNamehd.Tag = txthd.Tag;
            lbNamehs.Tag = txths.Tag;
            lbNamehda.Tag = txthda.Tag;
            lbNamehx.Tag = txthx.Tag;
            lbNamehxd.Tag = txthxd.Tag;
            lbNamehxs.Tag = txthxs.Tag;
            lbNamehdd.Tag = txthdd.Tag;
            lbNamehds.Tag = txthds.Tag;

            lbNamelb.Tag = txtlb.Tag;
            lbNameld.Tag = txtld.Tag;
            lbNamels.Tag = txtls.Tag;
            lbNamelda.Tag = txtlda.Tag;
            lbNamelx.Tag = txtlx.Tag;
            lbNamelxd.Tag = txtlxd.Tag;
            lbNamelxs.Tag = txtlxs.Tag;
            lbNameldd.Tag = txtldd.Tag;
            lbNamelds.Tag = txtlds.Tag;

            lbNamelanb.Tag = txtlanb.Tag;
            lbNameland.Tag = txtland.Tag;
            lbNamelans.Tag = txtlans.Tag;
            lbNamelanda.Tag = txtlanda.Tag;
            lbNamelanx.Tag = txtlanx.Tag;
            lbNamelanxd.Tag = txtlanxd.Tag;
            lbNamelanxs.Tag = txtlanxs.Tag;
            lbNamelandd.Tag = txtlandd.Tag;
            lbNamelands.Tag = txtlands.Tag;

            txthb.Name = "txt";
            txthd.Name = "txt";
            txths.Name = "txt";
            txthda.Name = "txt";
            txthx.Name = "txt";
            txthxd.Name = "txt";
            txthxs.Name = "txt";
            txthdd.Name = "txt";
            txthds.Name = "txt";

            txtlb.Name = "txt";
            txtld.Name = "txt";
            txtls.Name = "txt";
            txtlda.Name = "txt";
            txtlx.Name = "txt";
            txtlxd.Name = "txt";
            txtlxs.Name = "txt";
            txtldd.Name = "txt";
            txtlds.Name = "txt";

            txtlanb.Name = "txt";
            txtland.Name = "txt";
            txtlans.Name = "txt";
            txtlanda.Name = "txt";
            txtlanx.Name = "txt";
            txtlanxd.Name = "txt";
            txtlanxs.Name = "txt";
            txtlandd.Name = "txt";
            txtlands.Name = "txt";


            lbhb.Name = "pl";
            lbhd.Name = "pl";
            lbhs.Name = "pl";
            lbhda.Name = "pl";
            lbhx.Name = "pl";
            lbhxd.Name = "pl";
            lbhxs.Name = "pl";
            lbhdd.Name = "pl";
            lbhds.Name = "pl";

            lblb.Name = "pl";
            lbld.Name = "pl";
            lbls.Name = "pl";
            lblda.Name = "pl";
            lblx.Name = "pl";
            lblxd.Name = "pl";
            lblxs.Name = "pl";
            lbldd.Name = "pl";
            lblds.Name = "pl";

            lblanb.Name = "pl";
            lbland.Name = "pl";
            lblans.Name = "pl";
            lblanda.Name = "pl";
            lblanx.Name = "pl";
            lblanxd.Name = "pl";
            lblanxs.Name = "pl";
            lblandd.Name = "pl";
            lblands.Name = "pl";


            lbNamehb.Name = "code";
            lbNamehd.Name = "code";
            lbNamehs.Name = "code";
            lbNamehda.Name = "code";
            lbNamehx.Name = "code";
            lbNamehxd.Name = "code";
            lbNamehxs.Name = "code";
            lbNamehdd.Name = "code";
            lbNamehds.Name = "code";

            lbNamelb.Name = "code";
            lbNameld.Name = "code";
            lbNamels.Name = "code";
            lbNamelda.Name = "code";
            lbNamelx.Name = "code";
            lbNamelxd.Name = "code";
            lbNamelxs.Name = "code";
            lbNameldd.Name = "code";
            lbNamelds.Name = "code";

            lbNamelanb.Name = "code";
            lbNameland.Name = "code";
            lbNamelans.Name = "code";
            lbNamelanda.Name = "code";
            lbNamelanx.Name = "code";
            lbNamelanxd.Name = "code";
            lbNamelanxs.Name = "code";
            lbNamelandd.Name = "code";
            lbNamelands.Name = "code";
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
                Order_Type = (int)OrderType.波色,
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

        decimal value = 0m;
        private void fmBS_Load(object sender, EventArgs e)
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

                        value = tm.Return_PL;
                        tm.List.ToList().ForEach(x =>
                        {
                            switch (x.Key)
                            {
                                #region 红波
                                case (int)ChildType.红波:
                                    lbhb.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红单:
                                    lbhd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红双:
                                    lbhs.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红大:
                                    lbhda.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红小:
                                    lbhx.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红大单:
                                    lbhdd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红大双:
                                    lbhds.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红小单:
                                    lbhxd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.红小双:
                                    lbhxs.Text = x.Value.ToString();
                                    break;

                                #endregion

                                #region 绿波
                                case (int)ChildType.绿波:
                                    lblb.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿单:
                                    lbld.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿双:
                                    lbls.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿大:
                                    lblda.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿小:
                                    lblx.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿大单:
                                    lbldd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿大双:
                                    lblds.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿小单:
                                    lblxd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.绿小双:
                                    lblxs.Text = x.Value.ToString();
                                    break;

                                #endregion

                                #region 蓝波
                                case (int)ChildType.蓝波:
                                    lblanb.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝单:
                                    lbland.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝双:
                                    lblans.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝大:
                                    lblanda.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝小:
                                    lblanx.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝大单:
                                    lblandd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝大双:
                                    lblands.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝小单:
                                    lblanxd.Text = x.Value.ToString();
                                    break;
                                case (int)ChildType.蓝小双:
                                    lblanxs.Text = x.Value.ToString();
                                    break;

                                    #endregion

                                    //#region 特大单双

                                    //case (int)ChildType.特单:
                                    //    txttd.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特双:
                                    //    txtts.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特大:
                                    //    txttda.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特小:
                                    //    txttx.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特大单:
                                    //    txttdd.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特大双:
                                    //    txttds.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特小单:
                                    //    txttxd.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.特小双:
                                    //    txttxs.Text = x.Value.ToString();
                                    //    break;

                                    //#endregion

                                    //#region  合大小单双

                                    //case (int)ChildType.合单:
                                    //    txthed.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合双:
                                    //    txthes.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合大:
                                    //    txtheda.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合小:
                                    //    txthex.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合大单:
                                    //    txthedd.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合大双:
                                    //    txtheds.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合小单:
                                    //    txthexd.Text = x.Value.ToString();
                                    //    break;
                                    //case (int)ChildType.合小双:
                                    //    txthexs.Text = x.Value.ToString();
                                    //    break;

                                    //    #endregion
                            }

                        });
                        Common.CustomerId = cbox.SelectedValue.ToTryInt();
                    }
                }
            });
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
