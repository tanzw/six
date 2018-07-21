
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
	a.issue,
	a.order_type,
	ifnull(sum(b.inmoney), 0) AS total_in_money,
	ifnull(sum(b.outmoney), 0) AS total_out_money,
	ifnull(sum(b.inmoney), 0) * d.fs,
	a.customer_id
FROM
	t_orders AS a
INNER JOIN t_orders_tm AS b ON a.id = b.orderId
INNER JOIN t_customers AS c ON a.customer_id = c.id
INNER JOIN t_odds AS d ON d.customerId = a.customer_id
AND d.childtype = b.childtype
WHERE
	a.issue = @Issue
GROUP BY
	a.issue,
	a.order_type,
	a.customer_id";



                //SELECT
                //	issue,
                //order_type,
                //total_in_money,
                //total_out_money,
                //(case order_type
                //	when 1 THEN
                //	total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and t_odds.childtype=11)
                //	when 2 THEN
                //	total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and (t_odds.childtype=22 or t_odds.childtype=23 or t_odds.childtype=24 or t_odds.childtype=25))
                //	when 3 THEN 
                //  total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=3)
                //	when 4 THEN 
                //  total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=41)
                //when 5 THEN 
                //  total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=51)
                //when 6 THEN 
                //  total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=7)
                //when 7 THEN 
                //  total_in_money*(select fs from t_odds where t_odds.customerId=tb.customer_id and t_odds.ordertype=7)
                //END
                //) as tt,
                //customer_id
                //FROM
                //	(
                //		SELECT
                //			a.issue,
                //			a.order_type,
                //			ifnull(sum(a.total_in_money), 0) AS total_in_money,
                //			ifnull(sum(a.total_out_money), 0) AS total_out_money,
                //			a.customer_id
                //		FROM
                //			t_orders AS a
                //		INNER JOIN t_customers AS c ON a.customer_id = c.id
                //		WHERE
                //			a.issue = @Issue
                //		GROUP BY
                //			a.issue,
                //			a.order_type,
                //			a.customer_id
                //	) AS tb";

                db.Execute(sql_TM, new { Issue = issue });

                sql_TM = @"insert into t_total_details(issue, ordertype, Inmoney, outmoney, returnmoney, customerId) 
SELECT
	a.issue,
	a.order_type,
	ifnull(sum(b.inmoney), 0) AS total_in_money,
	ifnull(sum(b.outmoney), 0) AS total_out_money,
	ifnull(sum(b.inmoney), 0) * d.fs,
	a.customer_id
FROM
	t_orders AS a
INNER JOIN t_orders_lxlm AS b ON a.id = b.orderId
INNER JOIN t_customers AS c ON a.customer_id = c.id
INNER JOIN t_odds AS d ON d.customerId = a.customer_id
AND d.childtype = b.childtype
WHERE
	a.issue = @Issue
GROUP BY
	a.issue,
	a.order_type,
	a.customer_id";
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

                '尾数'

            WHEN 6 THEN

                '波色'
            
            WHEN 7 THEN

                '大小单双'

            WHEN 8 THEN

                '合肖'
            
            WHEN 9 THEN

                '全不中'
        
            WHEN 10 THEN

                '单平'
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

        public StandardResult<List<OrderResult>> GetOrderResult(OrderSearch search = null)
        {
            var result = new StandardResult<List<OrderResult>>();
            using (var db = base.NewDB())
            {
                result.Body = db.Query<OrderResult>(@"SELECT
	order_type,
	(
		CASE order_type
		WHEN 1 THEN
			'特'
		WHEN 2 THEN
			'平'
		WHEN 4 THEN
			'平'
		ELSE
			'其他'
		END
	) AS ordertypename,
	sort,
	sum(total_in_money) as Money
FROM
	t_orders
WHERE
	customer_id = 16
AND issue = @Issue
GROUP BY
	order_type,
	sort order by sort asc", new { Issue = search.Issue }).ToList();
            }

            return result;
        }
    }
}