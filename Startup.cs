using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop1.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.ResponseCompression;
using System.Linq;
using Microsoft.OpenApi.Models;
// using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Shop1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //esse metodo informa quais serviços usaremos
        public void ConfigureServices(IServiceCollection services)
        {
            //comprimi o json
            services.AddCors();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/json"} );
            });
            services.AddResponseCaching();
            services.AddControllers();

           //parte da autenticação do token e etc..
            // var key = Encoding.ASCII.GetBytes(Settings.Secret);
            // services.AddAuthentication(x => 
            // {
            //         x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //         x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            // }).Jwt(x =>
            // {
            //         X.RequiredHttpsMetadata = false;
            //         x.SaveToken = true;
            //         X.TokenValidationParameters = new TokenValidationParameters;
            //         {
            //             ValidateIssuerSigningKey = true,
            //             IssuerSigningKey = new SymmetricSecurityKey(key),
            //             ValidateIssuer = false,
            //             ValidateAudience = false

            //         };
            // });
            
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            // services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
           // services.AddScoped<DataContext, DataContext >(); // ele garante apenas um data context para que não haja mais conexões abertas
           // e fecha conexão com banco

          //usado para chamar o swagger
            services.AddSwaggerGen(c => 
           {
              c.SwaggerDoc("v1", new OpenApiInfo{Title = "Shop Api", Version = "v1"});
           });
        

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // esse metodo configura o que sera usado dos serviços
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())//verifica a varivel de ambiente
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();// redireciona nossa aplicação para https

            app.UseSwagger();

            app.UseSwaggerUI(c =>{
            
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop Api v1");
                     
            });

            app.UseRouting();//serviço que cuida das rotas

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();// serviço de autorização
               // serviço para criação de endpoints 
            app.UseAuthentication();
               
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
