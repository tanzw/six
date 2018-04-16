
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
select a.issue,a.order_type,sum(a.total_in_money),sum(a.total_out_money),sum(a.total_in_money)*b.return_pl,a.customer_id from t_orders AS a  INNER JOIN t_odds as b on a.customer_id=b.customerId and a.child_type=b.ordertype
INNER JOIN t_customers as c on a.customer_id=c.id  where a.issue=@Issue
group by a.issue,a.order_type,a.customer_id";

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