using HesabfaAPISampleCode.Models;

namespace HesabfaAPISampleCode.Services
{
    public interface IItemService
    {
        Task<Product> GetItems();
        Task<ProductItem> GetItem(string code);
        Task<ProductItem> GetItemByBarcode(string barcode);
        Task<List<QuantityItem>> GetQuantity(int warehouseCode, Array codes);
        Task<List<ProductItem>> GetItemById(Array idList);
        Task<ProductItem> Save(object item);
        Task<bool> Delete(string code);
        Task<object> UpdateOpeningQuantity(object items);

    }
    public class ItemService: IItemService
    {
        private readonly IBaseService baseService;
        public ItemService(IBaseService baseService)
        {
            this.baseService = baseService;
        }
        public async Task<Product> GetItems()
        {
            var queryInfo = new
            {
                SortBy = "Code",
                SortDesc = true,
                Take = 200,
                Skip = 0
            };

            return await baseService.Post<Product>("item/getitems", ("queryInfo", queryInfo));
        }
        public async Task<ProductItem> GetItem(string code)
        {
            return await baseService.Post<ProductItem>("item/get", ("code", code));
        }

        public async Task<ProductItem> GetItemByBarcode(string barcode)
        {
            return await baseService.Post<ProductItem>("item/getByBarcode", ("barcode", barcode));
        }

        public async Task<List<QuantityItem>> GetQuantity(int warehouseCode, Array codes)
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

            return await baseService.Post<List<QuantityItem>>("item/GetQuantity", parameters);
        }

        public async Task<List<ProductItem>> GetItemById(Array idList)
        {
            return await baseService.Post<List<ProductItem>>("item/getById", ("idList", idList));
        }

        public async Task<ProductItem> Save(object item)
        {
            return await baseService.Post<ProductItem>("item/save", ("item", item));
        }

        public async Task<bool> Delete(string code)
        {
            return await baseService.Post<bool>("item/delete", ("code", code));
        }

        public async Task<object> UpdateOpeningQuantity(object items)
        {
            return await baseService.Post<object>("item/UpdateOpeningQuantity", ("items", items));
        }
    }
}
