using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMS_Logistics.Common;
using TMS_Logistics.IRepository;
using TMS_Logistics.Repository;


namespace TMS_Logistics.API
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
            //连接字符串
            ConnString.connstring = Configuration.GetConnectionString("default");
            //services.AddTransient<ILogin, Login>();
            services.AddControllers();

            // 注册Swagger服务
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TMS_Logistics.API",
                    Version = "v1",
                    Description = "TMS_Logistics API"
                }
                );
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "基础接口",
                    Description = "用户登录认证接口"
                });

                // 为 Swagger 设置xml文档注释路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);
            });

            //JWT
            var jwtConfig = Configuration.GetSection("Jwt");
            //生成密钥
            var symmetricKeyAsBase64 = jwtConfig.GetValue<string>("Secret"); 
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64); 
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            //认证参数
            services.AddAuthentication("Bearer")
                .AddJwtBearer(o => 
                { o.TokenValidationParameters = new TokenValidationParameters { 
                    ValidateIssuerSigningKey = true,//是否验证签名,不验证的画可以篡改数据，不安全

                    IssuerSigningKey = signingKey,//解密的密钥
                    ValidateIssuer = true,//是否验证发行人，就是验证载荷中的Iss是否对应 ValidIssuer参数
                                          
                    ValidIssuer = jwtConfig.GetValue<string>("Iss"),//发行人
                    ValidateAudience = true,//是否验证订阅人，就是验证载荷中的Aud是否对应 ValidAudience参数
                    ValidAudience = jwtConfig.GetValue<string>("Aud"),//订阅人
                    ValidateLifetime = true,//是否验证过期时间，过期了就拒绝访问
                    ClockSkew = TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期 时间，这里也要考虑进去，过期时间+缓冲，默认好像是7分钟，你可以直接设置为0
                    RequireExpirationTime = true,
                         };
                 });

        }

        //依赖注入
        public void ConfigureContainer(ContainerBuilder build)
        {
            var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS-Logistics.Repository.dll"); 
            build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath)).AsImplementedInterfaces();
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS_Logistics.API v1"));
            }
            app.UseAuthentication();//这个是添加认证

            app.UseAuthorization(); //这个是方法里自带的授权

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
