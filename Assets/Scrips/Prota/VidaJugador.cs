using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vida;
    public int vidaMaxima = 100;
    public BarraDeVida BarraDeVida;

    void Start()
    {
        vida = vidaMaxima;
        BarraDeVida.maxv(vidaMaxima);
    }
    public int Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public void TakeDamage(int amount)
    {
        vida -= amount;
        BarraDeVida.ponervida(vida);
        if (vida <= 0)
        {
            Debug.Log("Muelto");
        }

    }
}
