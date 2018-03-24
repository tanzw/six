using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Data;

namespace Well.Six
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ToolStripButton t = new ToolStripButton();

            toolStrip1.Items.Add(t);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTM_Click(object sender, EventArgs e)
        {
            Frm.fmTM fm = new Frm.fmTM();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //TODO:加载订单
            }
        }

        private void btnLM_Click(object sender, EventArgs e)
        {
            Frm.fmLM fm = new Frm.fmLM();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void btnLX_Click(object sender, EventArgs e)
        {
            Frm.fmLX fm = new Frm.fmLX();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void btnFastTM_Click(object sender, EventArgs e)
        {
            Frm.fmFastTM fm = new Frm.fmFastTM();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void btnPTYX_Click(object sender, EventArgs e)
        {
            Frm.fmPTYX fm = new Frm.fmPTYX();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        #region 系统菜单
        private void 开奖记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmNumersList fm = new Frm.fmNumersList();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmChangePassword fm = new Frm.fmChangePassword();
            fm.ShowInTaskbar = false;
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        Thread thread = null;
        private void 备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var t = Task.Run(() =>
            {
                MessageEx.Show("开始");
                for (int i = 0; i < 999999999999999999; i++)
                {

                    this.Invoke(new Action(() =>
                    {
                        btnPTYX.Text = i.ToString();

                    }));
                }
                MessageEx.Show("结束");
            });
        }


        public void Test()
        {
            MessageEx.Show("开始");


            for (int i = 0; i < 999999999999999999; i++)
            {
                this.Invoke(new Action(() =>
            {
                btnPTYX.Text = i.ToString();

            }));
            }

            MessageEx.Show("结束");
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sd = ServiceNum.GetIssue();
        }

        #endregion

        #region 设置菜单

        private void 赔率设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 客户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.fmCustomer fm = new Frm.fmCustomer();
            fm.ShowInTaskbar = false;
            fm.MinimizeBox = false;
            fm.MaximizeBox = false;

            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowDialog();
        }

        #endregion

        #region 投注菜单

        private void 特码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTM_Click(sender, e);
        }

        private void 特码快捷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFastTM_Click(sender, e);
        }

        private void 连肖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLX_Click(sender, e);
        }

        private void 连码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLM_Click(sender, e);
        }


        #endregion


    }
}
