using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Services
{
    public interface IProductService
    {
        Product GetItems();
        ProductItem GetItem(string code);
        ProductItem GetItemByBarcode(string barcode);
        List<QuantityItem> GetQuantity(int warehouseCode, Array codes);
    }
    public class ProductService: IProductService
    {
        private readonly IBaseService baseService;
        public ProductService(IBaseService baseService)
        {
            this.baseService = baseService;
        }
        public Product GetItems()
        {
            var queryInfo = new
            {
                SortBy = "Code",
                SortDesc = true,
                Take = 200000,
                Skip = 0
            };

            var result = baseService.Post<Product>("item/getitems", ("queryInfo", queryInfo));

            return result.Result;
        }
        public ProductItem GetItem(string code)
        {
            var result = baseService.Post<ProductItem>("item/get", ("code", code));

            return result.Result;
        }

        public ProductItem GetItemByBarcode(string barcode)
        {
            var result = baseService.Post<ProductItem>("item/getByBarcode", ("barcode", barcode));

            return result.Result;
        }

        public List<QuantityItem> GetQuantity(int warehouseCode, Array codes)
        {
            var parameters = new List<(string, object)>
            {
                ("warehouseCode", warehouseCode),
                ("codes", codes),
            };

            var result = baseService.Post<List<QuantityItem>>("item/GetQuantity", parameters);

            return result.Result;
        }
    }
}
