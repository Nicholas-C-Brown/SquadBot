using Discord.WebSocket;

namespace SquadBot.Core.Services.Messaging
{
    public static class MessageActions
    {

        public static async Task ReplyAsync(SocketMessage message, string response)
        {
            await message.Channel.SendMessageAsync(response);
        }

    }
}
