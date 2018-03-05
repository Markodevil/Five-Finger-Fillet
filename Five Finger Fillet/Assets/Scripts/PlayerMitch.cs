using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMitch : MonoBehaviour
{
    public GameObject[] goKnife;
    public Rigidbody[] rbKnife;
    private GameObject[] intialPos;
    private Transform[] knifeInitPos;
    private Knife[] scpKnife;

    // Use this for initialization
    void Start()
    {
        intialPos = new GameObject[5];
        knifeInitPos = new Transform[5];

        for (int i = 0; i < rbKnife.Length; ++i)
            knifeInitPos[i] = intialPos[i].gameObject.transform.GetComponent<Transform>();

        scpKnife = new Knife[5];

        // get the rigidbodies for each knife
        for (int i = 0; i < rbKnife.Length; ++i)
        {
            rbKnife[i] = gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
            knifeInitPos[i].transform.position = rbKnife[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        knifeStabs();
        knifeResolve();
        if (knifeInitPos[0].transform.position.y != 1.38f)
        {

        }

    }

    void knifeStabs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            rbKnife[0].AddForce(-Vector3.up * 10, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.W))
            rbKnife[1].AddForce(-Vector3.up * 10, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.E))
            rbKnife[2].AddForce(-Vector3.up * 10, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.R))
            rbKnife[3].AddForce(-Vector3.up * 10, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.T))
            rbKnife[4].AddForce(-Vector3.up * 10, ForceMode.Impulse);

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
                rbKnife[i].transform.position = knifeInitPos[i].transform.position;
                scpKnife[i].bKnifeHitGround = false;
            }
        }
    }
}

