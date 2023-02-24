using Dapper;
using MySqlConnector;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<MySqlConnection>(X=>new MySqlConnection("Server=127.0.0.1;Port=3306;Database=sms_provider_api;uid=root;password=123456Ab;Convert Zero Datetime=True;usexatransactions=false"));
        
        var app = builder.Build();

        MySqlConnection sqlConnection= app.Services.GetRequiredService<MySqlConnection>();
        var result= sqlConnection.QueryAsync("SELECT * FROM sms_provider_api.resource_status;");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
