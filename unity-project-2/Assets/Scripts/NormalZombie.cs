using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : ZombieAI
{
    //Polymorphism
    public NormalZombie()
    {
        speed = 5f;
        damage = 10f;
    }
}
