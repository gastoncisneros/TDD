using FormulaApp.API.Configurations;
using FormulaApp.API.Services;
using FormulaApp.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:5024");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiServiceConfiguration>(builder.Configuration.GetSection("ApiServiceConfiguration"));
builder.Services.AddScoped<IFanService, FanService>();
builder.Services.AddHttpClient<IFanService, FanService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
