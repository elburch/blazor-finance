using BlazorFinance.Server.Data;
using BlazorFinance.Server.Repositories;
using BlazorFinance.Server.Services;
using BlazorFinance.Shared.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Data
builder.Services.AddScoped<IDataContext<Account>, DataContext<Account>>();
builder.Services.AddScoped<IDataContext<Asset>, DataContext<Asset>>();
builder.Services.AddScoped<IDataContext<Expense>, DataContext<Expense>>();
builder.Services.AddScoped<IDataContext<Income>, DataContext<Income>>();
builder.Services.AddScoped<IDataContext<Institution>, DataContext<Institution>>();
builder.Services.AddScoped<IDataContext<Template>, DataContext<Template>>();
// Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
// Services
builder.Services.AddScoped<IQuoteService, QuoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
