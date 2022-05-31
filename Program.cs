using Microsoft.AspNetCore.HttpOverrides;
using Sprint3_microservice.Interfaces;
using Sprint3_microservice.Services;
using System.Net;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "http://localhost:8080", "http://146.190.18.26/", "http://localhost:80/", "http://146.190.18.26/5000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod(); ;
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDelivery, DeliveryService>();
builder.Services.AddScoped<IAuction, AuctionService>();

var app = builder.Build();

app.UseForwardedHeaders(
    new ForwardedHeadersOptions
    {
        ForwardedHeaders =
       ForwardedHeaders.XForwardedFor |
       ForwardedHeaders.XForwardedProto
    }
);
app.UseAuthentication();

/*builder.Services.Configure<ForwardedHeadersOptions>(options => {
    options.KnownProxies.Add(IPAddress.Parse("10.10.41.40"));
});*/


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
