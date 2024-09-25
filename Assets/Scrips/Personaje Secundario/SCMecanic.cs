using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCMecanic : MonoBehaviour
{
    public Transform player;
    public GameObject characteros;
    public BarraDeMana barraTemp;
    private Rigidbody2D Player;
    public float basemanaCost = 10f;
    public float distanciaAnterior = 0;
    public GameObject Circle;
    public float manaDistanceFactor = 0.1f;
    private Vector3 respawnPoint;
    public Slider BarraDEmana;
    public bool flagBase = true;



    public void Start()
    {

        barraTemp = characteros.GetComponent<BarraDeMana>();
        respawnPoint = characteros.transform.position;

    }
    

    private void Update()
    {

        MoverObjeto();
        respawnPoint = characteros.transform.position;

    }

    private void  MoverObjeto()
{
    if ( flagBase)
    {
        Debug.Log("why?");
        transform.position=respawnPoint;
         BarraDEmana.maxValue = 100;
    }
    else 
    { 
        if (barraTemp.mana > 0)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Movimiento hacia arriba");
                MoverEnDireccion(Vector3.up );
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("Movimiento hacia la izquierda");
                MoverEnDireccion(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Movimiento hacia abajo");
                MoverEnDireccion(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Movimiento hacia la derecha");
                MoverEnDireccion(Vector3.right);

            }
 
        }
   
  }
  
           if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = respawnPoint;
            BarraDEmana.maxValue = 100;
            flagBase=false;
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            flagBase=true;
        }
    }
    private void MoverEnDireccion(Vector3 direccion)
    {
        float distancia = Vector3.Distance(transform.position, player.position);
        float costomana =  distancia; 
        if (BarraDEmana.maxValue <= 0)
        {
            transform.position= respawnPoint;
            BarraDEmana.maxValue = 100;
            
        }
        if (barraTemp.mana >= costomana)
        {
            transform.Translate(direccion);
            float distanciaGluglu = Vector3.Distance(respawnPoint, transform.position);
            if(distanciaGluglu >= distanciaAnterior){
                barraTemp.mana -= costomana;
                distanciaAnterior = distanciaGluglu;
                BarraDEmana.maxValue = BarraDEmana.maxValue - costomana;
                Debug.Log("Mana restante del protagonista: " + barraTemp.mana);
            }else {
                barraTemp.mana += costomana;
                distanciaAnterior = distanciaGluglu;
                float currentAddMana = BarraDEmana.maxValue +costomana;
                if(currentAddMana<=100){

                    BarraDEmana.maxValue = BarraDEmana.maxValue +costomana;
                }else {
                    BarraDEmana.maxValue = 100;
                }
                Debug.Log("Mana restante del protagonista: " + barraTemp.mana);
            }
        }
        else
        {
            transform.position = respawnPoint;
        }

    }

}
