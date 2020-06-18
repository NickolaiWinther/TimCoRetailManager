using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            var taxRate = ConfigHelper.GetTaxRate();

            ProductData products = new ProductData();

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                var productInfo = products.GetProductById(item.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product Id of {item.ProductId} could not be found in the database");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = detail.PurchasePrice * taxRate;
                }

                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spSale_Insert", sale, "TRMData");

            foreach (var item in details)
            {
                item.SaleId = sale.Id;
                sql.SaveData("dbo.SaleDetail_Insert", item, "TRMData");
            }

        }
    }
}
