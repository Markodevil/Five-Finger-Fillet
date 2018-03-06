using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMitch : MonoBehaviour
{
    public GameObject[] goKnife;
    public Rigidbody[] rbKnife;
    private Vector3[] knifeInitPos;
    private Knife[] scpKnife;

    // Public vars for the designers
    public float fFallSpeed = 0;

    // Use this for initialization
    void Start()
    {
        knifeInitPos = new Vector3[5];

        for (int i = 0; i < rbKnife.Length; ++i)
            knifeInitPos[i] = rbKnife[i].transform.position;

        scpKnife = new Knife[5];

        // get the rigidbodies for each knife
        for (int i = 0; i < rbKnife.Length; ++i)
        {
            rbKnife[i] = gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        knifeStabs();
        knifeResolve();
    }

    void knifeStabs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            rbKnife[0].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.W))
            rbKnife[1].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.E))
            rbKnife[2].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.R))
            rbKnife[3].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.T))
            rbKnife[4].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);

    }

    void knifeResolve()
    {
        for (int i = 0; i < rbKnife.Length; ++i)
        {
            scpKnife[i] = gameObject.transform.GetChild(i).GetComponent<Knife>();
        }

        for (int i = 0; i < rbKnife.Length; ++i)
        {
            if (scpKnife[i].bKnifeHitGround)
            {
                rbKnife[i].transform.position = knifeInitPos[i];
                scpKnife[i].bKnifeHitGround = false;
            }
        }
    }
}

