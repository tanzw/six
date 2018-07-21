using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using Well.Common.Result;
using Well.Model;
using System.Data;

namespace Well.Data
{
    public class OrderImpl : DataBase
    {

        /// <summary>
        /// 新增特码订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public StandardResult AddOrderTM(Order<OrderTM> model, int flag = 1)
        {
            var result = new StandardResult();
            using (var db = base.NewDB(flag))
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();
                try
                {
                    if (AddOrderMain(model, trans).Code != 0)
                    {
                        throw new Exception("订单主表添加失败");
                    }
                    if (AddOrderTMDetails(model.OrderDetails, trans).Code != 0)
                    {
                        throw new Exception("订单明细添加失败");
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    result.Code = 1;
                    result.Msg = "失败";
                }
            }
            return result;
        }

        public StandardResult AddOrderLXLM(Order<OrderLXLM> model, int flag = 1)
        {
            var result = new StandardResult();
            using (var db = base.NewDB(flag))
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();
                try
                {
                    if (AddOrderMain(model, trans).Code != 0)
                    {
                        throw new Exception("订单主表添加失败");
                    }
                    if (AddOrderLXLMDetails(model.OrderDetails, trans).Code != 0)
                    {
                        throw new Exception("订单明细添加失败");
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    result.Code = 1;
                    result.Msg = "失败";
                }
            }
            return result;
        }

        /// <summary>
        /// 新增订单主体信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private StandardResult AddOrderMain(OrderMain model, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            string sqlCommandText = "Insert into t_orders(id,order_no,issue,order_type,child_type,customer_id,total_in_money,total_out_money,create_time,create_user_id,update_time,update_user_id,ischeck,isdel,status,sort)  values(@Id,@Order_No,@Issue,@Order_Type,@Child_Type,@Customer_Id,@Total_In_Money,@Total_Out_Money,@Create_Time,@Create_User_Id,@Update_Time,@Update_User_Id,0,0,0,@Sort)";
            if (db.Execute(sqlCommandText, model, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }

        /// <summary>
        /// 批量新增特码明细信息
        /// </summary>
        /// <param name="array"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private StandardResult AddOrderTMDetails(List<OrderTM> array, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            string sqlCommandText = "Insert into t_orders_tm(id,orderId,sort,childtype,code,odds,inmoney,outmoney,status,remarks) " +
                "values(@Id,@OrderId,@Sort,@ChildType,@Code,@Odds,@InMoney,0,0,@Remarks)";
            if (db.Execute(sqlCommandText, array, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }

        /// <summary>
        /// 批量新增连肖连码明细信息
        /// </summary>
        /// <param name="array"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private StandardResult AddOrderLXLMDetails(List<OrderLXLM> array, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            string sqlCommandText = "Insert into t_orders_lxlm(id,orderId,sort,childtype,code1,zodiac1,code2,zodiac2,code3,zodiac3,code4,zodiac4,code5,zodiac5,odds,inmoney,outmoney,minoutmoney,maxoutmoney,minodds,maxodds,remarks,status) " +
                "values(@Id,@OrderId,@Sort,@ChildType,@Code1,@Zodiac1,@Code2,@Zodiac2,@Code3,@Zodiac3,@Code4,@Zodiac4,@Code5,@Zodiac5,@Odds,@InMoney,0,@MinOutMoney,@MaxOutMoney,@MinOdds,@MaxOdds,@Remarks,0)";
            if (db.Execute(sqlCommandText, array, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }

        public StandardResult<List<OrderView>> GetList(OrderSearch search = null)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = new StandardResult<List<OrderView>>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder("select * from view_orders where 1=1");
                if (search != null)
                {
                    if (!string.IsNullOrWhiteSpace(search.Issue))
                    {
                        sqlCommonText.Append(" and issue=@Issue");
                    }
                    if (search.OrderType != 0)
                    {
                        sqlCommonText.Append(" and ORDER_TYPE=@OrderType");
                    }
                    if (search.CustomerId != 0)
                    {
                        sqlCommonText.Append(" and CustomerId=@CustomerId");
                    }
                }
                var list = db.Query<OrderView>(sqlCommonText.ToString(), search);
                result.Body = list.ToList();
                return result;
            }
        }

        public StandardResult<bool> DeleteOrder(string orderId)
        {
            var result = new StandardResult<bool>();
            using (var db = base.NewDB())
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();
                try
                {

                    string sqlCommandText = "delete FROM  t_orders where id=@Id";
                    if (db.Execute(sqlCommandText, new { Id = orderId }, trans) <= 0)
                    {
                        result.Code = 1;
                        result.Msg = "失败";
                    }

                    string sqlCommandText1 = "delete FROM  t_orders_tm where orderid=@Id";
                    if (db.Execute(sqlCommandText1, new { Id = orderId }, trans) <= 0)
                    {
                        result.Code = 1;
                        result.Msg = "失败";
                    }

                    string sqlCommandText2 = "delete FROM  t_orders_lxlm where orderid=@Id";
                    if (db.Execute(sqlCommandText2, new { Id = orderId }, trans) <= 0)
                    {
                        result.Code = 1;
                        result.Msg = "失败";
                    }
                    result.Body = true;

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    result.Body = false;
                    trans.Rollback();
                }
            }
            return result;
        }

