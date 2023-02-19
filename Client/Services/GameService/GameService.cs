using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace fairSlots.Client.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly HttpClient _http;

        public GameService(HttpClient http)
        {
            _http = http;
        }
        public List<Game> Games { get; set; } = new List<Game>();
        public List<Player> Players { get; set; } = new List<Player>();

        public async Task GetGames()
        {
            var result = await _http.GetFromJsonAsync<List<Game>>("api/game");
            if (result != null)
                Games = result;

        }

        public async Task GetPlayers()
        {
            var result = await _http.GetFromJsonAsync<List<Player>>("api/game/player");
            if (result != null)
                Players = result;
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var result = await _http.GetFromJsonAsync<Game>($"api/game/{id}");
            if (result != null)
                return result;
            throw new Exception("Game not found!");
        }
    }
}
