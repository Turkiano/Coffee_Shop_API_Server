
using System.Text;
using System.Text.Json.Serialization;
using Coffee_Shop_App.Controllers;
using Coffee_Shop_App.Repositories;
using Coffee_Shop_App.Services;
using Coffee_Shop_App.src.Abstractions;
using Coffee_Shop_App.src.Databases;
using Coffee_Shop_App.src.Repositories;
using Coffee_Shop_App.src.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

//Should be added (1)
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });; // to deferntiate between controllers and other classes
builder.Services.AddAutoMapper(typeof(Program).Assembly); //to find where is the AutoMapper for DTOs
builder.Services.AddDbContext<DatabaseContext>(); //to configure DbSet for EF Core (Postgres)
// builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql()); //for creating custom enum type 


//Should be added (3) to lowercase the Route
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependency Injection Containers for Abstraction classes
builder.Services.AddScoped<IUserRepository, UserRepository>(); //built-in DI Container for UserRepository
builder.Services.AddScoped<IUserService, UserService>(); //built-in DI Container for UserService
builder.Services.AddScoped<IProductRepository, ProductRepository>(); //built-in DI Container for ProductRepository
builder.Services.AddScoped<IProductService, ProductService>(); //built-in DI Container for ProductService
builder.Services.AddScoped<ICategoryService, CategoryService>(); //built-in DI Container for CategoryService
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //built-in DI Container for CategoryRepository
builder.Services.AddScoped<IOrderService, OrderService>(); //built-in DI Container for OrderService
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); //built-in DI Container for OrderRepository
builder.Services.AddScoped<IOrderItemService, OrderItemService>(); //built-in DI Container for OrderService
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>(); //built-in DI Container for OrderRepository
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();


//Authentication Builder
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SIgningKey"]!))
    };
}
);

var app = builder.Build();

//Should be added (2)
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

//to let the Server know that we are using the following: 
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();


