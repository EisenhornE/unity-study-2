using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] float speed = 10f;
    private float horizontalInput;
    public float playerHealth = 100f;

    // Start is called before the first frame update
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
}
