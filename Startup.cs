using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using StartupProject_Asp.NetCore_PostGRE.Services.EmailService;
using WebMarkupMin.AspNetCore3;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.AuthorizationRequirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;

namespace StartupProject_Asp.NetCore_PostGRE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region IP Address Reading support
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(
                        IPAddress.Parse(Configuration.GetSection("ApplicationIP").Value)
                    );
            });
            #endregion
            #region Email Service Configuration
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            #endregion
            #region DB Service Configuration
            services.AddDbContext<ApplicationDbContext>(options => {
                if (Environment.IsDevelopment())
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DevelopConnection"));
                }
                else
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                }
            });
            #endregion
            #region Identity Service Configuration
            services.AddIdentity<User, Role>(options => {
                    //Password Settings
                    if (Environment.IsDevelopment())
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 4;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequiredUniqueChars = 2;
                    }
                    else
                    {
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequiredLength = 8;
                    }
                    // Lockout settings.
                    options.Lockout = new LockoutOptions(){
                        AllowedForNewUsers = true,
                        DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                        MaxFailedAccessAttempts = 5
                    };

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;

                    //Sign In Settings
                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
            #endregion
            #region Policies Configuration in Auth
            services.AddAuthorization(options => {
                //options.AddPolicy("MustHaveEmail", polBuilder => polBuilder.RequireClaim(System.Security.Claims.ClaimTypes.Email));
                //options.AddPolicy("IsAdminClaimAccess", policy => policy.RequireClaim("DateOfJoing"));
                //options.AddPolicy(EPolicy.RoleClaimView.ToString(), policy => policy.Requirements.Add(new RoleClaimPolicyRequirement(EPolicy.RoleClaimView)));

                //options.AddPolicy("IsAdminClaimAccess", policy => policy.Re
                //options.AddPolicy("Morethan365DaysClaim", policy => policy.Requirements.Add(new MinimumTimeSpendRequirement(365)));
                //options.AddPolicy("Morethan365DaysClaim", policy => policy.AuthenticationSchemes.);
                foreach (object eClaimValue in Enum.GetValues(typeof(EClaim)))
                {
                    //string description = ((EClaim)eClaimValue).Description() + eClaimValue.ToString();

                    options.AddPolicy(eClaimValue.ToString(), policy => policy.Requirements.Add(new ClaimsRoleRequirement(eClaimValue)));
                }
            });
            // Add all of your handlers to DI.
            services.AddTransient<IAuthorizationHandler, ClaimsRoleRequirementHandler>();
            #endregion
            #region Update Auth every second after role updated
            //https://stackoverflow.com/a/58117517/2193439
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                //options.ValidationInterval = TimeSpan.FromSeconds(1);
                options.ValidationInterval = TimeSpan.Zero;

            });
            #endregion
            #region View Configuration
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddWebMarkupMin(
                options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    options.AllowCompressionInDevelopmentEnvironment = true;
                })
                .AddHtmlMinification(
                    options =>
                    {
                        options.MinificationSettings.RemoveRedundantAttributes = true;
                        options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                        options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                    })
                .AddHttpCompression();
            #endregion
            #region Cache Configuration
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60); //60 days
                //options.ExcludedHosts.Add("example.com");
                //options.ExcludedHosts.Add("www.example.com");
            });
            #endregion
            #region Force to use Https Config
            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 443;
            //});
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //IWebHostEnvironment env - Can be removed
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region Forward all headers to server if any reverse proxy server like Nginx is used
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            //Allowed for IP - 127.0.0.0/8, [::1]
            //More can be found in here - https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-5.0#configure-a-proxy-server
            #endregion

            #region Handle http pipeline for making custom action for different error codes
            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Request.Path = "/Home";
            //        await next();
            //    }
            //});
            //app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");
            #endregion
            app.UseHttpsRedirection();  //Can be ignored
            #region Configure Cache for static files
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context => context.Context.Response.GetTypedHeaders()
                  .CacheControl = new CacheControlHeaderValue
                  {
                      NoTransform = true,
                      Public = true,
                      //OnlyIfCached = false,
                      MaxAge = TimeSpan.FromDays(365) // 1 year
                  }
            });
            #endregion
            app.UseWebMarkupMin();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            #region Configure URL Convention
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //        name: "auth",
                //        pattern: "auth/{controller=Account}/{action=Register}/{id?}"
                //    );
                //endpoints.MapAreaControllerRoute(
                //                     name: "default",
                //                     areaName: "Self",
                //                     pattern: "{area=Self}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapRazorPages();
            });
            #endregion
        }
    }
}