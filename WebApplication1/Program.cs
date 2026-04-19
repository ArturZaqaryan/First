using FluentValidation.AspNetCore;
using FluentValidation;
using WebApplication1.Clients;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;
using WebApplication1.Validators;
using WebApplication1.Repositories;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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
        builder.Services.AddScoped<IUsersService, Services.HTTP.UsersService>();
        builder.Services.AddScoped<IProductsService, Services.HTTP.ProductsService>();
        builder.Services.AddScoped<IPostsService, Services.HTTP.PostsService>();

        builder.Services.AddSingleton<IMonitoringService, MonitoringService>();
        builder.Services.AddScoped(typeof(CounterService));

        builder.Services.AddSingleton<UserRepository>();

        builder.Services.AddScoped<IPaymentsService, ArCaPaymentsService>();

        builder.Services.AddControllers();

        builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

        builder.Services.AddFluentValidationAutoValidation();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
