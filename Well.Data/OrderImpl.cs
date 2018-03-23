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
        public StandardResult AddOrderTM(Order<OrderTM> model)
        {
            var result = new StandardResult();
            using (var db = base.NewDB())
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

        public StandardResult AddOrderLXLM(Order<OrderLXLM> model)
        {
            var result = new StandardResult();
            using (var db = base.NewDB())
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
            string sqlCommandText = "Insert into t_orders(id,order_no,issue,order_type,customer_id,total_in_money,total_out_money,create_time,create_user_id,update_time,update_user_id,isdel) " +
                "values(@Id,@Order_No,@Issue,@Order_Type,@Customer_Id,@Total_In_Money,@Total_Out_Money,@Create_Time,@Create_User_Id,@Update_Time,@Update_User_Id,0)";
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
            string sqlCommandText = "Insert into t_orders_tm(id,orderId,code,odds,inmoney,outmoney,status) " +
                "values(@Id,@OrderId,@Code,@Odds,@InMoney,@OutMoney,@Status)";
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
            string sqlCommandText = "Insert into t_orders_lxlm(id,orderId,code1,zodiac1,code2,zodiac2,code3,zodiac3,code4,zodiac4,code5,zodiac5,odds,inmoney,outmoney,minoutmoney,maxoutmoney,minodds,maxodds,remarks,status) " +
                "values(@Id,@OrderId,@Code1,@Zodiac1,@Code2,@Zodiac2,@Code3,@Zodiac3,@Code4,@Zodiac4,@Code5,@Zodiac5,@Odds,@InMoney,@OutMoney,@MinOutMoney,@MaxOutMoney,@MinOdds,@MaxOdds,@Remarks,@Status)";
            if (db.Execute(sqlCommandText, array, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }

    }
}
