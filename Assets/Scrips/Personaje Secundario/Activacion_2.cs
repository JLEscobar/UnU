using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activacion_2 : MonoBehaviour
{
    public Animator mecanico;
    public Animator Puente;
    public BoxCollider2D BX;


    private void Start()
    {
        BX.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Puente.SetTrigger("C_Abre");
        Debug.Log("entro");
        mecanico.Play("Fuego_Activo");
        BX.enabled = false;
        Puente.SetBool("C_Acabo", true);
    }

}

