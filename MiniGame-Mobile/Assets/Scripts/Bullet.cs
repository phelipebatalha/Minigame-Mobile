using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bullet : MonoBehaviour
{
    public float life = 3;
 
    void Awake()
    {
        HUD.Instance.AtacckCooldown(-20f);
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}