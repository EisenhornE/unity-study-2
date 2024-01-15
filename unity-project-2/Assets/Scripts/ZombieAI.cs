using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        Chase();
    }

    public void Chase()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
