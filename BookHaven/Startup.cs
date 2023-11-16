using BookHaven.Common.Automapper;
using BookHaven.Domain.RequestDTOFluentValidations;
using BookHaven.UI.Models.ViewModel;
using FluentValidation.AspNetCore;
using Serilog;

public class Startup
{
    private readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add logging with Serilog
        var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("Serilog/BookHaven_Log.txt", rollingInterval: RollingInterval.Minute)
        .MinimumLevel.Information()
        .CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(logger));
        Log.Logger = logger;  // Set the global logger



        // Configure services here
        //services.AddDbContext<BookHavenDbContext>(options =>
        //    options.UseSqlServer(Configuration.GetConnectionString("BookHavenConnectionString")));
    //    services.AddDbContext<UserDbContext>(options =>
    //       options.UseSqlServer(Configuration.GetConnectionString("AuthenticationConnectionString")));
    //    services.AddIdentity<IdentityUser, IdentityRole>()
    //.AddEntityFrameworkStores<UserDbContext>();
        //.AddDefaultTokenProviders();



		// Configure FluentValidation for controllers
		services.AddControllersWithViews()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBookPostRequest>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookHavenTagValidation>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BookHavenCommentValidation>());

        // Configure AutoMapper
        services.AddAutoMapper(typeof(BookHavenAutomapper));

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true; // Convert URLs to lowercase
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        // Configure middleware here
        app.UseExceptionHandler("/Home/Error");
    }
}
