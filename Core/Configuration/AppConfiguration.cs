using Microsoft.Extensions.Configuration;

namespace SquadBot.Core.Configuration
{
    public static class AppConfiguration
    {

        public static Settings BuildAppSettings()
        {

            var envConfiguration = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            var environment = envConfiguration["RUNTIME_ENVIRONMENT"];
            Console.WriteLine("Starting Environment: " + environment);

            var token = envConfiguration["TOKEN"];

            return new Settings()
            {
                Token = token,
            };
        }

    }
}
