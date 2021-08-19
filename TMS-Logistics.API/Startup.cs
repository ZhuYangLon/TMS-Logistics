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
            //�����ַ���
            ConnString.connstring = Configuration.GetConnectionString("default");
            //services.AddTransient<ILogin, Login>();
            services.AddControllers();

            // ע��Swagger����
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
                    Title = "�����ӿ�",
                    Description = "�û���¼��֤�ӿ�"
                });

                // Ϊ Swagger ����xml�ĵ�ע��·��
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // ��ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
                c.IncludeXmlComments(xmlPath, true);
            });

            //JWT
            var jwtConfig = Configuration.GetSection("Jwt");
            //������Կ
            var symmetricKeyAsBase64 = jwtConfig.GetValue<string>("Secret"); 
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64); 
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            //��֤����
            services.AddAuthentication("Bearer")
                .AddJwtBearer(o => 
                { o.TokenValidationParameters = new TokenValidationParameters { 
                    ValidateIssuerSigningKey = true,//�Ƿ���֤ǩ��,����֤�Ļ����Դ۸����ݣ�����ȫ

                    IssuerSigningKey = signingKey,//���ܵ���Կ
                    ValidateIssuer = true,//�Ƿ���֤�����ˣ�������֤�غ��е�Iss�Ƿ��Ӧ ValidIssuer����
                                          
                    ValidIssuer = jwtConfig.GetValue<string>("Iss"),//������
                    ValidateAudience = true,//�Ƿ���֤�����ˣ�������֤�غ��е�Aud�Ƿ��Ӧ ValidAudience����
                    ValidAudience = jwtConfig.GetValue<string>("Aud"),//������
                    ValidateLifetime = true,//�Ƿ���֤����ʱ�䣬�����˾;ܾ�����
                    ClockSkew = TimeSpan.Zero,//����ǻ������ʱ�䣬Ҳ����˵����ʹ���������˹��� ʱ�䣬����ҲҪ���ǽ�ȥ������ʱ��+���壬Ĭ�Ϻ�����7���ӣ������ֱ������Ϊ0
                    RequireExpirationTime = true,
                         };
                 });

        }

        //����ע��
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
            app.UseAuthentication();//����������֤

            app.UseAuthorization(); //����Ƿ������Դ�����Ȩ

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
