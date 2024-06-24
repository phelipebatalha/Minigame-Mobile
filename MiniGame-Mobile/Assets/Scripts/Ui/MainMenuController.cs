using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AchievementManager achivManager;
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private GameObject[] achivs;
    [SerializeField] private TextMeshProUGUI[] nameLeader;
    [SerializeField] private TextMeshProUGUI[] pointLeader;
    private void Awake()
    {
        achivManager.LoadAchievements();
        leaderboardManager.LoadLeaderboard();
    }
    public void VerificarConquista()
    {
        achivs[0].SetActive(achivManager.achievements.achievements[0].unlocked);
        achivs[1].SetActive(achivManager.achievements.achievements[1].unlocked);
        achivs[2].SetActive(achivManager.achievements.achievements[2].unlocked);
        achivs[3].SetActive(achivManager.achievements.achievements[3].unlocked);
    }
    public void AtualizarLeader()
    {
        for (int i = 0; i < nameLeader.Length; i++)
        {
            nameLeader[i].text = leaderboardManager.leaderboard.entries[i].playerName;
            pointLeader[i].text = leaderboardManager.leaderboard.entries[i].score.ToString();
        }
    }
    public void LoadSceneGame()
    {
        SceneManager.LoadScene(1);
    }
}
