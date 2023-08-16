using HesabfaAPISampleCode.Controllers;
using HesabfaAPISampleCode.Middlewares;
using HesabfaAPISampleCode.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});
builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

builder.Services.AddSingleton<IBaseService, BaseService>();
builder.Services.AddSingleton<ISettingService, SettingService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IContactService, ContactService>();
builder.Services.AddSingleton<IInvoiceService, InvoiceService>();
builder.Services.AddSingleton<IReceiptService, ReceiptService>();
builder.Services.AddSingleton<IReportService, ReportService>();


var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();

