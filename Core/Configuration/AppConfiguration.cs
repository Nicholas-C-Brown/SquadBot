using Microsoft.Extensions.Configuration;

namespace SquadBot.Core.Configuration
{
    public static class AppConfiguration
    {

        public static Settings BuildAppSettings()
        {

            var envConfiguration = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            var environment = envConfiguration["ENVIRONMENT"];
            Console.WriteLine("Starting Environment: " + environment);

            var token = envConfiguration["APP_TOKEN"];

            return new Settings()
            {
                Token = token,
            };
        }

    }
}
