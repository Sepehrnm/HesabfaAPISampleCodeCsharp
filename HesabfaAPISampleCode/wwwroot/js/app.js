function initializeGetTrialBalanceItemsListPage(data) {
    $('#trialBalanceItemsGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'code',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetTrialBalanceListPage(data) {
    $('#trialBalanceGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'debit',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        columns: [
            { caption: "نام حساب", dataField: "accountName" },
            { caption: "مسیر حساب", dataField: "accountPath" },
            {
                caption: "نوع حساب", dataField: "accountType", lookup: {
                    dataSource: [
                        { id: '0', text: 'عمومی' },
                        { id: '1', text: 'صندوق' },
                        { id: '2', text: 'تنخواه گردان' },
                        { id: '3', text: 'بانک' },
                        { id: '4', text: 'حساب های دریافتنی' },
                        { id: '5', text: 'اسناد دریافتنی' },
                        { id: '6', text: 'اسناد در جریان وصول' },
                        { id: '7', text: 'موجودی کالا' },
                        { id: '8', text: 'مالیات بر ارزش افزوده خرید' },
                        { id: '9', text: 'حساب های پرداختنی' },
                        { id: '10', text: 'اسناد پرداختنی' },
                        { id: '11', text: 'مالیات بر ارزش افزوده فروش' },
                        { id: '12', text: 'مالیات بر درآمد پرداختنی' },
                        { id: '40', text: 'ذخیره مالیات بر درآمد پرداختنی' },
                        { id: '13', text: 'سرمایه اولیه' },
                        { id: '14', text: 'افزایش یا کاهش سرمایه' },
                        { id: '15', text: 'اندوخته قانونی' },
                        { id: '16', text: 'برداشت ها' },
                        { id: '17', text: 'سهم سود و زیان' },
                        { id: '18', text: 'سود یا زیان انباشته (سنواتی)' },
                        { id: '19', text: 'بهای تمام شده کالای فروخته شده / خرید' },
                        { id: '20', text: 'برگشت از خرید' },
                        { id: '21', text: 'تخفیفات نقدی خرید' },
                        { id: '22', text: 'فروش' },
                        { id: '23', text: 'برگشت از فروش' },
                        { id: '24', text: 'تخفیفات نقدی فروش' },
                        { id: '25', text: 'درآمد حاصل از فروش خدمات' },
                        { id: '26', text: 'برگشت از خرید خدمات' },
                        { id: '27', text: 'درآمد اضافه کالا' },
                        { id: '28', text: 'درآمد حمل کالا' },
                        { id: '29', text: 'برگشت از فروش خدمات' },
                        { id: '30', text: 'خرید خدمات' },
                        { id: '31', text: 'هزینه حمل کالا' },
                        { id: '32', text: 'هزینه کسری و ضایعات کالا' },
                        { id: '33', text: 'کارمزد خدمات بانکی' },
                        { id: '34', text: 'کنترل کسری و اضافه کالا' },
                        { id: '35', text: 'خلاصه سود و زیان' },
                        { id: '36', text: 'درآمد تسعیر ارز' },
                        { id: '37', text: 'هزینه تسعیر ارز' },
                    ],
                    valueExpr: 'id',
                    displayExpr: 'text'
                }
            },
            {
                caption: "نوع حساب اصلی", dataField: "mainAccountType", lookup: {
                    dataSource: [
                        { id: '1', text: 'دارایی ها' },
                        { id: '2', text: 'بدهی ها' },
                        { id: '3', text: 'حقوق صاحبان سهام' },
                        { id: '4', text: 'بهای تمام شده کالای فروخته شده / خرید' },
                        { id: '5', text: 'فروش' },
                        { id: '6', text: 'درآمد' },
                        { id: '7', text: 'هزینه ها' },
                        { id: '8', text: 'سایر حساب ها' },
                    ],
                    valueExpr: 'id',
                    displayExpr: 'text'
                }
            },
            { caption: "گردش بدهکار", dataField: "debit" },
            { caption: "گردش بستانکار", dataField: "credit" },
            { caption: "تراز حساب", dataField: "balance" },
            { caption: "ماهیت حساب", dataField: "balanceType", lookup: {
                    dataSource: [
                        { id: '0', text: 'بدهکار' },
                        { id: '1', text: 'بستانکار' }
                    ],
                    valueExpr: 'id',
                    displayExpr: 'text'
                }
            },
            { caption: "تراز افتتاحیه - بدهکار", dataField: "openingDebit" },
            { caption: "تراز افتتاحیه - بستانکار", dataField: "openingCredit" },
            { caption: "مانده از قبل - بدهکار", dataField: "remainingDebit" },
            { caption: "مانده از قبل - بستانکار", dataField: "remainingCredit" },
        ],
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetChangesPage(data) {
    $('#changeGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'id',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetProductListPage(data) {
    $('#productGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'Code',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [25, 50, 100],
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetContactListPage(data) {
    $('#contactGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: "Code",
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetContactByIdListPage(data) {
    $('#contactGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: "code",
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetInventoryListPage(data) {
    $('#inventoryGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'code',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetAccountsListPage(data) {
    $('#accountGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'fullPath',
        rtlEnabled: true,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 10,
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [10, 25, 50, 100],
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
        columns: [{
            dataField: 'name',
            caption: 'حساب',
            allowResizing: true,
            allowReordering: true,
            allowGrouping: true,
            allowHeaderFiltering: true
        }, {
            dataField: 'detailType',
            caption: 'تفصیل',
            allowResizing: true,
            allowGrouping: true,
            allowHeaderFiltering: true,
            allowReordering: true,
            lookup: {
                dataSource: [{ id: 0, text: '' }, { id: 1, text: 'شخص' }, { id: 2, text: 'بانک' }, { id: 3, text: 'صندوق' }, { id: 4, text: 'تنخواه گردان' }, { id: 5, text: 'کالا' }, { id: 6, text: 'حساب' }],
                valueExpr: 'id',
                displayExpr: 'text'
            }
        }]
    });
}

function initializeGetDebtorsCreditorsListPage(data) {
    $('#debtorsCreditorsListGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'code',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetInvoicesListPage(data) {
    $('#invoicesGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'Number',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetReceiptsListPage(data) {
    $('#receiptsGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'Id',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function initializeGetDocumentListPage(data) {
    $('#documentsGridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'Id',
        rtlEnabled: true,
        columnMinWidth: 150,
        filterRow: {
            visible: true
        },
        paging: {
            pageSize: 25,
        },
        focusedRowEnabled: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        showBorders: true,
        headerFilter: {
            visible: true,
        },
        groupPanel: {
            visible: true,
        },
    });
}

function formatContactCategories(data) {
    var contactCategories = data;
    let contactDetails = document.getElementById("contact-details");
    showCategory(contactCategories, contactDetails, 0);

    function showCategory(item, parentElement, level) {
        let name = document.createElement("div");
        name.className = "category-content";
        name.id = item.FullPath;
        name.innerHTML = `<img src="../assets/dropdown.svg" class="dropdown-icon" /><span id="${item.FullPath}">${item.Name}</span>`;
        name.style.paddingRight = `${level * 10}px`;

        parentElement.appendChild(name);

        if (item.Children) {
            let childWrapper = document.createElement("div");
            childWrapper.style.display = "none";
            parentElement.appendChild(childWrapper);

            item.Children.forEach((child) => {
                showCategory(child, childWrapper, level + 1);
            });
        }
    }

    $(".category-content").on("click", (e) => {
        if (e.target.id) {
            $("#fullPath").text(e.target.id);
        }
    });

    $(".dropdown-icon").on("click", function (e) {
        $(this).toggleClass("rotate");
        $(this).parent().next().stop().slideToggle();
    });
}

function formatProductCategories(data) {
    var productCategories = data;
    let productDetails = document.getElementById("product-details");
    showCategory(productCategories, productDetails, 0);

    function showCategory(item, parentElement, level) {
        let name = document.createElement("div");
        name.className = "category-content";
        name.id = item.FullPath;
        name.innerHTML = `<img src="../assets/dropdown.svg" class="dropdown-icon" /><span id="${item.FullPath}">${item.Name}</span>`;
        name.style.paddingRight = `${level * 10}px`;

        parentElement.appendChild(name);

        if (item.Children) {
            let childWrapper = document.createElement("div");
            childWrapper.style.display = "none";
            parentElement.appendChild(childWrapper);

            item.Children.forEach((child) => {
                showCategory(child, childWrapper, level + 1);
            });
        }
    }

    $(".category-content").on("click", (e) => {
        if (e.target.id) {
            $("#fullPath").text(e.target.id);
        }
    });

    $(".dropdown-icon").on("click", function (e) {
        $(this).toggleClass("rotate");
        $(this).parent().next().stop().slideToggle();
    });
}

function formatServiceCategories(data) {
    var serviceCategories = data;
    let serviceDetails = document.getElementById("service-details");
    showCategory(serviceCategories, serviceDetails, 0);

    function showCategory(item, parentElement, level) {
        let name = document.createElement("div");
        name.className = "category-content";
        name.id = item.FullPath;
        name.innerHTML = `<img src="../assets/dropdown.svg" class="dropdown-icon" /><span id="${item.FullPath}">${item.Name}</span>`;
        name.style.paddingRight = `${level * 10}px`;

        parentElement.appendChild(name);

        if (item.Children) {
            let childWrapper = document.createElement("div");
            childWrapper.style.display = "none";
            parentElement.appendChild(childWrapper);

            item.Children.forEach((child) => {
                showCategory(child, childWrapper, level + 1);
            });
        }
    }

    $(".category-content").on("click", (e) => {
        if (e.target.id) {
            $("#fullPath").text(e.target.id);
        }
    });

    $(".dropdown-icon").on("click", function (e) {
        $(this).toggleClass("rotate");
        $(this).parent().next().stop().slideToggle();
    });
}

function formatBalanceSheetData(data, ret, id, parentId) {
    for (const d of data) {
        d.id = id++;
        d.parentId = parentId;
        ret.push(d);
        id = formatBalanceSheetData(d.Children, ret, id, d.id);
    }
    return id;
}

function formatProfitAndLossStatementData(data, ret, id, parentId) {
    for (const d of data) {
        d.id = id++;
        d.parentId = parentId;
        ret.push(d);
        id = formatBalanceSheetData(d.Children, ret, id, d.id);
    }
    return id;
}