using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using vtex.api.core.Models;
using vtex.api.core.Security;
using vtex.context.core;
using vtex.repository.core;
using vtex.service.core;

namespace vtex.api.core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Para alojar en una clase de configuracion los parametros generales de la aplicacion
            services.Configure<AplicationConfig>(Configuration.GetSection("AplicationConfig"));

            string[] lOrigins = Configuration.GetSection("MyOrigin").Value.Split(',');

            //Seguridad en llamado al CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins(lOrigins)
                    .AllowAnyHeader().WithMethods("GET", "POST", "PUT");
                });
            });
            services.AddScoped<SimpleFilterRules>();
            services.AddMemoryCache();

            //Inyecta el contexto de la base de datos mediante la libreria de clase
            services.AddDbContext<vtex_testContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ModelContext")));

            //Inyecta a la plataforma las instancias de los repositorios que se utilizaran en la capa de servicios Rest
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(ILibroRepository), typeof(LibroRepository));
            services.AddTransient(typeof(IAutorRepository), typeof(AutorRepository));
            services.AddTransient(typeof(IEditorialRepository), typeof(EditorialRepository));
            services.AddTransient(typeof(ILibroAutorRepository), typeof(LibroAutorRepository));

            //Inyecta a la plataforma las instancias de los servicio o capa de negocio que se utilizaran en la capa de servicios Rest
            services.AddTransient(typeof(ILibroService), typeof(LibroService));
            services.AddTransient(typeof(IAutorService), typeof(AutorService));
            services.AddTransient(typeof(IEditorialService), typeof(EditorialService));
            services.AddTransient(typeof(ILibroAutorService), typeof(AutorLibroService));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servicio ApiRest para Vtex", Version = "v1" });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Servicio ApiRest para Vtex v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowOrigin");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
