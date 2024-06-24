using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    private string leaderboardFilePath;
    public Leaderboard leaderboard = new Leaderboard();
    public AchievementManager achievementManager;

    void Start()
    {
        leaderboardFilePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadLeaderboard();
        achievementManager = GetComponent<AchievementManager>();
    }

    public void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(leaderboardFilePath, json);
    }

    public void LoadLeaderboard()
    {
        if (File.Exists(leaderboardFilePath))
        {
            string json = File.ReadAllText(leaderboardFilePath);
            leaderboard = JsonUtility.FromJson<Leaderboard>(json);
        }
    }

    public void AddNewEntry(string playerName, int score)
    {
        leaderboard.AddEntry(new LeaderboardEntry(playerName, score));
        SaveLeaderboard();
        CheckAchievements(playerName, score);
    }

    private void CheckAchievements(string playerName, int score)
    {
        if (score >= 1)
        {
            achievementManager.UnlockAchievement("First Blood");
        }
        if (score >= 100)
        {
            achievementManager.UnlockAchievement("Century");
        }
        if (score >= 1000)
        {
            achievementManager.UnlockAchievement("Millennium");
        }
        if (leaderboard.entries.Count > 0 && leaderboard.entries[0].playerName == playerName)
        {
            achievementManager.UnlockAchievement("Top Player");
        }
    }
}
