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

        public decimal Return_PL { get; set; }

        public string strJson { get; set; }

    }
    public class Odds
    {
        public decimal Return_PL { get; set; }
    }

    public class TMOdds : Odds
    {
        public decimal Num_PL { get; set; }


    }

    public class LXOdds : Odds
    {
        public Dictionary<int, decimal> List { get; set; }


    }

    public class LMOdds : Odds
    {
        public decimal SZE { get; set; }

        public decimal SZS { get; set; }

        public decimal SQZ { get; set; }

        public decimal EQZ { get; set; }

        public decimal TP { get; set; }

        public decimal SIZHONGSI { get; set; }

    }

    public class PTYXOdds : Odds
    {
        public Dictionary<int, decimal> List { get; set; }


    }

    public class BSOdds : Odds
    {
        public Dictionary<int, decimal> List { get; set; }
    }

    public class WSOdds : Odds
    {
        public Dictionary<int, decimal> List { get; set; }

    }


}
