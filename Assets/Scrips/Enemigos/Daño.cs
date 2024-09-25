using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public VidaJugador vidaJugador;
    public int daño = 2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vidaJugador.TakeDamage(daño);

        }

    }
}