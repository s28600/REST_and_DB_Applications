using System.Data.SqlClient;
using KOL1.Models;

namespace KOL1.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private IConfiguration _configuration;

    public TeamsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Team> GetTeams(int idChampionship)
    {
        using var sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        using var sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "SELECT t.IdTeam, t.TeamName, t.MaxAge, ct.Score FROM Team t JOIN Championship_Team ct ON t.IdTeam = ct.IdTeam WHERE ct.IdChampionship = @idChampionship";
        sqlCommand.Parameters.AddWithValue("@idChampionship", idChampionship);
        
        sqlConnection.Open();
        var dataReader = sqlCommand.ExecuteReader();
        var teams = new List<Team>();
        while (dataReader.Read())
        {
            var team = new Team(
                idTeam:(int)dataReader["IdTeam"],
                teamName:dataReader["TeamName"].ToString(), 
                maxAge:(int)dataReader["MaxAge"],
                score:(double)dataReader["Score"]
            );
            teams.Add(team);
        }
        
        return teams;
    }

    public int AddPlayerToTeam(int idPlayer, int idTeam)
    {
        using var sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        sqlConnection.Open();
        if (!PlayerExists(sqlConnection, idPlayer))
            throw new Exception("Player does not exist");
        if (!PlayerClearsAgeRequirement(sqlConnection, idPlayer, idTeam))
            throw new Exception("Player does not meet age requirement for the team");
        if (PlayerIsAlreadyInTheTeam(sqlConnection, idPlayer, idTeam))
            throw new Exception("Player is already in the team");
        
        using var command = new SqlCommand("INSERT INTO Player_Team(IdPlayer, IdTeam, NumOnShirt) VALUES(@idPlayer, @idTeam, @numOnShirt)", sqlConnection);
        command.Parameters.AddWithValue("@idPlayer", idPlayer);
        command.Parameters.AddWithValue("@idTeam", idTeam);
        Random random = new Random();
        command.Parameters.AddWithValue("@numOnShirt", random.Next(100));
        
        return command.ExecuteNonQuery();
    }

    private bool PlayerExists(SqlConnection sqlConnection, int idPlayer)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM Player WHERE IdPlayer = @idPlayer", sqlConnection);
        command.Parameters.AddWithValue("@idPlayer", idPlayer);
        return (int)command.ExecuteScalar() > 0;
    }
    
    private bool PlayerClearsAgeRequirement(SqlConnection sqlConnection, int idPlayer, int idTeam)
    {
        using var command = new SqlCommand("SELECT (t.MaxAge - (YEAR(GETDATE()) - YEAR(p.DateOfBirth))) FROM Player p, Team t WHERE p.IdPlayer = @idPlayer and t.IdTeam = @idTeam", sqlConnection);
        command.Parameters.AddWithValue("@idPlayer", idPlayer);
        command.Parameters.AddWithValue("@idTeam", idTeam);
        return (int)command.ExecuteScalar() >= 0;
    }
    
    private bool PlayerIsAlreadyInTheTeam(SqlConnection sqlConnection, int idPlayer, int idTeam)
    {
        using var command = new SqlCommand("SELECT COUNT(1) FROM Player_Team WHERE IdPlayer = @idPlayer and IdTeam = @idTeam", sqlConnection);
        command.Parameters.AddWithValue("@idPlayer", idPlayer);
        command.Parameters.AddWithValue("@idTeam", idTeam);
        return (int)command.ExecuteScalar() > 0;
    }
}