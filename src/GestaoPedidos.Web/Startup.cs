using GestaoPedidos.Infrastructure.Data.Configuration;
using GestaoPedidos.Web;
using GestaoPedidos.Web.DependencyInjections;

namespace GestaoPedidosWeb;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
        AppSettings appSettings = new();
        Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);
        services.AddControllers();
        
        services.AddControllers(options => { });
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddServices();
        services.AddHealthChecks();
        services.AddMappers();
        services.AddDatabase(appSettings.DatabaseConnection);
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new()
            {
                Title = "Swagger Gestão de Pedidos WEB API",
                Description = "Aplicação para gestão de pedidos do restaurante"
            });
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "GestaoPedidos.xml");
            c.IncludeXmlComments(filePath);
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseDeveloperExceptionPage();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

            options.RoutePrefix = "/swagger";
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}