using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] float speed = 10f;
    private float b_speed = 10f;
    private float horizontalInput;
    public Transform gunBarrel;
    public float playerHealth = 100f;

    // public float playerHealth 
    // {
    //     get { return _playerHealth; }
    //     set 
    //     {
    //         if(value <= 0)
    //         {
    //             Die();
    //         }
    //         else
    //         {
    //             _playerHealth = value;
    //         }
    //     }
    // }

    public GameObject bulletPrefab;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            Die();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
    }

    //It's friday in California
    //Huh?
    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();
        bulletRb.AddForce(gunBarrel.forward * Time.deltaTime * b_speed, ForceMode.Impulse);
        bulletRb.velocity = gunBarrel.forward * b_speed;
    }
}
