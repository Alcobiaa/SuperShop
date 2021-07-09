using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SuperShop.Helpers
{
    public class NotFoundViewResult: ViewResult
    {
        public NotFoundViewResult(string viewName)
        {
            ViewName = viewName;
            StatusCode = (int)HttpStatusCode.NotFound;
        }


    }
}
