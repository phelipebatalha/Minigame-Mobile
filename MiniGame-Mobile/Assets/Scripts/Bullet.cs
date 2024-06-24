using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
    public Player player;
    void Awake()
    {
        HUD.Instance.AtacckCooldown(-20f);
        Destroy(gameObject, life);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.SpellCast();
        player.SpellCast2();
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != null)
        {
            if (collision.gameObject.tag == "Enemy" )
            {
                player.EnemyKill();
                Destroy(collision.gameObject);
            }
                Destroy(gameObject);
        }
    }
}