using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fingers : MonoBehaviour
{
    [HideInInspector]
    public bool bGotStabbed;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Knife")
        {
            bGotStabbed = true;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
