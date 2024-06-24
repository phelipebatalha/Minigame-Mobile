using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Achievements
{
    public List<Achievement> achievements = new List<Achievement>();

    public Achievements()
    {
        achievements.Add(new Achievement("First Blood", "Score your first point"));
        achievements.Add(new Achievement("Top Player", "Reach the top of the leaderboard"));
        achievements.Add(new Achievement("Century", "Score 100 points"));
        achievements.Add(new Achievement("Millennium", "Score 1000 points"));
    }
}

public class AchievementManager : MonoBehaviour
{
    private string achievementsFilePath;
    public Achievements achievements = new Achievements();

    void Start()
    {
        achievementsFilePath = Path.Combine(Application.persistentDataPath, "achievements.json");
        LoadAchievements();
    }

    public void SaveAchievements()
    {
        string json = JsonUtility.ToJson(achievements, true);
        File.WriteAllText(achievementsFilePath, json);
    }

    public void LoadAchievements()
    {
        if (File.Exists(achievementsFilePath))
        {
            string json = File.ReadAllText(achievementsFilePath);
            achievements = JsonUtility.FromJson<Achievements>(json);
        }
    }

    public void UnlockAchievement(string achievementName)
    {
        foreach (var achievement in achievements.achievements)
        {
            if (achievement.name == achievementName)
            {
                achievement.Unlock();
                SaveAchievements();
                break;
            }
        }
    }
}