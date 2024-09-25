using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image barra;

    public void maxv(int vidam)
    {
        Slider.maxValue = vidam;
        Slider.value = vidam;
        barra.color = Gradient.Evaluate(1f);
    }
    public void ponervida(int en4)
    {
        Slider.value = en4;
        barra.color = Gradient.Evaluate(Slider.normalizedValue);
    }
}