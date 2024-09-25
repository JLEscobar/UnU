using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataOtakus : MonoBehaviour
{
    public GameObject characteros;
    public BarraDeMana BR;
    public Animator animator;
    public Transform PuntaAttak;
    public float attakRange = 0.5f;
    public LayerMask EnemyLayers;
    public int AD = 40;
    public float AttakRate = 2f;
    public float NATime = 0f;

    private void Start()
    {
        BR = characteros.GetComponent<BarraDeMana>();
    }
    void Update()
    {
        if (Time.time >= NATime)
        {
            if (Input.GetKeyDown(KeyCode.X) && BR.mana >= BR.costoDeMana)
            {
                Attak();
                NATime = Time.time + 1f / AttakRate;
                BR.mana -= BR.costoDeMana;
            }
        }

    }
    void Attak()
    {
        animator.SetTrigger("Attak");
        Collider2D[]HitEnemis = Physics2D.OverlapCircleAll(PuntaAttak.position, attakRange, EnemyLayers);
        foreach(Collider2D enemi in HitEnemis)
        {
            enemi.GetComponent<VIdaEnemi>().takeDamage(AD);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (PuntaAttak == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(PuntaAttak.position, attakRange);

    }
}
