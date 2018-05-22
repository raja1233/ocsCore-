using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OCS.DataAccessLayer;
using OCS.SerivceLayer.Mapping;
using Swashbuckle.AspNetCore.Swagger;

namespace OCS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            AutomapperConfiguration.Configure();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });
            services.AddMvc();
            services.AddDbContext<OnlineCatalogueSystemContext>(option => { option.UseSqlServer(Configuration.GetConnectionString("DefaultDB"), b => b.MigrationsAssembly("OCS")); });
            services = BuildUnityContainer.RegisterAddTransient(services);
            services.AddSingleton(Configuration);
            services.AddTransient<MasterInitializer>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Online Catalogue System API", Version = "v1" });
                c.IgnoreObsoleteProperties();
            });
            services.AddCors();
            services.AddCors(options => options.AddPolicy("AllowCors", builder =>
            {
                builder.AllowAnyOrigin().WithMethods("GET", "PUT", "POST", "DELETE").AllowAnyHeader();
            })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, OnlineCatalogueSystemContext context, MasterInitializer masterSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors("AllowCors");
            masterSeeder.Seed(context).Wait(); //invoke seed method on application startup//
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }
    }
}
