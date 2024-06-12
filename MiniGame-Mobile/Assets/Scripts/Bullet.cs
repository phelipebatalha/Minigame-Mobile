using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
    public Quest quest;
    void Awake()
    {
        HUD.Instance.AtacckCooldown(-20f);
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(quest.isActive)
            {
                quest.goal.EnemyKilled();
                if(quest.goal.IsReached())
                {
                    HUD.Instance.points += 50;
                    quest.Complete();
                }
            }
            HUD.Instance.points += 5;
            Destroy(collision.gameObject);
        }
            Destroy(gameObject);
    }
}