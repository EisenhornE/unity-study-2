using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    GameObject zombieAI;
    public float b_damage = 3f;

    void Start()
    {
        zombieAI = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ExpireCoordinate"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
