using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using Well.Common.Result;
using Well.Model;
using Well.Common.Extensions;
using System.Data;

namespace Well.Data
{
    public class WinNumberImpl : DataBase
    {
        public StandardResult Add(WinNumber model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "Insert into t_winnumbers(issue,num1_code,num1_zodiac,num2_code,num2_zodiac,num3_code,num3_zodiac,num4_code,num4_zodiac,num5_code,num5_zodiac,num6_code,num6_zodiac,num7_code,num7_zodiac,create_time,create_user_id,upadte_time,update_user_id)" +
                    " values(@Issue,@Num1_Code,@Num1_Zodiac,@Num2_Code,@Num2_Zodiac,@Num3_Code,@Num3_Zodiac,@Num4_Code,@Num4_Zodiac,@Num5_Code,@Num5_Zodiac,@Num6_Code,@Num6_Zodiac,@Num7_Code,@Num7_Zodiac,@Create_Time,@Create_User_Id,@Update_Time,@Update_User_Id)";
                if (db.Execute(sqlCommandText, model) <= 0)
                {
                    result.Code = 1;
                    result.Msg = "失败";
                }
                return result;
            }
        }

        public StandardResult Update(WinNumber model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommandText = new StringBuilder();
                sqlCommandText.Append("Update t_winnumbers set ");
                sqlCommandText.Append(" issue=@Issue,");
                sqlCommandText.Append(" num1_code=@Num1_Code,");
                sqlCommandText.Append(" num1_zodiac=@Num1_Zodiac,");
                sqlCommandText.Append(" num2_code=@Num2_Code,");
                sqlCommandText.Append(" num2_zodiac=@Num2_Zodiac,");
                sqlCommandText.Append(" num3_code=@Num3_Code,");
                sqlCommandText.Append(" num3_zodiac=@Num3_Zodiac,");
                sqlCommandText.Append(" num4_code=@Num4_Code,");
                sqlCommandText.Append(" num4_zodiac=@Num4_Zodiac,");
                sqlCommandText.Append(" num5_code=@Num5_Code,");
                sqlCommandText.Append(" num5_zodiac=@Num5_Zodiac,");
                sqlCommandText.Append(" num6_code=@Num6_Code,");
                sqlCommandText.Append(" num6_zodiac=@Num6_Zodiac,");
                sqlCommandText.Append(" num7_code=@Num7_Code,");
                sqlCommandText.Append(" num7_zodiac=@Num7_Zodiac,");
                sqlCommandText.Append(" upadte_time=@Update_Time,");
                sqlCommandText.Append(" update_user_id=@Update_User_Id");
                sqlCommandText.Append(" where id = @Id");

                if (db.Execute(sqlCommandText.ToString(), model) <= 0)
                {
                    result.Code = 1;
                    result.Msg = "失败";
                }
                return result;
            }
        }

        public StandardResult<string> GetNewIssue()
        {
            var result = new StandardResult<string>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select max(issue)  from t_winnumbers  ";
                var obj = db.ExecuteScalar(sqlCommandText, null);
                if (obj != null && obj != DBNull.Value)
                {
                    var issue = obj.ToTryInt();
                    if (obj.ToString().Substring(0, 4) == DateTime.Now.Year.ToString())
                    {
                        result.Body = (issue + 1).ToString();
                    }
                    else
                    {
                        result.Body = DateTime.Now.Year + "001";
                    }
                }
                else
                {
                    result.Body = "";
                    result.Code = 1;
                    result.Msg = "没有获取到数据";
                }
            }
            return result;
        }

        public StandardResult<WinNumber> GetModel(WinNumber model)
        {
            StandardResult<WinNumber> result = new StandardResult<WinNumber>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select *  from t_winnumbers where ";
                if (model.Id != 0)
                {
                    sqlCommandText += " id=@Id";
                }
                else if (!string.IsNullOrWhiteSpace(model.Issue))
                {
                    sqlCommandText += " issue=@Issue";
                }
                result.Body = db.Query<WinNumber>(sqlCommandText, model).FirstOrDefault();


                return result;
            }
        }

        public StandardResult<List<WinNumber>> GetList(WinNumber model)
        {
            StandardResult<List<WinNumber>> result = new StandardResult<List<WinNumber>>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select *  from t_winnumbers  order by issue desc";
                result.Body = db.Query<WinNumber>(sqlCommandText, model).AsList();

                foreach (var item in result.Body)
                {
                    item.Display1 = item.Num1_Code + "\n" + item.Num1_Zodiac;
                    item.Display2 = item.Num2_Code + "\n" + item.Num2_Zodiac;
                    item.Display3 = item.Num3_Code + "\n" + item.Num3_Zodiac;
                    item.Display4 = item.Num4_Code + "\n" + item.Num4_Zodiac;
                    item.Display5 = item.Num5_Code + "\n" + item.Num5_Zodiac;
                    item.Display6 = item.Num6_Code + "\n" + item.Num6_Zodiac;
                    item.Display7 = item.Num7_Code + "\n" + item.Num7_Zodiac;
                    item.Create_Time = string.IsNullOrWhiteSpace(item.Create_Time) ? "" : DateTime.Parse(item.Create_Time).ToString("yyyy-MM-dd");
                }
                return result;
            }
        }

        #region 开奖
        public StandardResult Run(string issue)
        {
            var result = new StandardResult();
            var l1 = GetOrderTMList(issue);
            var l2 = GetOrderLXLMList(issue);
            var model = GetModel(new WinNumber() { Issue = issue });
            using (var db = base.NewDB())
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();

                var tempList = new List<string>();
                try
                {
                    var orderMainStatus = (int)ResultStatus.Lose;
                    foreach (var item in l1)
                    {
                        foreach (var detail in item.OrderDetails)
                        {
                            switch (item.Order_Type)
                            {
                                case (int)OrderType.特码:
                                case (int)OrderType.特码快捷:
                                    if (detail.Code == model.Body.Num7_Code)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)OrderType.平特一肖:
                                    if (detail.Code == model.Body.Num1_Zodiac || detail.Code == model.Body.Num2_Zodiac || detail.Code == model.Body.Num3_Zodiac || detail.Code == model.Body.Num4_Zodiac || detail.Code == model.Body.Num5_Zodiac || detail.Code == model.Body.Num6_Zodiac || detail.Code == model.Body.Num7_Zodiac)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)OrderType.尾数:
                                    if (detail.Code == model.Body.Num7_Code.Substring(model.Body.Num7_Code.Length - 1, 1))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                            }

                            UpdateOrderTMStatus(detail, trans);
                        }
                        UpdateOrderStatus(item.Id, orderMainStatus, trans);
                    }

                    orderMainStatus = (int)ResultStatus.Lose;
                    foreach (var item in l2)
                    {
                        foreach (var detail in item.OrderDetails)
                        {
                            switch (item.Order_Type)
                            {
                                case (int)OrderType.二连肖:
                                case (int)OrderType.二连码:
                                    if (model.Body.CodeList.Contains(detail.Code1) && model.Body.CodeList.Contains(detail.Code2))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)OrderType.三连肖:
                                case (int)OrderType.三连码:
                                    if (model.Body.CodeList.Contains(detail.Code1) && model.Body.CodeList.Contains(detail.Code2) && model.Body.CodeList.Contains(detail.Code3))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)OrderType.四连肖:
                                case (int)OrderType.四连码:
                                    if (model.Body.CodeList.Contains(detail.Code1) && model.Body.CodeList.Contains(detail.Code2) && model.Body.CodeList.Contains(detail.Code3) && model.Body.CodeList.Contains(detail.Code4))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)OrderType.五连肖:
                                case (int)OrderType.五连码:
                                    if (model.Body.CodeList.Contains(detail.Code1) && model.Body.CodeList.Contains(detail.Code2) && model.Body.CodeList.Contains(detail.Code3) && model.Body.CodeList.Contains(detail.Code4) && model.Body.CodeList.Contains(detail.Code5))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                            }

                            UpdateOrderLXLMStatus(detail, trans);
                        }
                        UpdateOrderStatus(item.Id, orderMainStatus, trans);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    result.Code = 1;
                    result.Msg = "失败";
                }
            }
            return result;

        }

        private List<Order<OrderTM>> GetOrderTMList(string issue)
        {

            using (var db = base.NewDB())
            {
                List<Order<OrderTM>> result = new List<Order<OrderTM>>();

                string sqlCommandText = @"select 
                                1 as t1,
                                t_orders.*,
                                1 as t2,
                                t_orders_tm.* 
                                from t_orders inner join t_orders_tm on t_orders.id=t_orders_tm.orderid 
                                where t_orders.issue=@Issue";


                db.Query<Order<OrderTM>, OrderTM, Order<OrderTM>>(sqlCommandText,
                                    (orderMain, orderTM) =>
                                    {
                                        if (result.Count(x => x.Id == orderMain.Id) == 0)
                                        {
                                            orderMain.OrderDetails.Add(orderTM);
                                            result.Add(orderMain);
                                        }
                                        else
                                        {
                                            result.FirstOrDefault(x => x.Id == orderMain.Id).OrderDetails.Add(orderTM);
                                        }
                                        return orderMain;
                                    }, param: new { Issue = issue }, splitOn: "t1,t2").ToList();

                return result;
            }
        }

        private List<Order<OrderLXLM>> GetOrderLXLMList(string issue)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            using (var db = base.NewDB())
            {
                List<Order<OrderLXLM>> result = new List<Order<OrderLXLM>>();

                string sqlCommandText = @"select 
                                1 as t1,
                                t_orders.*,
                                1 as t2,
                                t_orders_lxlm.* 
                                from t_orders inner join t_orders_lxlm on t_orders.id=t_orders_lxlm.orderid 
                                where t_orders.issue=@Issue";

                db.Query<Order<OrderLXLM>, OrderLXLM, Order<OrderLXLM>>(sqlCommandText,
                                    (orderMain, orderLXLM) =>
                                    {
                                        if (result.Count(x => x.Id == orderMain.Id) == 0)
                                        {
                                            orderMain.OrderDetails.Add(orderLXLM);
                                            result.Add(orderMain);
                                        }
                                        else
                                        {
                                            result.FirstOrDefault(x => x.Id == orderMain.Id).OrderDetails.Add(orderLXLM);
                                        }
                                        return orderMain;
                                    }, param: new { Issue = issue }, splitOn: "t1,t2").ToList();

                return result;
            }
        }

        private StandardResult UpdateOrderTMStatus(OrderTM model, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            StringBuilder sqlCommandText = new StringBuilder();
            sqlCommandText.Append("Update t_orders_tm set ");
            sqlCommandText.Append(" status=@Status");
            sqlCommandText.Append(" where id = @Id");

            if (db.Execute(sqlCommandText.ToString(), model, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }

            return result;
        }

        private StandardResult UpdateOrderLXLMStatus(OrderLXLM model, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            StringBuilder sqlCommandText = new StringBuilder();
            sqlCommandText.Append("Update t_orders_lxlm set ");
            sqlCommandText.Append(" status=@Status");
            sqlCommandText.Append(" where id = @Id");

            if (db.Execute(sqlCommandText.ToString(), model, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }

        private StandardResult UpdateOrderStatus(string id, int status, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            StringBuilder sqlCommandText = new StringBuilder();
            sqlCommandText.Append("Update t_orders set ");
            sqlCommandText.Append(" status=@Status");
            sqlCommandText.Append(" where id = @Id");

            if (db.Execute(sqlCommandText.ToString(), new { Status = status, Id = id }, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }
        #endregion



    }
}
