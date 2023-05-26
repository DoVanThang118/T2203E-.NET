using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add CORS
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(
        policy =>
        {
            //policy.WithOrigins("https://24h.com.vn")
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});
// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options
    => options.SerializerSettings.ReferenceLoopHandling
    = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ASP.NET_API.Entities.AspNetApiContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("T2203E_demo")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
