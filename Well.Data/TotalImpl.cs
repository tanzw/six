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
    public class TotalImpl : DataBase
    {
        //public StandardResult Add(string issue)
        //{
        //    using (var db = base.NewDB())
        //    {
        //        string totalId = Guid.NewGuid().ToString("n");
        //        string sql_TM = @"insert into t_total_details(totalId, ordertype, Inmoney, outmoney, returnmoney, customerId) SELECT
	       //                         @totalId,
	       //                         a.order_type,
	       //                         sum(b.inmoney),
	       //                         sum(b.outmoney) , 	sum(b.inmoney)*c.return_pl,
	       //                         a.customer_id
        //                        FROM
	       //                         t_orders AS a
        //                        INNER JOIN t_orders_tm AS b ON a.id = b.orderid
        //                        INNER JOIN t_odds as c on a.customer_id=c.customerId and a.order_type=c.ordertype
        //                        WHERE
	       //                         a.issue = @Issue
        //                        GROUP BY
	       //                         a.issue,
	       //                         a.customer_id,
	       //                         a.order_type,
	       //                         c.return_pl";

        //        db.Execute(sql_TM, new { totalId = totalId, Issue = issue });


        //        string sql_lxlm = @"insert into t_total_details(totalId, ordertype, Inmoney, outmoney, returnmoney, customerId) SELECT
	       //                         @totalId,
	       //                         a.order_type,
	       //                         sum(b.inmoney),
	       //                         sum(b.outmoney) , 	sum(b.inmoney)*c.return_pl,
	       //                         a.customer_id
        //                        FROM
	       //                         t_orders AS a
        //                        INNER JOIN t_orders_tm AS b ON a.id = b.orderid
        //                        INNER JOIN t_odds as c on a.customer_id=c.customerId and a.order_type=c.ordertype
        //                        WHERE
	       //                         a.issue = '2018035'
        //                        GROUP BY
	       //                         a.issue,
	       //                         a.customer_id,
	       //                         a.order_type,
	       //                         c.return_pl";
        //    }
        //}
    }
}
