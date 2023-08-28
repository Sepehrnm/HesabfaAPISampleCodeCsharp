using HesabfaAPISampleCode.Models;
using NPOI.SS.Formula.Functions;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HesabfaAPISampleCode.Services
{
    public interface IItemService
    {
        Product GetItems();
        T GetItem<T>(string code);
        T GetItemByBarcode<T>(string barcode);
        List<QuantityItem> GetQuantity(int warehouseCode, Array codes);
        T GetItemById<T>(Array idList);
        T Save<T>(object item);
        T Delete<T>(string code);
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
        public T GetItem<T>(string code)
        {
            var result = baseService.Post<ProductItem>("item/get", ("code", code));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(ProductItem)result.Result;
            }
        }

        public T GetItemByBarcode<T>(string barcode)
        {
            var result = baseService.Post<ProductItem>("item/getByBarcode", ("barcode", barcode));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(ProductItem)result.Result;
            }
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

        public T GetItemById<T>(Array idList)
        {
            var result = baseService.Post<List<ProductItem>>("item/getById", ("idList", idList));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(List<ProductItem>)result.Result;
            }
        }

        public T Save<T>(object item)
        {
            var result = baseService.Post<ProductItem>("item/save", ("item", item));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(ProductItem)result.Result;
            }
        }

        public T Delete<T>(string code)
        {
            var result = baseService.Post<object>("item/delete", ("code", code));

            if (!result.Success)
            {
                return (T)(object)new { Success = false, ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage };
            }
            else
            {
                return (T)(object)(object)result;
            }
        }

        public object UpdateOpeningQuantity(object items)
        {
            var result = baseService.Post<object>("item/UpdateOpeningQuantity", ("items", items));

            return result.Success;
        }
    }
}
