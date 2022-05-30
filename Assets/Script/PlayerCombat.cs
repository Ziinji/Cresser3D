using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public ThirdPersonMovement playerMove;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    public Animator animator;
    public HealthBar healthBar;

    public int comboStep;

    bool comboPossible;
    bool inputHeavy;
    bool canAttack;
    public bool canBeHit;

    public int maxHealth = 100;
    public int currentHealth;

    public int attackDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerMove.isGrounded)
        {
            if (canAttack) 
            {
                Attack();
            }
        }
    }

    public void AttackingAnim()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            switch (comboStep)
            {
                case 1:
                    enemy.GetComponent<EnemyCombat>().TakeDamage(25);
                    break;
                case 2:
                    enemy.GetComponent<EnemyCombat>().TakeDamage(35);
                    break;
                case 3:
                    enemy.GetComponent<EnemyCombat>().TakeDamage(40);
                    break;
            }
        }   
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void NextAtk()
    {
        if(comboStep == 2)
        {
            animator.Play("light2");
        }
        if (comboStep == 3)
        {
            animator.Play("light3");
        }
    }
    public void Attack()
    {
        if(comboStep==0)
        {
            animator.Play("light1");
            comboStep = 1;
            return;
        }
        if(comboStep!=0)
        {
            comboPossible = false;
            comboStep += 1;
        }
    }

    public void Combo()
    {
        if (comboStep == 2)
            animator.Play("light2");
        if (comboStep == 3)
            animator.Play("light3");
    }

    public void ResetCombo()
    {
        comboPossible = false;
        comboStep = 0;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameObject.tag = "Dead";
        animator.SetBool("isDead", true);

        this.enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<EnemyPatrol>().enabled = false;
        GetComponent<EnemyCombat>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<ThirdPersonMovement>().enabled = false;
    }

    void NormalAttack()
    {
        if(comboStep == 0)
        {
            animator.Play("light1");
            comboStep = 1;
            return;
        }
        if(comboStep != 0)
        {
            if(comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    public void enableAttack()
    {
        canAttack = true;
    }

    public void disableAttack()
    {
        canAttack = false;
    }

    void RollStart()
    {
        canBeHit = false;
    }

    void RollEnd()
    {
        canBeHit = true;
    }
}
