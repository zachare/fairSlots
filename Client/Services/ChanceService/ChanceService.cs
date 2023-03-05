using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;

namespace fairSlots.Client.Services.ChanceService
{
    // Provides a service that handles client-side Chance HTTP operations
    // To be injected into client-side pages
    public class ChanceService : IChanceService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ChanceService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Chance> Chances { get; set; } = new List<Chance>();
        public List<Player> Players { get; set; } = new List<Player>();

        public async Task CreateChance(Chance chance)
        {
            var result = await _http.PostAsJsonAsync("api/chance", chance);
            await SetChances(result);
        }

        private async Task SetChances(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Chance>>();
            Chances = response;
            _navigationManager.NavigateTo("chances");
        }

        public async Task DeleteChance(int id)
        {
            var result = await _http.DeleteAsync($"api/chance/{id}");
            await SetChances(result);
        }

        public async Task GetChances()
        {
            var result = await _http.GetFromJsonAsync<List<Chance>>("api/chance");
            if (result != null)
                Chances = result;

        }

        public async Task GetPlayers()
        {
            var result = await _http.GetFromJsonAsync<List<Player>>("api/chance/player");
            if (result != null)
                Players = result;
        }

        public async Task<Chance> GetSingleChance(int id)
        {
            var result = await _http.GetFromJsonAsync<Chance>($"api/chance/{id}");
            if (result != null)
                return result;
            throw new Exception("Chance not found!");
        }

        public async Task UpdateChance(Chance chance)
        {
            var result = await _http.PutAsJsonAsync($"api/chance/{chance.PlayerID}", chance);
            await SetChances(result);
        }
    }
}
