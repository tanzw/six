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
    public class OddsImpl : DataBase
    {
        public StandardResult Add(List<OddsData> list)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = new StandardResult();
            using (var db = base.NewDB())
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();
                try
                {

                    string sqlCommandText = "Insert into t_odds(customerId,ordertype,return_pl,strJson) values(@CustomerId,@OrderType,@Return_PL,@strJson)";
                    foreach (var item in list)
                    {
                        string q = " select id from t_odds where customerId=@CustomerId and ordertype=@OrderType";
                        var id = db.ExecuteScalar<int>(q, item, trans);
                        if (id > 0)
                        {
                            sqlCommandText = "update t_odds set return_pl=@Return_PL,strJson=@strJson where id=@Id";
                            item.Id = id;
                        }

                        if (db.Execute(sqlCommandText, item, trans) <= 0)
                        {
                            throw new Exception("添加客户赔率失败");
                        }
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    result.Code = 1;
                    result.Msg = "失败";
                    trans.Rollback();
                }
            }
            return result;

        }

        public StandardResult<List<OddsData>> GetList(int cid)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = new StandardResult<List<OddsData>>();
            using (var db = base.NewDB())
            {
                var list = db.Query<OddsData>("select * from t_odds where customerId=@CustomerId", new { CustomerId = cid });
                result.Body = list.ToList();
                return result;
            }
        }
    }
}
