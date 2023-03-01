using System.Numerics;

namespace fairSlots.Client.Services.PlayerService
{
    public interface IPlayerService
    {
        List<Player> Players { get; set; }
        Task GetPlayers();
        Task<Player> GetSinglePlayer(int id);
        Task CreatePlayer(Player player);
        Task UpdatePlayer(Player player);
        Task DeletePlayer(int id);
    }
}
