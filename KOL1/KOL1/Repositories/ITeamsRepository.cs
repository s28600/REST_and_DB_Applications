using KOL1.Models;

namespace KOL1.Repositories;

public interface ITeamsRepository
{
    IEnumerable<Team> GetTeams(int idChampionship);
    int AddPlayerToTeam(int idPlayer, int idTeam);
}