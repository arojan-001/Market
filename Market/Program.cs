using BLL.Intefaces;
using BLL.Services;
using DAL.Data;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IProductCategoryRepository), typeof(ProductCategoryRepository));
builder.Services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddTransient(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddTransient(typeof(IOrderDetailsRepository), typeof(OrderDetailsRepository));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
