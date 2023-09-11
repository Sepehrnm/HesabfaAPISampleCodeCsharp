namespace HesabfaAPISampleCode.Models.Enumarations
{
    public enum LogAction
    {
        ContactSave = 31,
        ContactEdit = 32,
        ContactDelete = 33,
        ContactMerge = 34,
        ProductSave = 51,
        ProductEdit = 52,
        ProductDelete = 53,
        ImportProduct = 101,
        ImportContact = 102,

        SalesSave = 121,
        SalesEdit = 122,
        SalesDelete = 123,
        SalesChangeStatus = 124,

        BillSave = 131,
        BillEdit = 132,
        BillDelete = 133,
        BillChangeStatus = 134,

        SalesReturnSave = 141,
        SalesReturnEdit = 142,
        SalesReturnDelete = 143,
        SalesReturnChangeStatus = 144,

        PurchaseReturnSave = 151,
        PurchaseReturnEdit = 152,
        PurchaseReturnDelete = 153,
        PurchaseReturnChangeStatus = 154,

        WastageSave = 161,
        WastageEdit = 162,
        WastageDelete = 163,
        WarehouseReceiptSave = 261,
        WarehouseReceiptEdit = 262,
        WarehouseReceiptDelete = 263,
        OpeningBalanceSave = 111,
        OpeningBalanceEdit = 112,
    }
}
