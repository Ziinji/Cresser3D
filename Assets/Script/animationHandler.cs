using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandler : MonoBehaviour
{
    public bool isDead = false;
    void DestroyInstance()
    {
        isDead = true;
        Destroy(transform.parent.gameObject);
    }
}
