using MangaReader.Entities;
using MangaReader.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.Configure<AuthenticationOptions>(builder.Configuration.GetSection("AuthenticationOptions"));
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
{
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(".NET", "8.0"));
    client.BaseAddress = new Uri(builder.Configuration["AuthenticationUri"]);
});
builder.Services.AddTransient<ICacheManager, CacheManager>();
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
