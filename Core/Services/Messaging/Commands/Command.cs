using Discord.WebSocket;

namespace SquadBot.Core.Services.Messaging.Commands
{
    public abstract class Command
    {

        public static readonly List<Command> Commands = [
            new HelpCommand(),
            new JokeCommand()
        ];

        public abstract string Name { get; }
        public abstract string Description { get; }

        public override string ToString()
        {
            return "!" + Name.ToLower() + ": " + Description;
        }

        public static bool IsCommand(SocketMessage message)
        {
            return message.Content.StartsWith('!');
        }

        public abstract Task ExecuteAsync(SocketMessage message);

    }
}
