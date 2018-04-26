using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace XUnitAndCore.Base
{
    public class TestBase : IDisposable
    {
        protected IConfiguration Configuration { get; set; }
        protected TestBase()
        {
            SetEnvironment();
            Configuration = GetConfiguration();
        }

        public virtual void Dispose()
        {
        }

        protected IConfiguration GetConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        protected void SetEnvironment()
        {
            try
            {
                var aspnetcoreEnvironment = "ASPNETCORE_ENVIRONMENT";
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable(aspnetcoreEnvironment)))
                    return;
                //dynamic settings =
                //    JsonConvert.DeserializeObject(File.ReadAllText("..\\..\\..\\Properties\\launchSettings.json"));
                dynamic settings =
                    JsonConvert.DeserializeObject(File.ReadAllText("launchSettings.json"));
                var env = settings.profiles[Assembly.GetExecutingAssembly().GetName().Name]["environmentVariables"][aspnetcoreEnvironment].Value;
                Environment.SetEnvironmentVariable(aspnetcoreEnvironment, env);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to set the environment variable", ex);
            }
        }
    }
}
