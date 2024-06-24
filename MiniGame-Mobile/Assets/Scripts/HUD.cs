using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Image healthBar,manaBar,CDbar;
    public Button button1;
    public static HUD Instance;
    public float healthAmount = 100f, manaAmount = 2f, cdAmount = 20f;
    public bool canButton = true;
    public Text pointsText;
    public int points = 0, lastPoints = 0; 
    public Quest quest;
    public GameObject configPainel;

    public void ReStart()
    {
        Heal(100f);
        points = 0;
        UpdatePoints(0);
    }
    public void SpawnButton()
    {   
        EnemySpawner.EnemySpawnerInstance.Spawning();
    }
    public void ConfigButton()
    {
        configPainel.SetActive(!configPainel.activeInHierarchy);
    }
    void Update()
    {
        if(button1 != null)
        {
            button1.gameObject.SetActive(!EnemySpawner.EnemySpawnerInstance.canSpawn);
        }
        if(points != lastPoints)
        {
            UpdatePoints(points);
        }
        if(Input.GetKey(KeyCode.X))
        {
            HighscoreTable.ScoresRanking.AddHighscoreEntry(points,PlayerNameInput.PlayerNameInstance.GetPlayerName());
            SceneManager.LoadScene("Menu");
            ReStart();
            //SceneManager.UnloadSceneAsync("Jogo_Official");
        }
        if(healthAmount <= 0)
        {
            HighscoreTable.ScoresRanking.AddHighscoreEntry(points,PlayerNameInput.PlayerNameInstance.GetPlayerName());
            SceneManager.LoadScene("Menu");
            ReStart();
            //SceneManager.UnloadSceneAsync("Jogo_Official");
        }
    }    
    public void UpdatePoints(int newPoints)
    {
        pointsText.text = "" + points;
    }
    void Awake(){
        if(Instance == null)
        Instance = this;
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void TakeDamage(float damage)
    {
        if(healthAmount > 0)
        {
            healthAmount -= damage;
            healthBar.fillAmount = healthAmount / 100f;
        }
            
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void CastMana(float mana)
    {
        manaAmount -= mana;
        manaBar.fillAmount = manaAmount / 2f;
        StartCoroutine("RechargeMana");
    }
    public void AtacckCooldown(float cooldown)
    {
        if(cooldown > 0)
        cdAmount -= cooldown;
        else{
            cooldown *= -1;
            cdAmount += cooldown;
        }
        CDbar.fillAmount = cdAmount / 20f;
    }
    public IEnumerator RechargeMana()
    {
        yield return new WaitForSeconds(3f);
        if(manaAmount < 2f) manaAmount += 1f;
        manaBar.fillAmount = manaAmount / 2f;
    }
}
