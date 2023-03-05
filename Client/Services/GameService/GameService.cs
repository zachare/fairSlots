using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;

namespace fairSlots.Client.Services.GameService
{
    // Provides a service that handles client-side Game HTTP operations
    // To be injected into client-side pages
    public class GameService : IGameService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public GameService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Game> Games { get; set; } = new List<Game>();
        public List<Player> Players { get; set; } = new List<Player>();

        public async Task CreateGame(Game game)
        {
            var result = await _http.PostAsJsonAsync("api/game", game);
            await SetGames(result);
        }

        private async Task SetGames(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Game>>();
            Games = response;
            _navigationManager.NavigateTo("gamehistory");
        }

        public async Task DeleteGame(int id)
        {
            var result = await _http.DeleteAsync($"api/game/{id}");
            await SetGames(result);
        }

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

        public async Task UpdateGame(Game game)
        {
            var result = await _http.PutAsJsonAsync($"api/game/{game.GameID}", game);
            await SetGames(result);
        }
    }
}
