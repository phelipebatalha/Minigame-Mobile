using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.025f;
    private Rigidbody rb;
    //public GameObject powerup;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        //Get the target
        if(!target) 
        {
            GetTarget();
        }
        else 
        {
            RotateTowardsTarget();
        }
        //Rotate towards the target
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void RotateTowardsTarget()
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.Normalize();
        transform.position += targetDirection * speed * Time.deltaTime;
        Quaternion rotations = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotations, speed * Time.deltaTime);
    }

    private void GetTarget()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject != null)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                //LevelManager.manager.GameOver();
                if(HUD.Instance.healthAmount > 0)
                HUD.Instance.TakeDamage(20f);
                target = null;
            }
            else if (other.gameObject.CompareTag("Bullet")){
                //LevelManager.manager.IncreaseScore(1);
                int rand = Random.Range(1,3);
                Destroy(other.gameObject);

                EnemySpawner.EnemySpawnerInstance._verify -= 1;
                //if(rand == 1)
                //{
                //    Instantiate(powerup, transform.position, Quaternion.identity);    
                //}
            } 
        }
    }
}
