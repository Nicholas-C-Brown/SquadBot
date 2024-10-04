using Discord.WebSocket;
using Newtonsoft.Json;
using SquadBot.Core.Http;
using System.Net.Http.Headers;

namespace SquadBot.Core.Services.Messaging.Commands
{
    public class JokeCommand : Command
    {

        private const string DAD_JOKE_URL = "https://icanhazdadjoke.com/";

        public override string Name => "Joke";

        public override string Description => "Get a random dad joke";

        public async override Task ExecuteAsync(SocketMessage message)
        {

            DadJokeResponse? response = await HttpRequestHandler.GetRequest<DadJokeResponse>(DAD_JOKE_URL, "application/json");
            string reply = response?.Joke ?? "Sorry no dad jokes at this time...";

            await MessageActions.ReplyAsync(message, reply);
        }

        [JsonObject]
        sealed class DadJokeResponse
        {
            [JsonProperty("id")] public string Id { get; set; }
            [JsonProperty("joke")] public string Joke { get; set; }
            [JsonProperty("status")] public int Status { get; set; }
        }


    }
}
