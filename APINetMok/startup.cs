using APINetMok.Business;
using APINetMok.Business.Interfaces;
using APINetMok.Dominio.Contextos;
using APINetMok.Infraestructura;
using APINetMok.Infraestructura.Interfaces;
using APINetMok.Infraestructure.Interfaces;
using APINetMok.Services;
using APINetMok.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;

namespace APINetMok
{
    public class startup
    {
        public IConfiguration Configuration { get; }

        public startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string? EnvironmentName = Configuration.GetSection("RunWithConfiguration")?["EnvironmentName"]?.ToLower();


            services.AddCors();
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = assemblyName, Version = "v1" });
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string xmlFile = $"{assemblyName}.xml";
                string xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #region Settings to Database and other configurations
            string nameConnectionString = String.Format("{0}{1}", CultureInfo.InvariantCulture.TextInfo.ToTitleCase(EnvironmentName), "ConnectionString");
            string? connectionString = Configuration?.GetSection("ConnectionSqlServer")[nameConnectionString];
            services.AddDbContext<PersistenciaContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            #endregion

            services.AddHttpContextAccessor();

            #region Scopeds 
            // Dependency injection, Usando las interfaces de Business y Repository
            services.AddScoped<IEstudianteBusiness, EstudianteBusiness>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<ILibroBusiness, LibroBusiness>();
            services.AddScoped<IPrestamoBusiness, PrestamoBusiness>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            // Referencia a Servicio Externo
            services.AddScoped<IServicioExternoApi, ServicioExternoApi>();            
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string? EnvironmentName = Configuration?.GetSection("RunWithConfiguration")?["EnvironmentName"]?.ToLower();

            // Ensambla el Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(
                string.Format("{0}{1}", EnvironmentName == "local" ? string.Empty : "/prestamo-" + EnvironmentName, "/swagger/v1/swagger.json"),
                string.Format("{0} v1", assemblyName))
            );

            app.UseCors(options =>
            {
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseFileServer(enableDirectoryBrowsing: true);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
        }
    }
}