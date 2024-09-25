using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeMana : MonoBehaviour
{
    public Slider BarraDEmana;
    public float mana;
    public int costoDeMana;


    private void Start()
    {
        StartCoroutine(tiempo());
    }


    private void Update()
    {
        BarraDEmana.GetComponent<Slider>().value = mana;
    }
    IEnumerator tiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (mana < 100)
            {
                mana += 0.5f;
            }
        }
    }
}
