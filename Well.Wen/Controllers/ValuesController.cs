using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Well.Model;
using Well.Data;
using Well.Common;
using Well.Common.Result;

namespace Well.Wen.Controllers
{
    public class ValuesController : ApiController
    {
        public StandardResult AddOrderLXLM(Order<OrderLXLM> input)
        {
            Well.Data.OrderImpl service = new Data.OrderImpl();
            return service.AddOrderLXLM(input);
        }

        public StandardResult AddOrderTM(Order<OrderTM> input)
        {
            Well.Data.OrderImpl service = new Data.OrderImpl();
            return service.AddOrderTM(input);
        }
    }
}
