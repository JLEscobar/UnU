using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activacion : MonoBehaviour
{
    public Animator mecanico;
    public Animator Puerta;
    public BoxCollider2D BX;
    

    private void Start()
    {
        BX.enabled = false;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sff")
        {
            Puerta.SetTrigger("C_Abre");
            Debug.Log("entro");
            mecanico.Play("Fire_active");
            BX.enabled = true;
            Puerta.SetBool("C_Abrio", true);
        }
    }

}
