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
    public partial class fmLX : Form
    {
        public fmLX()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fmLX_Load(object sender, EventArgs e)
        {
            ulx2l.OrderType = (int)OrderType.连肖;
            ulx3l.OrderType = (int)OrderType.连肖;
            ulx4l.OrderType = (int)OrderType.连肖;
            ulx5l.OrderType = (int)OrderType.连肖;
            ulx2l.ChildType = (int)ChildType.二连肖;
            ulx3l.ChildType = (int)ChildType.三连肖;
            ulx4l.ChildType = (int)ChildType.四连肖;
            ulx5l.ChildType = (int)ChildType.五连肖;
            ulx2l.InitControls();
            ulx3l.InitControls();
            ulx4l.InitControls();
            ulx5l.InitControls();


            //this.AcceptButton
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
                        switch (this.tabControl1.SelectedIndex)
                        {
                            case 0:
                                ulx2l.btnOK_Click(null, null);
                                break;
                            case 1:
                                ulx3l.btnOK_Click(null, null);
                                break;
                            case 2:
                                ulx4l.btnOK_Click(null, null);
                                break;
                            case 3:
                                ulx5l.btnOK_Click(null, null);
                                break;
                        }

                        break;
                }
            }
            return false;
        }
    }
}
