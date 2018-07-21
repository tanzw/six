using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Common.Result
{
    public class StandardResult : IStandardResult
    {
        public int Code { get; set; }

        public string Msg { get; set; }
    }

    public class StandardResult<T> : StandardResult, IStandardResult<T>
    {
        public StandardResult()
        {
            Code = 0;
            Msg = "成功";
        }
        public T Body { get; set; }
    }

    public class SearchReasult<T> : StandardResult
    {
        /// <summary>
        /// 记录总数
        /// </summary>
        public int total { set; get; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> rows { set; get; }
    }


}
