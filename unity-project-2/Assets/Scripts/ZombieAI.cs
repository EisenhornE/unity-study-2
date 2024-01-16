using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject player;

    //Encapsulation
    float m_speed;
    public float speed
    {
        get { return m_speed; }
        set 
        { 
            if(value <= 0f)
            {
                Debug.LogError("Speed must be greater than 0");
            }
            else
            m_speed = value; 
        }
    }

    protected float health;
    protected float damage;
    float damageCooldown = 1f;
    float damageTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Chase();
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && damageTimer <= 0f)
        {
            DealDamage();
            damageTimer = damageCooldown;
        }
    }

    //Abstraction
    public virtual void Chase()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //Abstraction
    public virtual void DealDamage()
    {
        player.GetComponent<PlayerControl>().playerHealth -= damage;
        Debug.Log("Player Health: " + player.GetComponent<PlayerControl>().playerHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
