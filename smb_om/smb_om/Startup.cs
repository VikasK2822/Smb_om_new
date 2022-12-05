using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using smb_om.Middleware;
using smb_om.Data;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using smb_om.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace smb_om
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = ".SMB";
            });
            services.AddControllersWithViews();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ProducesAttribute("text/xml"));
                options.OutputFormatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter(new XmlWriterSettings
                {
                    OmitXmlDeclaration = false
                }));
            }).AddXmlSerializerFormatters();

            services.AddDbContext<DataContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DataContext")));

       

            //services.AddDbContext<DataContext>(options =>
            //    options.UseMySql(Configuration.GetConnectionString("DataContext"), ServerVersion.AutoDetect(Configuration.GetConnectionString("DataContext"))));


            services.AddTransient<Ilogin, LoginRepository>();
            services.AddTransient<IChangePassword, ChangePasswordRepository>();
            services.AddTransient<Imlp, MlpRepository>();
            services.AddTransient<IAffiliate, AffiliateRepository >();
            services.AddTransient<IOrderProcess, OrderProcessRepository>();
            services.AddTransient<IDwqIncomplete, DwqIncompleteRepository>();
            services.AddTransient<IDwqCheckInstall,DwqCheckInstallRepository>();
            services.AddTransient<Iviewlog, ViewlogRepository>();
            services.AddTransient<IQueueSummary, QueueRepository>();
            services.AddTransient<ISpecialProjectType, SpecialProjectTypeRepository>();
            services.AddTransient<IQuickSearch, QuickSearchRepository>();
            services.AddTransient<IReasonCode, ReasonCodeRepository>();
            services.AddTransient<IHolidayCalendar, HolidayCalendarRepository>();
            services.AddTransient<ISalesCode, SalesCodeRepository>();
            services.AddTransient<IBrv, BrvRepository>();
            services.AddTransient<IProductReasonCode, ProductReasonCodeRepository>();
            services.AddTransient<ICallTracker, CallTrackerRepository>();
            services.AddTransient<Iemail, EmailRepository>();
            services.AddTransient<IproductInformation, ProductInformationRepository>();
            services.AddTransient<INotificationUrl, NotificationRepository>();
            services.AddTransient<IAffiliateReasonCode, AffiliateReasonCodeRepository>();
            services.AddTransient<ICallType, CallTypeRepository>();

            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddControllersWithViews();
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
        //    app.UseAntiXssMiddleware();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");
                // pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});
        }
    }
}
