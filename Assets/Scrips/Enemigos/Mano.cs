using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public int damage = 10;
    public VidaJugador VD;
    public float AttakRate = 2f;
    public float NATime = 0f;

    private Transform player;
    private bool isDashing = false;
    public Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null && !isDashing)
        {
            // Calcular la dirección hacia el jugador
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            // Moverse hacia el jugador
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Si el enemigo está lo suficientemente cerca del jugador, realizar el dash
            if (Vector2.Distance(transform.position, player.position) < 1.5f)
            {
                StartCoroutine(PerformDash());
            }
        }
    }

    private IEnumerator PerformDash()
    {
        isDashing = true;

        // Cambiar la animación a la de dash
        animator.SetTrigger("Dash");

        // Calcular la dirección del dash hacia el jugador
        Vector2 dashDirection = player.position - transform.position;
        dashDirection.Normalize();

        float elapsedTime = 2f;

        
        while (elapsedTime < dashDuration)
        {
            transform.Translate(dashDirection * dashSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        isDashing = false;
        // Cambiar la animación de vuelta a la normal
        animator.SetTrigger("Idle");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // El enemigo ha colisionado con el jugador, hacer daño
            VidaJugador VD = collision.gameObject.GetComponent<VidaJugador>();
            if (VD != null)
            {
                VD.TakeDamage(damage);
            }
        }
    }
}
