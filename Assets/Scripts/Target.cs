using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE SCRIPT VA EN CADA TARGET

public class Target : MonoBehaviour
{
    public float health = 2f; //Salud del target

    public void DamageReceived(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); //Destruye el game object en el que esta este script
    }
}