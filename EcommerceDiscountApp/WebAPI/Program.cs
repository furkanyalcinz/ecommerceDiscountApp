using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstact.CategoryRepository;
using DataAccess.Abstact.DiscountsRepository;
using DataAccess.Abstact.ProductRepository;
using DataAccess.Concrete.CategoryRepository;
using DataAccess.Concrete.DiscountRepository;
using DataAccess.Concrete.ProductRepository;
using DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddDbContext<DiscountContext>();
builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IDiscountsReadRepository, DiscountReadRepository>();
builder.Services.AddScoped<IDiscountsWriteRepository, DiscountWriteRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
