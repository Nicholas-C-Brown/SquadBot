using Discord.WebSocket;
using System.Text;

namespace SquadBot.Core.Services.Messaging.Commands
{
    internal class HelpCommand : Command
    {
        public override string Name => "Help";

        public override string Description => "Provides a list of all commands and their descriptions";

        public async override Task ExecuteAsync(SocketMessage message)
        {
            StringBuilder builder = new StringBuilder();
            Commands.ForEach(c => builder.Append(c.ToString() + "\n\n"));
            await MessageActions.ReplyAsync(message, builder.ToString());
        }
    }
}
