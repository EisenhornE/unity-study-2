using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : ZombieAI
{
    //Polymorphism
    public FastZombie()
    {
        speed = 10f;
        damage = 5f;
    }
}