using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Model
{
    public class Total
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Issue { get; set; }

        public decimal InMoney { get; set; }

        public decimal OutMoney { get; set; }

        public decimal ReturnMoney { get; set; }

        public string CustomerName { get; set; }
    }

    public class TotalDetails
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string Issue { get; set; }


        public int TotalId { get; set; }

        public int OrderType { get; set; }

        public decimal InMoney { get; set; }

        public decimal OutMoney { get; set; }

        public decimal ReturnMoney { get; set; }

        public string OrderTypeName { get; set; }

        public string CustomerName { get; set; }

        public int total { get; set; }
    }

    public class OrderResult
    {
        public int Sort { get; set; }

        public string OrderTypeName { get; set; }

        public decimal Money { get; set; }
    }
}
