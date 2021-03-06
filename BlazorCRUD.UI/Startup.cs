using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;
using BlazorCRUD.UI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorCRUD.Model;
using Microsoft.Extensions.Options;
using BlazorCRUD.Data.Dapper.Repositorios;

namespace BlazorCRUD.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            //agregamos un nuevo servicio para asociar la interfaz del servicio con el objeto del servicio film
            services.AddScoped<IFilmService, FilmService>(); 

            //agregamos la interfaz y el servicio de file
            services.AddScoped<IFileService, FileService>();

            //agregamos la interfaz y el servicio de fileupload
            services.AddScoped<IFileUpload, FileUpload>();

            //agregamos la conexion a la bd
            var SqlConnectionConfiguration = new SqlConfiguration(Configuration.GetConnectionString("SqlConnection"));
            services.AddSingleton(SqlConnectionConfiguration);


            //agregar la conexion a la bd mongo
            services.Configure<ArchivosDBMDatabaseSettings>(
            Configuration.GetSection(nameof(ArchivosDBMDatabaseSettings)));

            services.AddSingleton<IArchivosDBMDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<ArchivosDBMDatabaseSettings>>().Value);

            //agregamos el empleadoservice
            services.AddSingleton<EmpleadoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}