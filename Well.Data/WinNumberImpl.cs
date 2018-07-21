using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using Well.Common.Result;
using Well.Model;
using Well.Common.Extensions;
using System.Data;
using System.Drawing;

namespace Well.Data
{
    public class WinNumberImpl : DataBase
    {
        public StandardResult Add(WinNumber model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "Insert into t_winnumbers(issue,num1_code,num1_zodiac,num2_code,num2_zodiac,num3_code,num3_zodiac,num4_code,num4_zodiac,num5_code,num5_zodiac,num6_code,num6_zodiac,num7_code,num7_zodiac,create_time,create_user_id,upadte_time,update_user_id)" +
                    " values(@Issue,@Num1_Code,@Num1_Zodiac,@Num2_Code,@Num2_Zodiac,@Num3_Code,@Num3_Zodiac,@Num4_Code,@Num4_Zodiac,@Num5_Code,@Num5_Zodiac,@Num6_Code,@Num6_Zodiac,@Num7_Code,@Num7_Zodiac,@Create_Time,@Create_User_Id,@Update_Time,@Update_User_Id)";
                if (db.Execute(sqlCommandText, model) <= 0)
                {
                    result.Code = 1;
                    result.Msg = "失败";
                }
                return result;
            }
        }

        public StandardResult Update(WinNumber model)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                StringBuilder sqlCommandText = new StringBuilder();
                sqlCommandText.Append("Update t_winnumbers set ");
                sqlCommandText.Append(" issue=@Issue,");
                sqlCommandText.Append(" num1_code=@Num1_Code,");
                sqlCommandText.Append(" num1_zodiac=@Num1_Zodiac,");
                sqlCommandText.Append(" num2_code=@Num2_Code,");
                sqlCommandText.Append(" num2_zodiac=@Num2_Zodiac,");
                sqlCommandText.Append(" num3_code=@Num3_Code,");
                sqlCommandText.Append(" num3_zodiac=@Num3_Zodiac,");
                sqlCommandText.Append(" num4_code=@Num4_Code,");
                sqlCommandText.Append(" num4_zodiac=@Num4_Zodiac,");
                sqlCommandText.Append(" num5_code=@Num5_Code,");
                sqlCommandText.Append(" num5_zodiac=@Num5_Zodiac,");
                sqlCommandText.Append(" num6_code=@Num6_Code,");
                sqlCommandText.Append(" num6_zodiac=@Num6_Zodiac,");
                sqlCommandText.Append(" num7_code=@Num7_Code,");
                sqlCommandText.Append(" num7_zodiac=@Num7_Zodiac,");
                sqlCommandText.Append(" upadte_time=@Update_Time,");
                sqlCommandText.Append(" update_user_id=@Update_User_Id");
                sqlCommandText.Append(" where id = @Id");

