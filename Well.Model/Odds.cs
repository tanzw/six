using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Model
{
    public class OddsData
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int OrderType { get; set; }

        public int ChildType { get; set; }

        /// <summary>
        /// 返水
        /// </summary>
        public decimal FS { get; set; }
        /// <summary>
        /// 赔率
        /// </summary>
        public decimal PL { get; set; }

        public decimal Return_PL { get; set; }

        public string strJson { get; set; }

        public string Remarks { get; set; }

    }

    public class TMOdds
    {
        public decimal Num_PL { get; set; }


    }

    public class LXOdds
    {
        public Dictionary<int, decimal> List { get; set; }


    }

    public class LMOdds
    {
        public decimal SZE { get; set; }

        public decimal SZS { get; set; }

        public decimal SQZ { get; set; }

        public decimal EQZ { get; set; }

        public decimal TP { get; set; }

        public decimal SIZHONGSI { get; set; }

    }

    public class PTYXOdds
    {
        public Dictionary<int, decimal> List { get; set; }


    }

    public class BSOdds
    {
        public Dictionary<int, decimal> List { get; set; }
    }

    public class WSOdds
    {
        public Dictionary<int, decimal> List { get; set; }

    }


}
