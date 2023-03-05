using System.Numerics;

namespace fairSlots.Client.Services.PlayerService
{
    // Initializes the IPlayerService interface to be inherited by PlayerService
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