                if (db.Execute(sqlCommandText.ToString(), model) <= 0)
                {
                    result.Code = 1;
                    result.Msg = "失败";
                }
                return result;
            }
        }

        public StandardResult<string> GetNewIssue(bool isLast = false)
        {
            var result = new StandardResult<string>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select max(issue)  from t_winnumbers  ";
                var obj = db.ExecuteScalar(sqlCommandText, null);
                if (obj != null && obj != DBNull.Value)
                {
                    if (isLast)
                    {
                        result.Body = obj.ToString();
                    }
                    else
                    {
                        var issue = obj.ToTryInt();
                        if (obj.ToString().Substring(0, 4) == DateTime.Now.Year.ToString())
                        {
                            result.Body = (issue + 1).ToString();
                        }
                        else
                        {
                            result.Body = DateTime.Now.Year + "001";
                        }
                    }
                }
                else
                {
                    result.Body = "";
                    result.Code = 1;
                    result.Msg = "没有获取到数据";
                }
            }
            return result;
        }

        public StandardResult<WinNumber> GetModel(WinNumber model)
        {
            StandardResult<WinNumber> result = new StandardResult<WinNumber>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select *  from t_winnumbers where ";
                if (model.Id != 0)
                {
                    sqlCommandText += " id=@Id";
                }
                else if (!string.IsNullOrWhiteSpace(model.Issue))
                {
                    sqlCommandText += " issue=@Issue";
                }
                result.Body = db.Query<WinNumber>(sqlCommandText, model).FirstOrDefault();


                return result;
            }
        }

        public StandardResult<List<WinNumber>> GetList(WinNumber model)
        {
            StandardResult<List<WinNumber>> result = new StandardResult<List<WinNumber>>();
            using (var db = base.NewDB())
            {
                string sqlCommandText = "select *  from t_winnumbers  order by issue desc";
                result.Body = db.Query<WinNumber>(sqlCommandText, model).AsList();

                foreach (var item in result.Body)
                {
                    item.Display1 = item.Num1_Code + "\n" + item.Num1_Zodiac;
                    item.Display2 = item.Num2_Code + "\n" + item.Num2_Zodiac;
                    item.Display3 = item.Num3_Code + "\n" + item.Num3_Zodiac;
                    item.Display4 = item.Num4_Code + "\n" + item.Num4_Zodiac;
                    item.Display5 = item.Num5_Code + "\n" + item.Num5_Zodiac;
                    item.Display6 = item.Num6_Code + "\n" + item.Num6_Zodiac;
                    item.Display7 = item.Num7_Code + "\n" + item.Num7_Zodiac;
                    item.Create_Time = string.IsNullOrWhiteSpace(item.Create_Time) ? "" : DateTime.Parse(item.Create_Time).ToString("yyyy-MM-dd");
                }
                return result;
            }
        }

        #region 开奖
        public StandardResult Run(string issue)
        {
            var result = new StandardResult();
            var l1 = GetOrderTMList(issue);
            var l2 = GetOrderLXLMList(issue);
            var model = GetModel(new WinNumber() { Issue = issue });
            using (var db = base.NewDB())
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();

                var tempList = new List<string>();
                var green = Color.LimeGreen;
                var red = Color.Red;
                var blue = Color.Blue;
                int sum = 0;//计算合数变量
                int num = 0;//计算合数变量
                try
                {
                    var orderMainStatus = (int)ResultStatus.Lose;
                    foreach (var item in l1)
                    {
                        orderMainStatus = (int)ResultStatus.Lose;
                        foreach (var detail in item.OrderDetails)
                        {
                            var v = 0;
                            switch (detail.ChildType)
                            {
                                case (int)ChildType.特码:
                                    if (detail.Code == model.Body.Num7_Code)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.平特:
                                    if (detail.Code == model.Body.Num1_Zodiac || detail.Code == model.Body.Num2_Zodiac || detail.Code == model.Body.Num3_Zodiac || detail.Code == model.Body.Num4_Zodiac || detail.Code == model.Body.Num5_Zodiac || detail.Code == model.Body.Num6_Zodiac || detail.Code == model.Body.Num7_Zodiac)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.尾数:
                                    if (detail.Code == model.Body.Num7_Code.Substring(model.Body.Num7_Code.Length - 1, 1) ||
                                        detail.Code == model.Body.Num6_Code.Substring(model.Body.Num6_Code.Length - 1, 1) ||
                                        detail.Code == model.Body.Num5_Code.Substring(model.Body.Num5_Code.Length - 1, 1) ||
                                        detail.Code == model.Body.Num4_Code.Substring(model.Body.Num4_Code.Length - 1, 1) ||
                                        detail.Code == model.Body.Num3_Code.Substring(model.Body.Num3_Code.Length - 1, 1) ||
                                        detail.Code == model.Body.Num2_Code.Substring(model.Body.Num2_Code.Length - 1, 1) ||
                                        detail.Code == model.Body.Num1_Code.Substring(model.Body.Num1_Code.Length - 1, 1)
                                        )
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.二肖:
                                case (int)ChildType.三肖:
                                case (int)ChildType.四肖:
                                case (int)ChildType.五肖:
                                case (int)ChildType.六肖:
                                    if (detail.Code.Contains(model.Body.Num7_Zodiac))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.五不中:
                                case (int)ChildType.六不中:
                                case (int)ChildType.七不中:
                                case (int)ChildType.八不中:
                                case (int)ChildType.九不中:
                                case (int)ChildType.十不中:
                                    if (detail.Code.Contains(model.Body.Num1_Code) ||
                                        detail.Code.Contains(model.Body.Num2_Code) ||
                                        detail.Code.Contains(model.Body.Num3_Code) ||
                                        detail.Code.Contains(model.Body.Num4_Code) ||
                                        detail.Code.Contains(model.Body.Num5_Code) ||
                                        detail.Code.Contains(model.Body.Num6_Code) ||
                                        detail.Code.Contains(model.Body.Num7_Code))
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    break;
                                case (int)ChildType.单平:
                                    if (detail.Code == model.Body.Num1_Code ||
                                      detail.Code == model.Body.Num2_Code ||
                                      detail.Code == model.Body.Num3_Code ||
                                      detail.Code == model.Body.Num4_Code ||
                                      detail.Code == model.Body.Num5_Code ||
                                      detail.Code == model.Body.Num6_Code)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                #region 波色
                                case (int)ChildType.红波:
                                    if (ServiceNum.GetNumColor(model.Body.Num7_Code.ToTryInt()) == red)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿波:
                                    if (ServiceNum.GetNumColor(model.Body.Num7_Code.ToTryInt()) == green)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝波:
                                    if (ServiceNum.GetNumColor(model.Body.Num7_Code.ToTryInt()) == blue)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                #endregion

                                #region 半波--红波

                                case (int)ChildType.红大:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红小:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v % 2 != 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v % 2 == 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红大单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v % 2 != 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红小单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v % 2 != 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红大双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v % 2 == 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.红小双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == red && v % 2 == 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                #endregion

                                #region 半波--绿波

                                case (int)ChildType.绿大:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿小:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v % 2 != 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v % 2 == 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿大单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v % 2 != 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿小单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v % 2 != 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿大双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v % 2 == 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.绿小双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == green && v % 2 == 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                #endregion

                                #region 半波--蓝波

                                case (int)ChildType.蓝大:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝小:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v % 2 != 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v % 2 == 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝大单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v % 2 != 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝小单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v % 2 != 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝大双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v % 2 == 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.蓝小双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (ServiceNum.GetNumColor(v) == blue && v % 2 == 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                #endregion

                                #region 特码大小单双

                                case (int)ChildType.特大:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特小:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v % 2 != 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v % 2 == 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特大单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v % 2 != 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特小单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v % 2 != 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特大双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v % 2 == 0 && v > 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.特小双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    if (v % 2 == 0 && v <= 24)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                #endregion

                                #region 特码合大小单双

                                case (int)ChildType.合大:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }
                                    if (sum > 6)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合小:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }
                                    if (sum <= 6)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }
                                    if (sum % 2 != 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }
                                    if (sum % 2 != 0)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合大单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }

                                    if (sum % 2 != 0 && sum > 6)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合小单:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }

                                    if (sum % 2 != 0 && sum <= 6)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合大双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }
                                    if (sum % 2 == 0 && sum > 6)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.合小双:
                                    v = model.Body.Num7_Code.ToTryInt();
                                    num = v;
                                    sum = 0;
                                    while (num > 0)
                                    {
                                        sum += num % 10;//每次的余数都是末尾的数字
                                        num /= 10;//因为是INT型的所以等于直接去掉最后的数字.
                                    }
                                    if (sum % 2 == 0 && sum <= 6)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                    #endregion
                            }

                            UpdateOrderTMStatus(detail, trans);
                        }
                        UpdateOrderStatus(1, item.Id, orderMainStatus, trans);
                    }


                    foreach (var item in l2)
                    {
                        orderMainStatus = (int)ResultStatus.Lose;
                        foreach (var detail in item.OrderDetails)
                        {
                            switch (detail.ChildType)
                            {
                                case (int)ChildType.平特:
                                    if (detail.Zodiac1 == model.Body.Num1_Zodiac || detail.Zodiac1 == model.Body.Num2_Zodiac || detail.Zodiac1 == model.Body.Num3_Zodiac || detail.Zodiac1 == model.Body.Num4_Zodiac || detail.Zodiac1 == model.Body.Num5_Zodiac || detail.Zodiac1 == model.Body.Num6_Zodiac || detail.Zodiac1 == model.Body.Num7_Zodiac)
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.二连肖:
                                    if (model.Body.ZodiacList.Contains(detail.Zodiac1) && model.Body.ZodiacList.Contains(detail.Zodiac2))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.二全中:
                                    var temp = model.Body.CodeList.Take(6);
                                    if (temp.Contains(detail.Code1) && temp.Contains(detail.Code2))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.三连肖:

                                    if (model.Body.ZodiacList.Contains(detail.Zodiac1) && model.Body.ZodiacList.Contains(detail.Zodiac2) && model.Body.ZodiacList.Contains(detail.Zodiac3))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.三全中:
                                    var temp1 = model.Body.CodeList.Take(6);
                                    if (temp1.Contains(detail.Code1) && temp1.Contains(detail.Code2) && temp1.Contains(detail.Code3))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.四连肖:

                                    if (model.Body.ZodiacList.Contains(detail.Zodiac1) && model.Body.ZodiacList.Contains(detail.Zodiac2) && model.Body.ZodiacList.Contains(detail.Zodiac3) && model.Body.ZodiacList.Contains(detail.Zodiac4))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.五连肖:
                                    if (model.Body.ZodiacList.Contains(detail.Zodiac1) && model.Body.ZodiacList.Contains(detail.Zodiac2) && model.Body.ZodiacList.Contains(detail.Zodiac3) && model.Body.ZodiacList.Contains(detail.Zodiac4) && model.Body.ZodiacList.Contains(detail.Zodiac5))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                                case (int)ChildType.三中三:
                                    var temp2 = model.Body.CodeList.Take(6);
                                    if (temp2.Contains(detail.Code1) && temp2.Contains(detail.Code2) && temp2.Contains(detail.Code3))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.MaxOdds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        //需要组合的号码
                                        List<string> InCombinationList = new List<string>();

                                        InCombinationList.Add(detail.Code1);
                                        InCombinationList.Add(detail.Code2);
                                        InCombinationList.Add(detail.Code3);
                                        //生成号码组合
                                        List<string[]> ListCombination = PermutationAndCombination<string>.GetCombination(InCombinationList.ToArray(), 2); //求全部的3-3组合
                                        foreach (string[] arr in ListCombination)
                                        {
                                            if (temp2.Contains(arr[0]) && temp2.Contains(arr[1]))
                                            {
                                                detail.Status = (int)ResultStatus.Win;
                                                detail.OutMoney = detail.MinOdds * detail.InMoney;
                                                orderMainStatus = (int)ResultStatus.Win;
                                                break;
                                            }
                                            else
                                            {
                                                detail.Status = (int)ResultStatus.Lose;
                                                continue;
                                            }
                                        }
                                    }
                                    break;
                                case (int)ChildType.特碰:
                                    if (model.Body.CodeList[6] == detail.Code1 && model.Body.CodeList.Take(6).Contains(detail.Code2))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else if (model.Body.CodeList[6] == detail.Code2 && model.Body.CodeList.Take(6).Contains(detail.Code1))
                                    {
                                        detail.Status = (int)ResultStatus.Win;
                                        detail.OutMoney = detail.Odds * detail.InMoney;
                                        orderMainStatus = (int)ResultStatus.Win;
                                    }
                                    else
                                    {
                                        detail.Status = (int)ResultStatus.Lose;
                                    }
                                    break;
                            }
                            UpdateOrderLXLMStatus(detail, trans);
                        }
                        UpdateOrderStatus(2, item.Id, orderMainStatus, trans);
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Code = 1;
                    result.Msg = "失败";
                }
            }
            return result;

        }

        public StandardResult UpdateOrderMainOutMoney(string issue)
        {
            StandardResult result = new StandardResult();
            using (var db = base.NewDB())
            {
                db.Open();
                IDbTransaction trans = db.BeginTransaction();
                try
                {
                    StringBuilder sqlCommandText = new StringBuilder();
                    sqlCommandText.Append("Update t_orders set total_out_money=(select sum(outmoney) from t_orders_tm  where orderId=t_orders.id and status=1) where (order_type=1 or order_type=4 or order_type=5  ) and issue=@Issue  and status=1");

                    db.Execute(sqlCommandText.ToString(), new { Issue = issue }, trans);

                    sqlCommandText.Clear();

                    sqlCommandText.Append("Update t_orders set total_out_money=(select sum(outmoney) from t_orders_lxlm  where orderId=t_orders.id and status=1) where (order_type=2 or order_type=3) and issue=@Issue  and status=1");
                    db.Execute(sqlCommandText.ToString(), new { Issue = issue }, trans);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Code = 1;
                    result.Msg = ex.Message;
                }
            }
            return result;
        }
        private List<Order<OrderTM>> GetOrderTMList(string issue)
        {

            using (var db = base.NewDB())
            {
                List<Order<OrderTM>> result = new List<Order<OrderTM>>();

                string sqlCommandText = @"select 
                                1 as t1,
                                t_orders.*,
                                1 as t2,
                                t_orders_tm.* 
                                from t_orders inner join t_orders_tm on t_orders.id=t_orders_tm.orderid 
                                where t_orders.issue=@Issue";


                db.Query<Order<OrderTM>, OrderTM, Order<OrderTM>>(sqlCommandText,
                                    (orderMain, orderTM) =>
                                    {
                                        if (result.Count(x => x.Id == orderMain.Id) == 0)
                                        {
                                            orderMain.OrderDetails.Add(orderTM);
                                            result.Add(orderMain);
                                        }
                                        else
                                        {
                                            result.FirstOrDefault(x => x.Id == orderMain.Id).OrderDetails.Add(orderTM);
                                        }
                                        return orderMain;
                                    }, param: new { Issue = issue }, splitOn: "t1,t2").ToList();

                return result;
            }
        }

        private List<Order<OrderLXLM>> GetOrderLXLMList(string issue)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            using (var db = base.NewDB())
            {
                List<Order<OrderLXLM>> result = new List<Order<OrderLXLM>>();

                string sqlCommandText = @"select 
                                1 as t1,
                                t_orders.*,
                                1 as t2,
                                t_orders_lxlm.* 
                                from t_orders inner join t_orders_lxlm on t_orders.id=t_orders_lxlm.orderid 
                                where t_orders.issue=@Issue";

                db.Query<Order<OrderLXLM>, OrderLXLM, Order<OrderLXLM>>(sqlCommandText,
                                    (orderMain, orderLXLM) =>
                                    {
                                        if (result.Count(x => x.Id == orderMain.Id) == 0)
                                        {
                                            orderMain.OrderDetails.Add(orderLXLM);
                                            result.Add(orderMain);
                                        }
                                        else
                                        {
                                            result.FirstOrDefault(x => x.Id == orderMain.Id).OrderDetails.Add(orderLXLM);
                                        }
                                        return orderMain;
                                    }, param: new { Issue = issue }, splitOn: "t1,t2").ToList();

                return result;
            }
        }

        private StandardResult UpdateOrderTMStatus(OrderTM model, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            StringBuilder sqlCommandText = new StringBuilder();
            sqlCommandText.Append("Update t_orders_tm set ");
            sqlCommandText.Append(" status=@Status,");
            sqlCommandText.Append(" outmoney=@OutMoney ");
            sqlCommandText.Append(" where id = @Id");

            if (db.Execute(sqlCommandText.ToString(), model, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }

            return result;
        }

        private StandardResult UpdateOrderLXLMStatus(OrderLXLM model, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            StringBuilder sqlCommandText = new StringBuilder();
            sqlCommandText.Append("Update t_orders_lxlm set ");
            sqlCommandText.Append(" status=@Status,");
            sqlCommandText.Append(" outmoney=@OutMoney");
            sqlCommandText.Append(" where id = @Id");

            if (db.Execute(sqlCommandText.ToString(), model, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }

        private StandardResult UpdateOrderStatus(int v, string id, int status, IDbTransaction trans)
        {
            StandardResult result = new StandardResult();
            var db = trans.Connection;
            StringBuilder sqlCommandText = new StringBuilder();
            sqlCommandText.Append("Update t_orders set ");
            sqlCommandText.Append(" status=@Status,");

            if (v == 1)
            {
                sqlCommandText.Append(" total_out_money=(select sum(outmoney) from t_orders_tm  where orderId=@Id and status=1)");
            }
            else if (v == 2)
            {
                sqlCommandText.Append(" total_out_money=(select sum(outmoney) from t_orders_lxlm  where orderId=@Id and status=1)");
            }
            sqlCommandText.Append(" where id = @Id");


            if (db.Execute(sqlCommandText.ToString(), new { Status = status, Id = id }, trans) <= 0)
            {
                result.Code = 1;
                result.Msg = "失败";
            }
            return result;
        }


        public StandardResult AddTotal(string issue)
        {
            var result = new StandardResult();
            using (var db = base.NewDB())
            {
                string totalId = Guid.NewGuid().ToString("n");
                string sql_TM = @"insert into t_total_details(totalId, ordertype, Inmoney, outmoney, returnmoney, customerId) SELECT
                                 @totalId,
                                 a.order_type,
                                 sum(b.inmoney),
                                 sum(b.outmoney) , 	sum(b.inmoney)*c.return_pl,
                                 a.customer_id
                                FROM
                                 t_orders AS a
                                INNER JOIN t_orders_tm AS b ON a.id = b.orderid
                                INNER JOIN t_odds as c on a.customer_id=c.customerId and a.order_type=c.ordertype
                                WHERE
                                 a.issue = @Issue
                                GROUP BY
                                 a.issue,
                                 a.customer_id,
                                 a.order_type,
                                 c.return_pl";

                db.Execute(sql_TM, new { totalId = totalId, Issue = issue });


                string sql_lxlm = @"insert into t_total_details(totalId, ordertype, Inmoney, outmoney, returnmoney, customerId) SELECT
                                 @totalId,
                                 a.order_type,
                                 sum(b.inmoney),
                                 sum(b.outmoney) , 	sum(b.inmoney)*c.return_pl,
                                 a.customer_id
                                FROM
                                 t_orders AS a
                                INNER JOIN t_orders_tm AS b ON a.id = b.orderid
                                INNER JOIN t_odds as c on a.customer_id=c.customerId and a.order_type=c.ordertype
                                WHERE
                                 a.issue = @Issue
                                GROUP BY
                                 a.issue,
                                 a.customer_id,
                                 a.order_type,
                                 c.return_pl";
                db.Execute(sql_lxlm, new { totalId = totalId, Issue = issue });

                return result;
            }
        }

        #endregion



    }
}
