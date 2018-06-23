using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Model
{
    public class OrderMain
    {
        public string Id { get; set; }

        public string Order_No { get; set; }

        public string Issue { get; set; }

        public int Order_Type { get; set; }

        public int Child_Type { get; set; }

        public int Customer_Id { get; set; }

        public decimal Total_In_Money { get; set; }

        public decimal Total_Out_Money { get; set; }

        public string Create_Time { get; set; }

        public string Create_User_Id { get; set; }

        public string Update_Time { get; set; }

        public string Update_User_Id { get; set; }

        public int IsDel { get; set; }
    }

    public class Order<T> : OrderMain
    {
        public Order()
        {
            OrderDetails = new List<T>();
        }
        public List<T> OrderDetails { get; set; }
    }

    public class OrderTM
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

        public int ChildType { get; set; }

        public string Code { get; set; }

        public decimal Odds { get; set; }

        public decimal InMoney { get; set; }

        public decimal OutMoney { get; set; }

        public int Status { get; set; }

        public int Flag { get; set; }

        public string Remarks { get; set; }

        public int Sort { get; set; }
    }

    public class OrderLXLM
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

        public int ChildType { get; set; }

        public string Code1 { get; set; }

        public string Zodiac1 { get; set; }

        public string Code2 { get; set; }

        public string Zodiac2 { get; set; }

        public string Code3 { get; set; }

        public string Zodiac3 { get; set; }

        public string Code4 { get; set; }

        public string Zodiac4 { get; set; }

        public string Code5 { get; set; }

        public string Zodiac5 { get; set; }

        public decimal Odds { get; set; }

        public decimal InMoney { get; set; }

        public decimal OutMoney { get; set; }

        public decimal MinOutMoney { get; set; }

        public decimal MaxOutMoney { get; set; }

        public decimal MinOdds { get; set; }

        public decimal MaxOdds { get; set; }

        public string Remarks { get; set; }
        public int Status { get; set; }

        /// <summary>
        /// UI使用,确认订单 0、未选中1、已选中
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// UI使用,序号
        /// </summary>
        public int Sort { get; set; }
    }

    public class OrderView
    {
        public string Id { get; set; }
        public string Order_No { get; set; }

        public string Issue { get; set; }

        public int OrderType { get; set; }

        public string OrderTypeName { get; set; }
        public string ChildType { get; set; }

        public string ChildTypeName { get; set; }

        public string Total_In_Money { get; set; }

        public string Total_Out_Money { get; set; }

        public string CreateTime { get; set; }

        public string Status { get; set; }

        public string StatusName { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int ischeck { get; set; }
        public string ischeckname { get; set; }



        //select a.id, a.order_no, a.issue,a.order_type,(CASE a.order_type WHEN 1 THEN '特码' WHEN 12 THEN '二连肖' WHEN 13 then '三连肖' WHEN 14 THEN '四连肖' WHEN 15 THEN '五连肖' END) as ordertypename,a.total_in_money,a.total_out_money,a.create_time,a.create_user_id,(CASE a.status WHEN 0 THEN '未开奖' WHEN 1 THEN '已中奖' WHEN 2 THEN '未中奖' ELSE '未知' END) as statusname,a.status,b.id as CustomerId, b.name as CustomerName from t_orders as a INNER JOIN t_customers as b ON a.customer_id=b.id order by a.create_time DESC
    }

    public class OrderSearch
    {
        public string Issue { get; set; }

        public int OrderType { get; set; }

        public int CustomerId { get; set; }
    }

    public class OrderTJ
    {
        public string Issue { get; set; }

        public string Code { get; set; }

        public decimal Money { get; set; }

        public string Code2 { get; set; }
    }
}
