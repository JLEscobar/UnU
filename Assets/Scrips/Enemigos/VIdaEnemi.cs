using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdaEnemi : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
        }
        else if (currentHealth <= 0){
            Die();
            animator.SetBool("IsDead", true);
        }

    }
    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
}
