﻿using System;
using System.Web.Http;
using TRMDataManager.Library;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public void Post(SaleModel sale)
        {
            Console.WriteLine();
        }
    }
}
