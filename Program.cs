using Microsoft.EntityFrameworkCore;
using prj_RestaurantApi.Dao;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("MyPolicy", policy => { policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod(); });
});

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnx")));

builder.Services.AddControllers();

builder.Services.AddScoped<PlatService,PlatRepo>();
builder.Services.AddScoped<EmployeService, EmployeRepo>(); 

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
