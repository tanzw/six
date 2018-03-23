using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Common.Extensions;
using Well.Data;

namespace Well.Six.Frm
{
    public partial class fmNumberEdit : Form
    {
        Well.Data.WinNumberImpl service = new Data.WinNumberImpl();
        List<CodeNum> list = Well.Data.ServiceNum.GetNumsArray();

        Model.WinNumber CurrentModel = new Model.WinNumber();

        int NumberId = 0;
        public fmNumberEdit()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            Text = "新增开奖记录";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            txtIssue.Text = service.GetNewIssue().Body;
        }

        public fmNumberEdit(int _numberid)
        {
            InitializeComponent();
            CurrentModel.Id = _numberid;
            MinimizeBox = false;
            MaximizeBox = false;
            Text = "更新开奖记录";
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitValues();
        }

        public bool IsValid()
        {
            var result = true;
            if (!string.IsNullOrWhiteSpace(txtCode1.Text) && list.Count(x => x.Value == txtCode1.Text.Trim()) == 0)
            {
                result = false;
            }
            if (!string.IsNullOrWhiteSpace(txtCode2.Text) && list.Count(x => x.Value == txtCode2.Text.Trim()) == 0)
            {
                result = false;
            }
            if (!string.IsNullOrWhiteSpace(txtCode3.Text) && list.Count(x => x.Value == txtCode3.Text.Trim()) == 0)
            {
                result = false;
            }
            if (!string.IsNullOrWhiteSpace(txtCode4.Text) && list.Count(x => x.Value == txtCode4.Text.Trim()) == 0)
            {
                result = false;
            }
            if (!string.IsNullOrWhiteSpace(txtCode5.Text) && list.Count(x => x.Value == txtCode5.Text.Trim()) == 0)
            {
                result = false;
            }
            if (!string.IsNullOrWhiteSpace(txtCode6.Text) && list.Count(x => x.Value == txtCode6.Text.Trim()) == 0)
            {
                result = false;
            }
            if (!string.IsNullOrWhiteSpace(txtCode7.Text) && list.Count(x => x.Value == txtCode7.Text.Trim()) == 0)
            {
                result = false;
            }
            return result;
        }

        public void InitValues()
        {
            var result = service.GetModel(new Model.WinNumber() { Id = CurrentModel.Id });
            if (result.Code == 0 && result.Body != null)
            {
                CurrentModel = result.Body;
                txtCode1.Text = result.Body.Num1_Code;
                txtCode2.Text = result.Body.Num2_Code;
                txtCode3.Text = result.Body.Num3_Code;
                txtCode4.Text = result.Body.Num4_Code;
                txtCode5.Text = result.Body.Num5_Code;
                txtCode6.Text = result.Body.Num6_Code;
                txtCode7.Text = result.Body.Num7_Code;
                txtIssue.Text = result.Body.Issue;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                MessageEx.ShowWarning("输入的数据格式不正确,请重新输入");
                return;
            }

            CurrentModel.Issue = txtIssue.Text.Trim();
            CurrentModel.Num1_Code = txtCode1.Text.Trim();
            CurrentModel.Num1_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num1_Code).Zodiac;
            CurrentModel.Num2_Code = txtCode2.Text.Trim();
            CurrentModel.Num2_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num2_Code).Zodiac;
            CurrentModel.Num3_Code = txtCode3.Text.Trim();
            CurrentModel.Num3_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num3_Code).Zodiac;
            CurrentModel.Num4_Code = txtCode4.Text.Trim();
            CurrentModel.Num4_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num4_Code).Zodiac;
            CurrentModel.Num5_Code = txtCode5.Text.Trim();
            CurrentModel.Num5_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num5_Code).Zodiac;
            CurrentModel.Num6_Code = txtCode6.Text.Trim();
            CurrentModel.Num6_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num6_Code).Zodiac;
            CurrentModel.Num7_Code = txtCode7.Text.Trim();
            CurrentModel.Num7_Zodiac = list.FirstOrDefault(x => x.Value == CurrentModel.Num7_Code).Zodiac;

            if (CurrentModel.Id != 0)
            {
                CurrentModel.Update_User_Id = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                CurrentModel.Update_Time = "0";
                if (service.Update(CurrentModel).Code == 0)
                {
                    MessageEx.Show("更新开奖信息成功");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageEx.ShowWarning("更新开奖信息失败");
                }
            }
            else
            {
                CurrentModel.Create_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                CurrentModel.Create_User_Id = "0";
                if (service.Add(CurrentModel).Code == 0)
                {
                    MessageEx.Show("新增开奖信息成功");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageEx.ShowWarning("新增开奖信息失败");
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCode1.Text = "";
            txtCode2.Text = "";
            txtCode3.Text = "";
            txtCode4.Text = "";
            txtCode5.Text = "";
            txtCode6.Text = "";
            txtCode7.Text = "";
        }

        private void fmNumberEdit_Load(object sender, EventArgs e)
        {


        }

        private void Run()
        {
            
        }
    }
}
