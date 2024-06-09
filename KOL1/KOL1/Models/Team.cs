namespace KOL1.Models;

public class Team
{
    public int IdTeam { get; set; }
    public string TeamName { get; set; }
    public int MaxAge { get; set; }
    public double Score { get; set; }

    public Team(int idTeam, string teamName, int maxAge, double score)
    {
        IdTeam = idTeam;
        TeamName = teamName;
        MaxAge = maxAge;
        Score = score;
    }
}