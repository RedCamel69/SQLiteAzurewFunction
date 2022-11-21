using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using SQLiteFunction.Models;
using System.IO;

[assembly: FunctionsStartup(typeof(SQLiteFunction.StartUp))]
namespace SQLiteFunction
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            File.Copy("D:\\home\\site\\wwwroot\\school.db", "D:\\home\\school.db");
            File.SetAttributes("D:\\home\\school.db", FileAttributes.Normal);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlite(Utils.GetSQLiteConnectionString());
                options.UseSqlite("Data source = D:\\home\\school.db");
            });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);
        }

    }
}