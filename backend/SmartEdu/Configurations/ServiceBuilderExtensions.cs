using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartEdu.Data;
using SmartEdu.Models;
using SmartEdu.Services.AuthService;
using SmartEdu.Services.EmailService;
using SmartEdu.Services.AccountService;
using SmartEdu.UnitOfWork;
using Serilog;
using System.Text;
using Hangfire;
using Hangfire.SqlServer;
using Twilio.Clients;
using SmartEdu.Services.SmsService;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Marvin.Cache.Headers;
using AspNetCoreRateLimit;
using System.Reflection;
using SmartEdu.Entities;
using SmartEdu.Services.BunnyService;
using SmartEdu.Services.SeederService;
using SmartEdu.Services.ClassService;
using SmartEdu.Services.CrawlerService;
using SmartEdu.Services.DocumentService;

namespace SmartEdu.Configurations
{
    public static class ServiceBuilderExtensions
    {

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = Environment.GetEnvironmentVariable("SE_DB");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(u => u.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureTokenLifespan(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(2));
        }

        public static void ConfigureCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void ConfigureSerilog(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var key = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IBunnyService, BunnyService>();
            services.AddScoped<ISeederService, SeederService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICrawlerService, CrawlerService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddHttpClient();
        }

        public static void ConfigureExternalAuth(this IServiceCollection services)
        {
            services.Configure<GoogleAuthOptions>(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable("PHA_GG_C_ID");
                options.ClientSecret = Environment.GetEnvironmentVariable("PHA_GG_C_S");
            });

            services.Configure<FacebookAuthOptions>(options =>
            {
                options.AppId = long.Parse(Environment.GetEnvironmentVariable("PHA_FB_A_ID"));
                options.AppSecret = Environment.GetEnvironmentVariable("PHA_FB_A_S");
            });
        }

        public static void ConfigureEmaill(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailOptions>();
            var password = Environment.GetEnvironmentVariable("PHA_M_PWD");
            var username = Environment.GetEnvironmentVariable("PHA_M_U");
            emailConfig.Username = username;
            emailConfig.Password = password;
            services.AddSingleton(emailConfig);
        }

        public static void ConfigureClientApp(this IServiceCollection services, IConfiguration configuration)
        {
            var clientAppConfig = configuration.GetSection("ClientAppConfiguration").Get<ClientAppOptions>();
            services.AddSingleton(clientAppConfig);
        }

        //public static void ConfigureHangfire(this IServiceCollection services, IConfiguration config)
        //{
        //    // Add Hangfire services
        //    services.AddHangfire(configuration => configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180).UseSimpleAssemblyNameTypeSerializer().UseRecommendedSerializerSettings());

        //    // Storage in the only thing required for basic configuration.
        //    // Just discover what configuration options do you have.

        //    var options = new SqlServerStorageOptions
        //    {
        //        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        //        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        //        QueuePollInterval = TimeSpan.Zero,
        //        UseRecommendedIsolationLevel = true,
        //        DisableGlobalLocks = true,
        //    };


        //    var connectionString = config.GetConnectionString("HangfireConnection");
        //    GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString, options);

        //    // Add the processing server as IHostedService
        //    services.AddHangfireServer();

        //    //BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));
        //    //RecurringJob.AddOrUpdate("easyjob", () => Console.WriteLine("Easy!"), Cron.Minutely);

        //    RecurringJob.RemoveIfExists("easyjob");
        //    RecurringJob.RemoveIfExists("scan_db_and_send_reminders");
        //    //RecurringJob.AddOrUpdate<IReminderService>("scan_db_and_send_reminders", rs => rs.ScanDbAndSendReminders(), "*/30 * * * *");
        //}

        public static void ConfigureTwilio(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ITwilioRestClient, TwilioClient>();
            var verificationServiceSID = Environment.GetEnvironmentVariable("PHA_TW_VS");
            services.Configure<TwilioVerifyOptions>(tvs => tvs.VerificationServiceSID = verificationServiceSID);

        }

        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme, e.g. \"bearer {token} \"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SmartEdu API",
                    Description = "An ASP.NET Core Web API for managing app items.",
                    License = new OpenApiLicense
                    {
                        Name = "GitHub Repository",
                        Url = new Uri("https://github.com/leonghia/smart-edu")
                    }
                });

                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        Log.Error($"Something went wrong in the {contextFeature.Error}");
                        await context.Response.WriteAsync(new ServerResponse<object>
                        {
                            Succeeded = false,
                            Message = "Internal server error."
                        }.ToString());
                    }
                });
            });
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }

        public static void ConfigureHttpCacheHeaders(this IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddHttpCacheHeaders(
                (expirationOpt) =>
                {
                    expirationOpt.MaxAge = 120;
                    expirationOpt.CacheLocation = CacheLocation.Private;
                },
                (validationOpt) =>
                {
                    validationOpt.MustRevalidate = true;
                });
        }

        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Limit = 1,
                    Period = "1s"
                }
            };
            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }

        public static async Task PromptDatabase(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var seederService = scope.ServiceProvider.GetRequiredService<ISeederService>();
            Console.Write("Do you want to re-create the database (Y/n): ");
            var selection = Console.ReadLine();
            if (selection is not null)
            {
                selection = selection.Trim().ToUpper();
                if (selection == "Y")
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                    Console.WriteLine("Database re-created.");                
                }
            }
            await seederService.SeedingData();
        }
    }
}
