using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using WebApplication1.Clients;
using WebApplication1.Middlewares;
using WebApplication1.Repositories;
using WebApplication1.Services.Abstract;
using WebApplication1.Validators;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddHttpClient<PostsClient>(client =>
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts/");
        });

        builder.Services.AddHttpClient<ProductsClient>(client =>
        {
            client.BaseAddress = new Uri("https://fakestoreapi.com/products/");
        });

        builder.Services.AddHttpClient<UsersClient>(client =>
        {
            client.BaseAddress = new Uri("https://reqres.in/api/users/");
            client.DefaultRequestHeaders.Add("x-api-key", "reqres_902cbf1ee1eb4a4db6ed8ef5f4abde48");
        });

        // Add services to the container.
        builder.Services.AddScoped<IUsersService, Services.Simple.UsersService>();
        builder.Services.AddScoped<IProductsService, Services.HTTP.ProductsService>();
        builder.Services.AddScoped<IPostsService, Services.HTTP.PostsService>();

        builder.Services.AddSingleton<IMonitoringService, Services.Simple.MonitoringService>();
        builder.Services.AddScoped(typeof(Services.Simple.CounterService));

        builder.Services.AddSingleton<Repositories.Abstract.IUserRepository, UserRepository>();

        builder.Services.AddScoped<IPaymentsService, Services.Simple.ArCaPaymentsService>();

        builder.Services.AddControllers().AddNewtonsoftJson();

        builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

        builder.Services.AddFluentValidationAutoValidation();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
