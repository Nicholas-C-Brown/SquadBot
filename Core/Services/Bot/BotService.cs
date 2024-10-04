using Discord.WebSocket;
using SquadBot.Core.Configuration;

namespace SquadBot.Core.Services.Bot
{
    public class BotService : IBotService
    {

        private readonly Settings settings;
        private readonly DiscordSocketClient client;

        public BotService(Settings settings, DiscordSocketClient client)
        {
            this.settings = settings;
            this.client = client;
        }

        public async Task StartBotAsync()
        {
            await client.LoginAsync(Discord.TokenType.Bot, settings.Token);
            await client.StartAsync();

            client.Ready += () =>
            {
                Console.WriteLine("Squadbot Started!");
                return Task.CompletedTask;
            };

            //Run forever
            await Task.Delay(-1);
        }

    }
}
