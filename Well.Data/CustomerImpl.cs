using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using Well.Common.Result;
using Well.Model;

namespace Well.Data
{
    public class CustomerImpl : DataBase
    {
        public StandardResult Add(Customers model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "Insert into t_customers(Name,Phone,IsDel,Remarks) values(@Name,@Phone,@IsDel,@Remarks)";
                if (db.Execute(sqlCommandText, model) > 0)
                {
                    result.Code = 0;
                    result.Msg = "成功";
                }
                else
                {
                    result.Code = 1;
                    result.Msg = "失败";
                }
                return result;
            }
        }

        public StandardResult Update(Customers model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                try
                {
                    string sqlCommandText = "Update t_customers set name=@Name,phone=@Phone,isdel=@IsDel,remarks=@Remarks where id=@Id";
                    if (db.Execute(sqlCommandText, model) > 0)
                    {
                        result.Code = 0;
                        result.Msg = "成功";
                    }
                    else
                    {
                        result.Code = 1;
                        result.Msg = "失败";
                    }
                }
                catch (Exception ex)
                {
                    result.Code = 1;
                    result.Msg = ex.Message;
                }

                return result;
            }
        }

        public StandardResult LogicDel(Customers model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "Update t_customers set  isdel=1 where id=@Id";
                if (db.Execute(sqlCommandText, model) > 0)
                {
                    result.Code = 0;
                    result.Msg = "成功";
                }
                else
                {
                    result.Code = 1;
                    result.Msg = "失败";
                }
                return result;
            }
        }

        public StandardResult<Customers> GetModel(Customers model)
        {
            StandardResult<Customers> result = new StandardResult<Customers>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select *  from t_customers where id=@Id";
                result.Body = db.Query<Customers>(sqlCommandText, model).FirstOrDefault();
                return result;
            }
        }

        public StandardResult<List<Customers>> GetList(Customers model)
        {
            StandardResult<List<Customers>> result = new StandardResult<List<Customers>>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select *  from t_customers where isdel=@IsDel";
                result.Body = db.Query<Customers>(sqlCommandText, model).AsList();
                return result;
            }
        }


    }
}
