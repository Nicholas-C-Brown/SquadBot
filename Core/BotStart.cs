using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using SquadBot.Core.Configuration;
using SquadBot.Core.Services.Bot;
using SquadBot.Core.Services.Messaging;

namespace SquadBot.Core
{
    public static class BotStart
    {

        static async Task Main(string[] args)
        {

            System.Diagnostics.Trace.WriteLine("Starting App");

            var serviceProvider = CreateSquadBotServiceProvider();

            //Start Services
            serviceProvider.GetRequiredService<IMessagingService>().StartService();

            //Start Bot
            await serviceProvider.GetRequiredService<IBotService>().StartBotAsync();
        }

        private static IServiceProvider CreateSquadBotServiceProvider()
        {
            var appSettings = AppConfiguration.BuildAppSettings();
            var discordSocketConfig = GetDiscordSocketConfig();
            
            var collection = new ServiceCollection()
                .AddSingleton(appSettings)
                .AddSingleton(discordSocketConfig)
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<IMessagingService, MessagingService>()
                .AddSingleton<IBotService, BotService>();

            return collection.BuildServiceProvider();
        }

        public static DiscordSocketConfig GetDiscordSocketConfig()
        {
            return new DiscordSocketConfig()
            {
                GatewayIntents = Discord.GatewayIntents.All
            };
        }

    }
}
