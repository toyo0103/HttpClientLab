using ProjectA.MyCustomHttpClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICustomHttpClient, CustomHttpClient>((serviceProvider, client) =>
{
    client.BaseAddress = new Uri("http://localhost:5091");
}).ConfigurePrimaryHttpMessageHandler(serviceProvider =>
 {
     return new SocketsHttpHandler
     {
         PooledConnectionLifetime = TimeSpan.FromSeconds(10),
         //UseCookies = false,
     };
});

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
