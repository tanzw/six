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
                            case (int)OrderType.连码:
                                var pl_lm = Newtonsoft.Json.JsonConvert.DeserializeObject<LMOdds>(item.strJson);
                                if (pl_lm != null)
                                {
                                    txtEQZ.Text = pl_lm.EQZ.ToString();
                                    txtLMFS.Text = pl_lm.Return_PL.ToString();
                                    txtSIQZ.Text = pl_lm.SIZHONGSI.ToString();
                                    txtSQZ.Text = pl_lm.SQZ.ToString();
                                    txtSZE.Text = pl_lm.SZE.ToString();
                                    txtSZS.Text = pl_lm.SZS.ToString();
                                    txttp.Text = pl_lm.TP.ToString();
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
                            case (int)ChildType.尾数:
                                var ws = Newtonsoft.Json.JsonConvert.DeserializeObject<LXOdds>(item.strJson);
                                if (ws != null)
                                {
                                    foreach (var oo in ws.List)
                                    {
                                        switch (oo.Key)
                                        {

                                            case 0:
                                                txt0w.Text = oo.Value.ToString();
                                                break;
                                            case 1:
                                                txt1w.Text = oo.Value.ToString();
                                                break;
                                            case 2:
                                                txt2w.Text = oo.Value.ToString();
                                                break;
                                            case 3:
                                                txt3w.Text = oo.Value.ToString();
                                                break;
                                            case 4:
                                                txt4w.Text = oo.Value.ToString();
                                                break;
                                            case 5:
                                                txt5w.Text = oo.Value.ToString();
                                                break;
                                            case 6:
                                                txt6w.Text = oo.Value.ToString();
                                                break;
                                            case 7:
                                                txt7w.Text = oo.Value.ToString();
                                                break;
                                            case 8:
                                                txt8w.Text = oo.Value.ToString();
                                                break;
                                            case 9:
                                                txt9w.Text = oo.Value.ToString();
                                                break;
                                        }
                                    }
                                    txtwsfs.Text = ws.Return_PL.ToString();
                                }
                                break;
                            case (int)OrderType.大小单双:
                                var bs = Newtonsoft.Json.JsonConvert.DeserializeObject<BSOdds>(item.strJson);
                                if (bs != null)
                                {
                                    txtfs.Text = bs.Return_PL.ToString();
                                    foreach (var oo in bs.List)
                                    {
                                        switch (oo.Key)
                                        {

                                            #region 红波
                                            case (int)ChildType.红波:
                                                txthb.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红单:
                                                txthd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红双:
                                                txths.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红大:
                                                txthda.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红小:
                                                txthx.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红大单:
                                                txthdd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红大双:
                                                txthds.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红小单:
                                                txthxd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.红小双:
                                                txthxs.Text = oo.Value.ToString();
                                                break;

                                            #endregion

                                            #region 绿波
                                            case (int)ChildType.绿波:
                                                txtlb.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿单:
                                                txtld.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿双:
                                                txtls.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿大:
                                                txtlda.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿小:
                                                txtlx.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿大单:
                                                txtldd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿大双:
                                                txtlds.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿小单:
                                                txtlxd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.绿小双:
                                                txtlxs.Text = oo.Value.ToString();
                                                break;

                                            #endregion

                                            #region 蓝波
                                            case (int)ChildType.蓝波:
                                                txtlanb.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝单:
                                                txtland.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝双:
                                                txtlans.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝大:
                                                txtlanda.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝小:
                                                txtlanx.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝大单:
                                                txtlandd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝大双:
                                                txtlands.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝小单:
                                                txtlanxd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.蓝小双:
                                                txtlanxs.Text = oo.Value.ToString();
                                                break;

                                            #endregion

                                            #region 特大单双

                                            case (int)ChildType.特单:
                                                txttd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特双:
                                                txtts.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特大:
                                                txttda.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特小:
                                                txttx.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特大单:
                                                txttdd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特大双:
                                                txttds.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特小单:
                                                txttxd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.特小双:
                                                txttxs.Text = oo.Value.ToString();
                                                break;

                                            #endregion

                                            #region  合大小单双

                                            case (int)ChildType.合单:
                                                txthed.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合双:
                                                txthes.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合大:
                                                txtheda.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合小:
                                                txthex.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合大单:
                                                txthedd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合大双:
                                                txtheds.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合小单:
                                                txthexd.Text = oo.Value.ToString();
                                                break;
                                            case (int)ChildType.合小双:
                                                txthexs.Text = oo.Value.ToString();
                                                break;

                                                #endregion

                                        }

                                    }

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
            lm.TP = Convert.ToDecimal(txttp.Text.Trim());
            lm.SIZHONGSI = Convert.ToDecimal(txtSIQZ.Text.Trim());
            lm.Return_PL = Convert.ToDecimal(txtLMFS.Text.Trim());


            Well.Model.BSOdds bs = new BSOdds();
            bs.Return_PL = Convert.ToDecimal(txtfs.Text.Trim());
            bs.List = new Dictionary<int, decimal>();

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
            lmModel.OrderType = (int)OrderType.连码;
            lmModel.Return_PL = lm.Return_PL;
            lmModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(lm);
            list.Add(lmModel);

            Well.Model.OddsData ptyxModel = new Model.OddsData();
            ptyxModel.CustomerId = customerId;
            ptyxModel.OrderType = (int)ChildType.平特;
            ptyxModel.Return_PL = pt.Return_PL;
            ptyxModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(pt);
            list.Add(ptyxModel);

            Well.Model.OddsData bsModel = new Model.OddsData();
            bsModel.CustomerId = customerId;
            bsModel.OrderType = (int)OrderType.大小单双;
            bsModel.Return_PL = Convert.ToDecimal(txtfs.Text.Trim());


            bs.List.Add((int)ChildType.红波, Convert.ToDecimal(txthb.Text.Trim()));
            bs.List.Add((int)ChildType.绿波, Convert.ToDecimal(txtlb.Text.Trim()));
            bs.List.Add((int)ChildType.蓝波, Convert.ToDecimal(txtlanb.Text.Trim()));

            bs.List.Add((int)ChildType.红单, Convert.ToDecimal(txthd.Text.Trim()));
            bs.List.Add((int)ChildType.红双, Convert.ToDecimal(txths.Text.Trim()));
            bs.List.Add((int)ChildType.红大, Convert.ToDecimal(txthda.Text.Trim()));
            bs.List.Add((int)ChildType.红小, Convert.ToDecimal(txthx.Text.Trim()));
            bs.List.Add((int)ChildType.红大单, Convert.ToDecimal(txthdd.Text.Trim()));
            bs.List.Add((int)ChildType.红小单, Convert.ToDecimal(txthxd.Text.Trim()));
            bs.List.Add((int)ChildType.红大双, Convert.ToDecimal(txthds.Text.Trim()));
            bs.List.Add((int)ChildType.红小双, Convert.ToDecimal(txthxs.Text.Trim()));

            bs.List.Add((int)ChildType.绿单, Convert.ToDecimal(txtld.Text.Trim()));
            bs.List.Add((int)ChildType.绿双, Convert.ToDecimal(txtls.Text.Trim()));
            bs.List.Add((int)ChildType.绿大, Convert.ToDecimal(txtlda.Text.Trim()));
            bs.List.Add((int)ChildType.绿小, Convert.ToDecimal(txtlx.Text.Trim()));
            bs.List.Add((int)ChildType.绿大单, Convert.ToDecimal(txtldd.Text.Trim()));
            bs.List.Add((int)ChildType.绿小单, Convert.ToDecimal(txtlxd.Text.Trim()));
            bs.List.Add((int)ChildType.绿大双, Convert.ToDecimal(txtlds.Text.Trim()));
            bs.List.Add((int)ChildType.绿小双, Convert.ToDecimal(txtlxs.Text.Trim()));

            bs.List.Add((int)ChildType.蓝单, Convert.ToDecimal(txtland.Text.Trim()));
            bs.List.Add((int)ChildType.蓝双, Convert.ToDecimal(txtlans.Text.Trim()));
            bs.List.Add((int)ChildType.蓝大, Convert.ToDecimal(txtlanda.Text.Trim()));
            bs.List.Add((int)ChildType.蓝小, Convert.ToDecimal(txtlanx.Text.Trim()));
            bs.List.Add((int)ChildType.蓝大单, Convert.ToDecimal(txtlandd.Text.Trim()));
            bs.List.Add((int)ChildType.蓝小单, Convert.ToDecimal(txtlanxd.Text.Trim()));
            bs.List.Add((int)ChildType.蓝大双, Convert.ToDecimal(txtlands.Text.Trim()));
            bs.List.Add((int)ChildType.蓝小双, Convert.ToDecimal(txtlanxs.Text.Trim()));


            bs.List.Add((int)ChildType.特单, Convert.ToDecimal(txttd.Text.Trim()));
            bs.List.Add((int)ChildType.特双, Convert.ToDecimal(txtts.Text.Trim()));
            bs.List.Add((int)ChildType.特大, Convert.ToDecimal(txttda.Text.Trim()));
            bs.List.Add((int)ChildType.特小, Convert.ToDecimal(txttx.Text.Trim()));
            bs.List.Add((int)ChildType.特大单, Convert.ToDecimal(txttdd.Text.Trim()));
            bs.List.Add((int)ChildType.特小单, Convert.ToDecimal(txttxd.Text.Trim()));
            bs.List.Add((int)ChildType.特大双, Convert.ToDecimal(txttds.Text.Trim()));
            bs.List.Add((int)ChildType.特小双, Convert.ToDecimal(txttxs.Text.Trim()));

            bs.List.Add((int)ChildType.合单, Convert.ToDecimal(txthed.Text.Trim()));
            bs.List.Add((int)ChildType.合双, Convert.ToDecimal(txthes.Text.Trim()));
            bs.List.Add((int)ChildType.合大, Convert.ToDecimal(txtheda.Text.Trim()));
            bs.List.Add((int)ChildType.合小, Convert.ToDecimal(txthex.Text.Trim()));
            bs.List.Add((int)ChildType.合大单, Convert.ToDecimal(txthedd.Text.Trim()));
            bs.List.Add((int)ChildType.合小单, Convert.ToDecimal(txthexd.Text.Trim()));
            bs.List.Add((int)ChildType.合大双, Convert.ToDecimal(txtheds.Text.Trim()));
            bs.List.Add((int)ChildType.合小双, Convert.ToDecimal(txthexs.Text.Trim()));


            bsModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(bs);
            list.Add(bsModel);

            Well.Model.LXOdds ws = new Model.LXOdds();
            ws.List = new Dictionary<int, decimal>();
            ws.Return_PL = Convert.ToDecimal(txtwsfs.Text.Trim());
            ws.List.Add(0, Convert.ToDecimal(txt0w.Text.Trim()));
            ws.List.Add(1, Convert.ToDecimal(txt1w.Text.Trim()));
            ws.List.Add(2, Convert.ToDecimal(txt2w.Text.Trim()));
            ws.List.Add(3, Convert.ToDecimal(txt3w.Text.Trim()));
            ws.List.Add(4, Convert.ToDecimal(txt4w.Text.Trim()));
            ws.List.Add(5, Convert.ToDecimal(txt5w.Text.Trim()));
            ws.List.Add(6, Convert.ToDecimal(txt6w.Text.Trim()));
            ws.List.Add(7, Convert.ToDecimal(txt7w.Text.Trim()));
            ws.List.Add(8, Convert.ToDecimal(txt8w.Text.Trim()));
            ws.List.Add(9, Convert.ToDecimal(txt9w.Text.Trim()));


            Well.Model.OddsData wsModel = new Model.OddsData();
            wsModel.CustomerId = customerId;
            wsModel.OrderType = (int)ChildType.尾数;
            wsModel.Return_PL = Convert.ToDecimal(txtwsfs.Text.Trim());
            wsModel.strJson = Newtonsoft.Json.JsonConvert.SerializeObject(ws);
            list.Add(wsModel);


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

