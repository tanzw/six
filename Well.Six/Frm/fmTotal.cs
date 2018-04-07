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
    public partial class fmTotal : Form
    {
        public fmTotal()
        {
            InitializeComponent();
        }

        public void BindDataSource()
        {
            TotalImpl service = new TotalImpl();
            var result = service.GetTotalList();
            if (result.Code == 0)
            {
                dataGridView1.DataSource = result.Body;
            }
        }

        private void fmTotal_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }
    }
}
