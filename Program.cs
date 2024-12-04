using Microsoft.EntityFrameworkCore;
using prj_RestaurantApi.Dao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors( setup=>
{
        setup.AddPolicy("MyPolicy", policy => { policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); });
});
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnx")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
