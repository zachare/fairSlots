using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Numerics;

namespace fairSlots.Client.Services.PlayerService
{
    // Provides a service that handles client-side Player HTTP operations
    // To be injected into client-side pages
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PlayerService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Player> Players { get; set; } = new List<Player>();

        public async Task CreatePlayer(Player player)
        {
            var result = await _http.PostAsJsonAsync("api/player", player);
            await SetPlayers(result);
        }

        private async Task SetPlayers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Player>>();
            Players = response;
            _navigationManager.NavigateTo("players");
        }

        public async Task DeletePlayer(int id)
        {
            var result = await _http.DeleteAsync($"api/player/{id}");
            await SetPlayers(result);
        }

        public async Task<Player> GetSinglePlayer(int id)
        {
            var result = await _http.GetFromJsonAsync<Player>($"api/player/{id}");
            if (result != null)
                return result;
            throw new Exception("This player does not exist.");
        }

        public async Task GetPlayers()
        {
            var result = await _http.GetFromJsonAsync<List<Player>>("api/player");
            if (result != null)
                Players = result;
        }

        public async Task UpdatePlayer(Player player)
        {
            var result = await _http.PutAsJsonAsync($"api/player/{player.PlayerID}", player);
            await SetPlayers(result);
        }
    }
}