        public StandardResult<OrderView> GetModel(string id)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = new StandardResult<OrderView>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder("select * from view_orders where id=@Id");
                result.Body = db.Query<OrderView>(sqlCommonText.ToString(), new { Id = id }).FirstOrDefault();
                return result;

            }
        }

        public StandardResult<List<OrderTM>> GetOrderTMList(string orderId)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = new StandardResult<List<OrderTM>>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder("select * from t_orders_tm where orderid=@OrderId");
                result.Body = db.Query<OrderTM>(sqlCommonText.ToString(), new { OrderId = orderId }).ToList();
                return result;

            }
        }

        public StandardResult<List<OrderLXLM>> GetOrderLXLMList(string orderId)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = new StandardResult<List<OrderLXLM>>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder("select * from t_orders_lxlm where orderid=@OrderId");
                result.Body = db.Query<OrderLXLM>(sqlCommonText.ToString(), new { OrderId = orderId }).ToList();
                return result;

            }
        }

        public StandardResult<List<OrderTJ>> GetTJ(int cid, string issue, string code, int flag = 1)
        {
            var result = new StandardResult<List<OrderTJ>>();
            using (var db = base.NewDB(flag))
            {
                StringBuilder sqlCommonText = new StringBuilder(@"select a.issue,b.code,sum(b.inmoney) as money from t_orders as a INNER JOIN t_orders_tm as b on a.id=b.orderId and a.order_type=1 
where a.issue = @Issue ");
                if (cid != 0)
                {
                    sqlCommonText.Append(" and  a.customer_id=@cid ");
                }
                if (!string.IsNullOrWhiteSpace(code))
                {
                    sqlCommonText.Append(" and  b.code=@Code ");
                }
                sqlCommonText.Append(" group by a.issue, b.code order by money desc");

                result.Body = db.Query<OrderTJ>(sqlCommonText.ToString(), new { Issue = issue, cid = cid, Code = code }).ToList();
                result.Body.ForEach(x =>
                {
                    x.Code2 = x.Code;
                    x.Code = x.Code + "\n" + ServiceNum.GetNumsArray().FirstOrDefault(P => P.Value == x.Code).Zodiac;

                });
                result.Code = 0;
                return result;
            }
        }

        public StandardResult SetCheck(string orderId)
        {
            var result = new StandardResult();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder(@"update t_orders set ischeck=1 where id=@OrderId");

                if (db.Execute(sqlCommonText.ToString(), new { OrderId = orderId }) > 0)
                {
                    result.Code = 0;
                }
                else
                {
                    result.Code = 1;
                }
            }
            return result;

        }

        public StandardResult<int> GetMaxIndex(string cid, string issue)
        {
            var result = new StandardResult<int>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder(@"select ifnull(max(sort),0) from t_orders where customer_id=@cid and issue=@Issue ");
                result.Body = db.Query<int>(sqlCommonText.ToString(), new { Issue = issue, cid = cid }).FirstOrDefault();

                result.Body = result.Body + 1;

            }
            return result;
        }

    }
}