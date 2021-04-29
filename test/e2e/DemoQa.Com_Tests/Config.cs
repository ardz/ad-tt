using Microsoft.Extensions.Configuration;

namespace DemoQa.Com_Tests
{
    public class Config
    {
        public IConfiguration TestConfiguration { get; }

        public Config()
        {
            TestConfiguration = new ConfigurationBuilder()
                .AddJsonFile(System.IO.Directory.GetCurrentDirectory() + "\\appsettings.json")
                .Build();
        }
    }
}