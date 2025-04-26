using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.Service;
using Microsoft.EntityFrameworkCore;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;

namespace ManufacturingExecutionSystem1
{
  public class Startup
    {
        public IConfiguration config { get; }
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IProgProfil, ProgProfilRepository>();
            services.AddScoped<IRepository<Machine>, MachineRepository>();
            services.AddScoped<IRepository<Process>, ProcessRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Caracters>, CaractersRepository>();
            services.AddScoped<IRepository<CaracterValues>, CaractersValuesRepository>();
            services.AddScoped<IRepository<ProfilUser>, ProfilUserRepository>();
            services.AddScoped<IRepository<CaractersStartOfShiftValues>, CaractersStartOfShiftRepository>(); 
            services.AddDbContext<Context>(options =>
    options.UseSqlServer(config.GetConnectionString("MyContext") ?? throw new InvalidOperationException("Connection string 'MyContext' not found.")));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseHttpsRedirection();
                app.UseBlazorFrameworkFiles();
                app.UseStaticFiles();

                app.UseRouting();
                app.UseCors(option => option
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  );
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllers();
                    endpoints.MapFallbackToFile("index.html");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

        }

    }
       
}
