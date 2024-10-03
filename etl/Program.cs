using etl.Data;
using etl.Services;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Configurando host builder e injeção de dependência
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Pegar a connection string do arquivo de configuração
                var connectionString = context.Configuration.GetConnectionString("MySQLConnection");

                // Configurar DbContext com MySQL
                services.AddDbContext<MyDbContext>(options =>
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

                services.AddTransient<CsvService>();
            })
            .Build();

        var csvService = host.Services.GetRequiredService<CsvService>();
        csvService.ProcessCsv("C:\\Users\\Marili\\Desktop\\Nanda\\CURRICULO\\dts - data solution\\etl2\\bloomberg-data.csv").Wait();
    }
}

