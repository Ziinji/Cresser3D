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
    bool comboPossible;
    public int comboStep;
    bool inputHeavy;

    public int attackDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerMove.isGrounded)
        {
            Attack();
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
                    enemy.GetComponent<EnemyPatrol>().Chasing();
                    break;
                case 2:
                    enemy.GetComponent<EnemyCombat>().TakeDamage(25);
                    enemy.GetComponent<EnemyPatrol>().Chasing();
                    break;
                case 3:
                    enemy.GetComponent<EnemyCombat>().TakeDamage(50);
                    enemy.GetComponent<EnemyPatrol>().Chasing();
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
}
