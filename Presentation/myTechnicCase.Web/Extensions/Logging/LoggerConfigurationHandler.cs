using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;

namespace myTechnicCase.Web.Extensions.Logging
{
    public static class LoggerConfigurationHandler
    {
        public static Logger GetConfiguratedLogger(IConfiguration configuration)
        {
            Logger logger = new LoggerConfiguration().WriteTo.Console()
               .WriteTo.File("logs/log.txt").WriteTo.MSSqlServer(
               connectionString: configuration.GetConnectionString("myTechnicLoggingDb"),
               sinkOptions: new MSSqlServerSinkOptions
               {
                   AutoCreateSqlDatabase = true,
                   AutoCreateSqlTable = true,
                   TableName = "Logs"
               }).Enrich.FromLogContext()
               .MinimumLevel.Information()
               .CreateLogger();
            return logger;
        }
    }
}
