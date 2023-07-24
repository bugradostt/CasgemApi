using Casgem.DataAccessLayer.Concrete;

using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("MongoDB");
//var databaseName = builder.Configuration.GetConnectionString("test");
//var client = new MongoClient(connectionString);
//var database = client.GetDatabase(databaseName);
//builder.Services.AddSingleton<IMongoClient>(client);
//builder.Services.AddSingleton<IMongoDatabase>(database);

// Add services to the container.

builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
//builder.Services.AddScoped<ICategoryService, CategoryManager>();


//builder.Services.AddScoped<IProductDal, EfProductDal>();
//builder.Services.AddScoped<IProductService, ProductManager>();

//builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
//builder.Services.AddScoped<ICustomerService, CustomerManager>();


//builder.Services.AddDbContext<Context>();

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
