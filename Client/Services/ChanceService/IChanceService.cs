namespace fairSlots.Client.Services.ChanceService
{
    // Initializes the IChanceService interface to be inherited by ChanceService
    public interface IChanceService
    {
        List<Chance> Chances { get; set; }
        List<Player> Players { get; set; }
        Task GetPlayers();
        Task GetChances();
        Task<Chance> GetSingleChance(int id);
        Task CreateChance(Chance chance);
        Task UpdateChance(Chance chance);
        Task DeleteChance(int id);
    }
}
