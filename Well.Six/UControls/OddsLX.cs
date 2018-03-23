using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Model;

namespace Well.Six.UControls
{
    public partial class OddsLX : UserControl
    {
        public OddsLX()
        {
            InitializeComponent();
        }

        public Dictionary<int, decimal> GetResult()
        {
            var result = new Dictionary<int, decimal>();
            result.Add(1, Convert.ToDecimal(textBox1.Text.Trim()));
            result.Add(2, Convert.ToDecimal(textBox2.Text.Trim()));
            result.Add(3, Convert.ToDecimal(textBox3.Text.Trim()));
            result.Add(4, Convert.ToDecimal(textBox4.Text.Trim()));
            result.Add(5, Convert.ToDecimal(textBox5.Text.Trim()));
            result.Add(6, Convert.ToDecimal(textBox6.Text.Trim()));
            result.Add(7, Convert.ToDecimal(textBox7.Text.Trim()));
            result.Add(8, Convert.ToDecimal(textBox8.Text.Trim()));
            result.Add(9, Convert.ToDecimal(textBox9.Text.Trim()));
            result.Add(10, Convert.ToDecimal(textBox10.Text.Trim()));
            result.Add(11, Convert.ToDecimal(textBox11.Text.Trim()));
            result.Add(12, Convert.ToDecimal(textBox12.Text.Trim()));
            return result;
        }

        public void SetValues(Dictionary<int, decimal> values)
        {
            foreach (var item in values)
            {
                switch (item.Key)
                {
                    case 1:
                        textBox1.Text = item.Value.ToString();
                        break;
                    case 2:
                        textBox2.Text = item.Value.ToString();
                        break;
                    case 3:
                        textBox3.Text = item.Value.ToString();
                        break;
                    case 4:
                        textBox4.Text = item.Value.ToString();
                        break;
                    case 5:
                        textBox5.Text = item.Value.ToString();
                        break;
                    case 6:
                        textBox6.Text = item.Value.ToString();
                        break;
                    case 7:
                        textBox7.Text = item.Value.ToString();
                        break;
                    case 8:
                        textBox8.Text = item.Value.ToString();
                        break;
                    case 9:
                        textBox9.Text = item.Value.ToString();
                        break;
                    case 10:
                        textBox10.Text = item.Value.ToString();
                        break;
                    case 11:
                        textBox11.Text = item.Value.ToString();
                        break;
                    case 12:
                        textBox12.Text = item.Value.ToString();
                        break;
                }
            }

        }
    }
}
