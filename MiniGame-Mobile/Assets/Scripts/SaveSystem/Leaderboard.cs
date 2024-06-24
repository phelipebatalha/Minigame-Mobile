using System.Collections.Generic;

[System.Serializable]
public class Leaderboard
{
    public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

    public void AddEntry(LeaderboardEntry entry)
    {
        entries.Add(entry);
        entries.Sort((a, b) => b.score.CompareTo(a.score));
        if (entries.Count > 5)
        {
            entries.RemoveAt(entries.Count - 1);
        }
    }
}
