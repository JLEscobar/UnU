using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public float invulnerabilityDuration = 1f;

    public LayerMask muros; // Capa de obstáculos

    private bool canDash = true;
    private bool isInvulnerable = false;
    public BarraDeMana Costo;
    public GameObject characteros;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public Animator animator;

    private void Awake()
    {
        Costo = characteros.GetComponent<BarraDeMana>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (canDash && Input.GetKeyDown(KeyCode.Space) && Costo.mana >= Costo.costoDeMana)
        {
            Costo.mana -= Costo.costoDeMana;
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        animator.SetTrigger("Dash");
        canDash = false;
        isInvulnerable = true;
        boxCollider.enabled = false;

        Vector2 dashDirection = CalculateDashDirection();
        Vector2 targetPos = (Vector2)transform.position + dashDirection * dashDistance;

        // Realizar un raycast para verificar si hay obstáculos en el camino
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dashDirection, dashDistance, muros);
        if (hit.collider != null)
        {
            // Si se detecta un obstáculo, cancelar el dash
            canDash = true;
            isInvulnerable = false;
            boxCollider.enabled = true;
            yield break;
        }

        float elapsedTime = 0f;

        while (elapsedTime < dashDuration)
        {
            rb.MovePosition(Vector2.Lerp(transform.position, targetPos, elapsedTime / dashDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPos);

        yield return new WaitForSeconds(invulnerabilityDuration);

        isInvulnerable = false;
        boxCollider.enabled = true;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private Vector2 CalculateDashDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;

        return direction;
    }
}





