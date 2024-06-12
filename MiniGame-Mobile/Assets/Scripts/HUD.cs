using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image healthBar,manaBar,CDbar;
    public Button button1;
    public static HUD Instance;
    public float healthAmount = 100f, manaAmount = 2f, cdAmount = 20f;
    public bool canButton = true;
    public Text pointsText;
    public int points = 0; 
    public Quest quest;

    public void SpawnButton()
    {   
        EnemySpawner.EnemySpawnerInstance.Spawning();
    }
    void Update()
    {
        if(button1 != null)
        {
            button1.gameObject.SetActive(!EnemySpawner.EnemySpawnerInstance.canSpawn);
        }

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
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
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
