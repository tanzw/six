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
using Well.Model;

namespace Well.Six.Frm
{
    public partial class fmOdds : Form
    {

        int customerId = 0;

        public fmOdds(int id)
        {
            InitializeComponent();
            customerId = id;

        }

        public void InitValues()
        {
            if (customerId != 0)
            {
                OddsImpl service = new OddsImpl();
                var result = service.GetList(customerId);
                if (result.Code == 0)
                {
                    foreach (var item in result.Body)
                    {
                        switch (item.OrderType)
                        {
                            case (int)ChildType.特码:
                                var pl_tm = Newtonsoft.Json.JsonConvert.DeserializeObject<TMOdds>(item.strJson);
                                if (pl_tm != null)
                                {
                                    txtTMPL.Text = pl_tm.Num_PL.ToString();
                                    txtTMFS.Text = pl_tm.Return_PL.ToString();
                                }
                                break;
                            case (int)ChildType.二连肖:
                                var pl_lm2 = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(item.strJson);
                                if (pl_lm2 != null)
                                {
                                    oddsLX1.SetValues(pl_lm2.List);
                                    txtLXFS.Text = pl_lm2.Return_PL.ToString();
                                }
                                break;
                            case (int)ChildType.三连肖:
                                var pl_lm3 = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(item.strJson);
                                if (pl_lm3 != null)
                                {
                                    oddsLX2.SetValues(pl_lm3.List);
                                    txtLXFS.Text = pl_lm3.Return_PL.ToString();
                                }
                                break;
                            case (int)ChildType.四连肖:
                                var pl_lm4 = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(item.strJson);
                                if (pl_lm4 != null)
                                {
                                    oddsLX3.SetValues(pl_lm4.List);
                                    txtLXFS.Text = pl_lm4.Return_PL.ToString();
                                }
                                break;
                            case (int)ChildType.五连肖:
                                var pl_lm5 = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(item.strJson);
                                if (pl_lm5 != null)
                                {
                                    oddsLX4.SetValues(pl_lm5.List);
                                    txtLXFS.Text = pl_lm5.Return_PL.ToString();
                                }
                                break;
                            case (int)ChildType.二全中:
                                var pl_lm = Newtonsoft.Json.JsonConvert.DeserializeObject<LMOdds>(item.strJson);
                                if (pl_lm != null)
                                {
                                    txtEQZ.Text = pl_lm.EQZ.ToString();
                                    txtLMFS.Text = pl_lm.Return_PL.ToString();
                                    txtSIQZ.Text = pl_lm.SIZHONGSI.ToString();
                                    txtSQZ.Text = pl_lm.SQZ.ToString();
                                    txtSZE.Text = pl_lm.SZE.ToString();
                                    txtSZS.Text = pl_lm.SZS.ToString();
                                }
                                break;
                            case (int)ChildType.平特:
                                var pl_ptyx = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(item.strJson);
                                if (pl_ptyx != null)
                                {
                                    oddsLX5.SetValues(pl_ptyx.List);
                                    txtPTYXFS.Text = pl_ptyx.Return_PL.ToString();
                                }

                                break;
                        }
                    }

                }
            }
        }

        string defaultTMOdds = "43.00";

        private void InitTM()
        {

            var PointX = 20;
            var PointY = 20;
            var interval = 10;
            var currentColumn = 0;
            for (int i = 1; i < 50; i++)
            {
                Label lbNum = new Label();
                lbNum.Text = i.ToString().PadLeft(2, '0');
                lbNum.Size = new Size(26, 16);
                lbNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

                TextBox txt = new TextBox();
                txt.Size = new Size(50, 20);
                txt.Text = defaultTMOdds;

                if (i == 1 || i == 11 || i == 21 || i == 31 || i == 41)
                {
                    PointY = 20;
                }
                PointX = 50;
                if (i % 10 > 0)
                {
                    currentColumn = i / 10 + 1;
                }
                else
                {
                    currentColumn = i / 10;
                }
                PointX = PointX + 140 * (currentColumn - 1);


                lbNum.Location = new Point(PointX, PointY);

                txt.Location = new Point(PointX + 30, PointY);

                PointY = PointY + interval + lbNum.Height;

                tabPage1.Controls.Add(lbNum);
                tabPage1.Controls.Add(txt);

            }



        }

