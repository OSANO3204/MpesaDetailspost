using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppService.BLL.Data;
using WhatsAppService.BLL.Mapper;
using WhatsAppService.BLL;
using WhatsAppService.BLL.Iservices;
using WhatsAppService.BLL.Services;
using Microsoft.AspNetCore.Identity;
using WhatsAppService.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace WhasAppService.Api
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
            services.AddDbContext<WhatsAppServiceContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DevConnectiions")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WhatsAppServiceContext>();
            services.AddControllers();
            services.AddScoped<ITransactionActions,TransactionActions>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers();


            //token registration
            var _jwtsettings = Configuration.GetSection("JwtSetting");
            services.Configure<JwtSetting>(_jwtsettings);
            var authkey = Configuration.GetValue<string>("JWTSettings:SecretKey");
            services.AddAuthentication(item =>
            {
                item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(item =>
            {
                item.RequireHttpsMetadata = true;
                item.SaveToken = true;
                item.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
                    ValidateIssuer = false,
                    ValidAudience= Convert.ToString(false)


                };

            });
            //end of token registration


                services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WhasAppService.Api", Version = "v1" });
            });
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhasAppService.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("http://localhost:8080/");
            app.UseRouting();
            _ = app.UseCors(x => x.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
