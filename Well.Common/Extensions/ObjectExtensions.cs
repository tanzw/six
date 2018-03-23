﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Common.Extensions
{
    public static class ObjectExtensions
    {

        public static string SerializeToJson(this object v, string DateTimeFormats = "yyyy-MM-dd HH:mm:ss")
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = DateTimeFormats };
            return Newtonsoft.Json.JsonConvert.SerializeObject(v, Formatting.Indented, timeConverter);
        }

        public static T DeserializeToModel<T>(this string v)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(v);
        }

        /// <summary>
        /// 将json字符串转换成list<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="v"></param>
        /// <returns></returns>
        public static List<T> DeserializeToList<T>(this string v)
        {
            return JsonConvert.DeserializeObject<List<T>>(v);
        }


        public static int ToTryInt(this string v)
        {
            int r = 0;
            if (int.TryParse(v, out r))
            {
                return r;
            }
            else
            {
                throw new Exception("字符串转Int数据错误");
            }

        }

        public static int ToTryInt(this object v)
        {
            int r = 0;
            if (int.TryParse(v.ToString().Trim(), out r))
            {
                return r;
            }
            else
            {
                throw new Exception("字符串转Int数据错误");
            }

        }
    }
}
