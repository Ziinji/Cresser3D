using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    public Animator animator;

    public bool isDead = false;
    void DestroyInstance()
    {
        isDead = true;
        Destroy(transform.parent.gameObject);
    }

    void Attacking()
    {
        GetComponentInParent<EnemyCombat>().Attack();
    }
}
