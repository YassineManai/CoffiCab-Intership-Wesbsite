/*
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.Service;
using Microsoft.EntityFrameworkCore;
using ManufacturingExecutionSystem1;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;

/* public static void Main(string[] args)
 {
     CreateHostBuilder(args).Build().Run();
 }

 public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseStartup<Startup>();
         });*/
/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProgProfil, ProgProfilRepository>();
builder.Services.AddScoped<IRepository<Machine>, MachineRepository>();
builder.Services.AddScoped<IRepository<Process>, ProcessRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Caracters>, CaractersRepository>();
builder.Services.AddScoped<IRepository<CaracterValues>, CaractersValuesRepository>();
builder.Services.AddScoped<IRepository<ProfilUser>, ProfilUserRepository>();
builder.Services.AddScoped<IRepository<CaractersStartOfShiftValues>, CaractersStartOfShiftRepository>();
builder.Services.AddDbContext<Context>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("MyContext") ?? throw new InvalidOperationException("Connection string 'MyContext' not found.")));
//builder.Services.AddControllers();
builder.Services.AddTransient<Context>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
   app.UseDeveloperExceptionPage();
   //app.UseWebAssemblyDebugging();
}
app.UseCors(option => option
                 .AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/


using ManufacturingExecutionSystem1.entities;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.Service;
using ManufacturingExecutionSystem1.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ProcessRepository>();
builder.Services.AddScoped<IProgProfil, ProgProfilRepository>();
builder.Services.AddScoped<IRepository<Machine>, MachineRepository>();
builder.Services.AddScoped<IRepository<Process>, ProcessRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Caracters>, CaractersRepository>();
builder.Services.AddScoped<IRepository<CaracterValues>, CaractersValuesRepository>();
builder.Services.AddScoped<IRepository<ProfilUser>, ProfilUserRepository>();
builder.Services.AddScoped<IRepository<CaractersStartOfShiftValues>, CaractersStartOfShiftRepository>();
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyContext") ?? throw new InvalidOperationException("Connection string 'MyContext' not found.")));
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
app.UseCors(option => option
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

