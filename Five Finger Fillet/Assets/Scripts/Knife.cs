using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [HideInInspector]
    public bool bKnifeHitGround;
    [HideInInspector]
    public bool bResetPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
            bKnifeHitGround = true;

        if (col.gameObject.tag == "Roof")
            bResetPos = true;
    }
}
