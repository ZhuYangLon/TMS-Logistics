using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Swashbuckle.AspNetCore.Filters;
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

                #region swagger用JWT验证
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",// t默认的参数名称
                    In = ParameterLocation.Header,// t默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                #endregion
                // 为 Swagger 设置xml文档注释路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);
            });


            #region 注册jwt中间件
            services.AddTransient<JWTService>();

            #endregion

            #region JWT配置
            services.AddAuthentication(options =>
            {
                //认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 //主要是jwt  token参数设置
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     //颁发者
                     ValidateIssuer = true,
                     ValidIssuer = Configuration["JwtSetting:Issuer"],
                     //被授权者
                     ValidateAudience = true,
                     ValidAudience = Configuration["JwtSetting:Audience"],
                     //秘钥
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSetting:SecretKey"])),
                     //是否验证失效时间【使用当前时间与Token的Claims中的NotBefore和Expires对比】
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.FromMinutes(5)//允许的服务器时间偏移量【5分钟】
                 };
             });

            #endregion;

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
