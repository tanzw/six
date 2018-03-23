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

        public string Code { get; set; }

        public decimal Odds { get; set; }

        public decimal InMoney { get; set; }

        public decimal OutMoney { get; set; }

        public int Status { get; set; }
    }

    public class OrderLXLM
    {
        public string Id { get; set; }

        public string OrderId { get; set; }

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
        public int Index { get; set; }
    }
}
