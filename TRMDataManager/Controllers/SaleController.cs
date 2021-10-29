using System;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TRMDataManager.Library;
using TRMDataManager.Library.DataAccess;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();
            data.SaveSale(sale, userId);
        }
    }
}
