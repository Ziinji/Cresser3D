using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public ThirdPersonMovement playerMove;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public Animator animator;
    bool comboPossible;
    public int comboStep;
    bool inputHeavy;
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
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

            Attack();
        }
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
