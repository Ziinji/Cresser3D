using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealh(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        this.enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<EnemyPatrol>().enabled = false;
        GetComponent<EnemyCombat>().enabled = false;
        GetComponent<CharacterController>().enabled = false;

    }
}
