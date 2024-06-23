using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public string sceneName;
    public GameObject rank;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Ranking()
    {
        rank.SetActive(!rank.activeInHierarchy);
    }
}
