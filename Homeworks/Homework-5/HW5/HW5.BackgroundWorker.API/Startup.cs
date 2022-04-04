using HW5.BackgroundWorker.API.Background;
using HW5.Business.Abstracts;
using HW5.Business.Concretes;
using HW5.DataAccess.EntityFramework;
using HW5.DataAccess.EntityFramework.Repository.Abstracts;
using HW5.DataAccess.EntityFramework.Repository.Concretes;
using HW5.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HW5.BackgroundWorker.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = " HW5.BackgroundWorker.API", Version = "v1" });
            });

            // Adding all defined services:
            // Database Connection Service
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            // AddTransient() -> A new instance of a Transient service is created each time it is requested.
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPostService, PostService>();

            // Background Queue Structure for Background Processing
            services.AddSingleton<IBackgroundQueue<Post>, BackgroundQueue<Post>>();
            // Background Services
            services.AddHostedService<RecorderWorker>();
            services.AddHostedService<RetrieverWorker>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", " HW5.BackgroundWorker.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
