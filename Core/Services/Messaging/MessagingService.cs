using Discord.WebSocket;
using SquadBot.Core.Services.Messaging.Commands;

namespace SquadBot.Core.Services.Messaging
{
    public class MessagingService : IMessagingService
    {

        private readonly DiscordSocketClient client;

        public MessagingService(DiscordSocketClient client)
        {
            this.client = client;
        }

        public void StartService()
        {
            client.MessageReceived += HandleMessage;

            Console.WriteLine("Message Service Started!");
        }

        private async Task HandleMessage(SocketMessage message)
        {
            //Do not reply to other bots!!
            if (message.Author.IsBot)
            {
                return;
            }

            //Handle Commands
            if (Command.IsCommand(message))
            {
                await HandleCommand(message);
                return;
            }

            if (ContentContains(message, "Hello Squadbot"))
            {
                await SayHello(message);
            }

        }

        private async Task HandleCommand(SocketMessage message)
        {
            Command? command = Command.Commands.Find(c => ContentContains(message, c.Name));

            if (command != null)
            {
                await command.ExecuteAsync(message);
            }
            else
            {
                await MessageActions.ReplyAsync(message, "Unknown command, please enter !help to see a list of commands.");
            }
        }

        private async Task SayHello(SocketMessage message)
        {
            await MessageActions.ReplyAsync(message, "Hello, " + message.Author.Username + "!");
        }

        private bool ContentContains(SocketMessage message, string value)
        {
            return message.Content.Contains(value, StringComparison.OrdinalIgnoreCase);
        }




    }
}
