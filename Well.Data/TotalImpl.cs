
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

        public StandardResult Add(string issue)
        {
            var result = new StandardResult();
            using (var db = base.NewDB())
            {
                db.Execute("delete from t_total_details where issue=@Issue", new { Issue = issue });

                string sql_TM = @"insert into t_total_details(issue, ordertype, Inmoney, outmoney, returnmoney, customerId) 
SELECT
	issue,
order_type,
total_in_money,
total_out_money,
(case order_type
	when 1 THEN
	total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=11)
	when 2 THEN
	total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and (t_odds.ordertype=22 or t_odds.ordertype=23 or t_odds.ordertype=24 or t_odds.ordertype=25))
	when 3 THEN 
  total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=3)
	when 4 THEN 
  total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=41)
when 5 THEN 
  total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=51)
when 6 THEN 
  total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=7)
when 7 THEN 
  total_in_money*(select return_pl from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=7)
END
) as tt,
customer_id
FROM
	(
		SELECT
			a.issue,
			a.order_type,
			ifnull(sum(a.total_in_money), 0) AS total_in_money,
			ifnull(sum(a.total_out_money), 0) AS total_out_money,
			a.customer_id
		FROM
			t_orders AS a
		INNER JOIN t_customers AS c ON a.customer_id = c.id
		WHERE
			a.issue = @Issue
		GROUP BY
			a.issue,
			a.order_type,
			a.customer_id
	) AS tb";

                db.Execute(sql_TM, new { Issue = issue });

                return result;
            }
        }


        public StandardResult<List<TotalDetails>> GetTotalDetailsList(OrderSearch search = null)
        {
            var result = new StandardResult<List<TotalDetails>>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder();
                sqlCommonText.Append(@"SELECT
        a.id,
        a.issue,
        a.ordertype,
        (
            CASE a.ordertype

            WHEN 1 THEN

                '特码'

            WHEN 2 THEN

                '连肖'

            WHEN 3 THEN

                '连码'

            WHEN 4 THEN

                '一肖'

            WHEN 5 THEN

                '特尾'

            ELSE

                '其他'

            END
        ) AS ordertypename,
        a.inmoney,
		a.outmoney,
		a.returnmoney,
		a.customerId,
		b.name AS customername,
        (a.inmoney-a.outmoney-a.returnmoney) as total
    FROM
        t_total_details AS a
    INNER JOIN t_customers AS b ON a.customerId = b.Id
    WHERE
        1 = 1 ");

                if (search != null)
                {
                    if (search.CustomerId != 0)
                    {
                        sqlCommonText.Append(" and a.customerid=@CustomerId");
                    }
                    if (!string.IsNullOrWhiteSpace(search.Issue))
                    {
                        sqlCommonText.Append(" and a.issue==@Issue");
                    }
                }

                result.Body = db.Query<TotalDetails>(sqlCommonText.ToString(), search).ToList();

            }
            return result;
        }

        public StandardResult<List<TotalDetails>> GetTotalList(OrderSearch search = null)
        {
            var result = new StandardResult<List<TotalDetails>>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder();
                sqlCommonText.Append(@"select *,(inmoney - outmoney - returnmoney) as total from(
                 SELECT
                
                        a.issue,
                        sum(a.inmoney) AS inmoney,
                        sum(a.outmoney) AS outmoney,
                        sum(a.returnmoney) AS returnmoney,
                        a.customerId,
                        b.name AS customername
                
                    FROM
                
                        t_total_details AS a
                
                    INNER JOIN t_customers AS b ON a.customerId = b.Id
                
                    WHERE
                
                        1 = 1 ");



                if (search != null)
                {
                    if (search.CustomerId != 0)
                    {
                        sqlCommonText.Append(" and a.customerid=@CustomerId");
                    }
                    if (!string.IsNullOrWhiteSpace(search.Issue))
                    {
                        sqlCommonText.Append(" and a.issue=@Issue");
                    }
                }
                sqlCommonText.Append(@" GROUP BY
                        a.issue,
                        a.customerid) as tb");

                result.Body = db.Query<TotalDetails>(sqlCommonText.ToString(), search).ToList();

            }
            return result;

        }
    }
}