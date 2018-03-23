using System;
using System.Collections.Generic;
using System.Text;

namespace Well.Common.Result
{
    public interface IStandardResult
    {
        int Code { get; set; }
        string Msg { get; set; }

    }

    public interface IStandardResult<T> : IStandardResult
    {
        T Body { get; set; }
    }
}
