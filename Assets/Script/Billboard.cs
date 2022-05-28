using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    // Update is called once per frame

    private void Start()
    {
        GameObject track = GameObject.FindWithTag("MainCamera");
        cam = track.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
