using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HesabfaAPISampleCode.Services
{
    public interface IItemService
    {
        Product GetItems();
        ProductItem GetItem(string code);
        ProductItem GetItemByBarcode(string barcode);
        List<QuantityItem> GetQuantity(int warehouseCode, Array codes);
        List<ProductItem> GetItemById(Array idList);
        ProductItem Save(object item);
        object Delete(string code);
        object UpdateOpeningQuantity(object items);

    }
    public class ItemService: IItemService
    {
        private readonly IBaseService baseService;
        public ItemService(IBaseService baseService)
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
            var parameters = new List<(string, object)>();

            if (warehouseCode != 0) 
            {
                parameters.Add(("warehouseCode", warehouseCode));
            }

            if (codes != null && codes.Length > 0) 
            {
                parameters.Add(("codes", codes));
            }

            var result = baseService.Post<List<QuantityItem>>("item/GetQuantity", parameters);

            return result.Result;
        }

        public List<ProductItem> GetItemById(Array idList)
        {
            var result = baseService.Post<List<ProductItem>>("item/getById", ("idList", idList));

            return result.Result;
        }

        public ProductItem Save(object item)
        {
            var result = baseService.Post<ProductItem>("item/save", ("item", item));

            return result.Result;
        }

        public object Delete(string code)
        {
            var result = baseService.Post<object>("item/delete", ("code", code));

            return result.Result;
        }

        public object UpdateOpeningQuantity(object items)
        {
            var result = baseService.Post<object>("item/UpdateOpeningQuantity", ("items", items));

            return result.Success;
        }
    }
}