        private void fmOdds_Load(object sender, EventArgs e)
        {
            InitValues();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var list = new List<Model.OddsData>();

            Well.Model.TMOdds tm = new Model.TMOdds();
            tm.Num_PL = Convert.ToDecimal(txtTMPL.Text.Trim());
            tm.Return_PL = Convert.ToDecimal(txtTMFS.Text.Trim());


            Well.Model.LXOdds lx2 = new Model.LXOdds();
            lx2.List = oddsLX1.GetResult();

            Well.Model.LXOdds lx3 = new Model.LXOdds();
            lx3.List = oddsLX2.GetResult();

            Well.Model.LXOdds lx4 = new Model.LXOdds();
            lx4.List = oddsLX3.GetResult();

            Well.Model.LXOdds lx5 = new Model.LXOdds();
            lx5.List = oddsLX4.GetResult();

            lx2.Return_PL = Convert.ToDecimal(txtLXFS.Text.Trim());
            lx3.Return_PL = Convert.ToDecimal(txtLXFS.Text.Trim());
            lx4.Return_PL = Convert.ToDecimal(txtLXFS.Text.Trim());
            lx5.Return_PL = Convert.ToDecimal(txtLXFS.Text.Trim());

            Well.Model.LXOdds pt = new Model.LXOdds();
            pt.List = oddsLX5.GetResult();
            pt.Return_PL = Convert.ToDecimal(txtPTYXFS.Text.Trim());

            Well.Model.LMOdds lm = new Model.LMOdds();
            lm.EQZ = Convert.ToDecimal(txtEQZ.Text.Trim());
            lm.SQZ = Convert.ToDecimal(txtSQZ.Text.Trim());
            lm.SZE = Convert.ToDecimal(txtSZE.Text.Trim());

            lm.SZS = Convert.ToDecimal(txtSZS.Text.Trim());

            lm.SIZHONGSI = Convert.ToDecimal(txtSIQZ.Text.Trim());
            lm.Return_PL = Convert.ToDecimal(txtLMFS.Text.Trim());

            Well.Model.OddsData tmModel = new Model.OddsData();
            tmModel.CustomerId = customerId;
            tmModel.OrderType = (int)ChildType.特码;
            tmModel.Return_PL = tm.Return_PL;
            tmModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(tm);
            list.Add(tmModel);

            Well.Model.OddsData lx2Model = new Model.OddsData();
            lx2Model.CustomerId = customerId;
            lx2Model.OrderType = (int)ChildType.二连肖;
            lx2Model.Return_PL = lx2.Return_PL;
            lx2Model.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(lx2);
            list.Add(lx2Model);

            Well.Model.OddsData lx3Model = new Model.OddsData();
            lx3Model.CustomerId = customerId;
            lx3Model.OrderType = (int)ChildType.三连肖;
            lx3Model.Return_PL = lx3.Return_PL;
            lx3Model.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(lx3);
            list.Add(lx3Model);

            Well.Model.OddsData lx4Model = new Model.OddsData();
            lx4Model.CustomerId = customerId;
            lx4Model.OrderType = (int)ChildType.四连肖;
            lx4Model.Return_PL = lx4.Return_PL;
            lx4Model.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(lx4);
            list.Add(lx4Model);

            Well.Model.OddsData lx5Model = new Model.OddsData();
            lx5Model.CustomerId = customerId;
            lx5Model.OrderType = (int)ChildType.五连肖;
            lx5Model.Return_PL = lx5.Return_PL;
            lx5Model.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(lx5);
            list.Add(lx5Model);

            Well.Model.OddsData lmModel = new Model.OddsData();
            lmModel.CustomerId = customerId;
            lmModel.OrderType = (int)ChildType.二全中;
            lmModel.Return_PL = lm.Return_PL;
            lmModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(lm);
            list.Add(lmModel);

            Well.Model.OddsData ptyxModel = new Model.OddsData();
            ptyxModel.CustomerId = customerId;
            ptyxModel.OrderType = (int)ChildType.平特;
            ptyxModel.Return_PL = pt.Return_PL;
            ptyxModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(pt);
            list.Add(ptyxModel);

            OddsImpl service = new OddsImpl();
            if (service.Add(list).Code == 0)
            {
                MessageEx.Show("成功");
            }
            else
            {
                MessageEx.ShowWarning("失败");
            }


        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}
