
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


        public StandardResult<List<Total>> GetTotalList()
        {
            var result = new StandardResult<List<Total>>();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommonText = new StringBuilder("select a.*,b.name as customername from t_total as a inner JOIN t_customers as b ON a.customerId=b.Id where 1=1 ");

                result.Body = db.Query<Total>(sqlCommonText.ToString(), null).ToList();

            }
            return result;
        }
    }
}