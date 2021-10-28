using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel sale)
        {
            // TODO - Break this apart make it better
            // Start filling in the models we'll save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            foreach (var item in sale.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };


                
                details.Add(detail);
            }
            // Fill in the available information

            // Create the sale model
            // Save the sale model
            // Get the ID from the sale model
            // Finish filling in the sale detail models
            // Save the sale details model


        }
    }
}
