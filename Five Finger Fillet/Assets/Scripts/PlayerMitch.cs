using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMitch : MonoBehaviour
{
    public GameObject[] goKnife;
    public Rigidbody[] rbKnife;
    private Vector3[] knifeInitPos;
    private Knife[] scpKnife;
    public GameObject[] stabTarget;

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
        knifeFails();
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
    void knifeFails()
    {
        GameObject player1 = GameObject.Find("Knife1");
        GameObject player2 = GameObject.Find("Knife2");
        GameObject player3 = GameObject.Find("Knife3");
        GameObject player4 = GameObject.Find("Knife4");
        GameObject player5 = GameObject.Find("Knife5");

        // Gets a vector that points from the player's position to the target's.
        var heading1 = stabTarget[0].transform.position - player1.transform.position;
        var heading2 = stabTarget[1].transform.position - player2.transform.position;
        var heading3 = stabTarget[2].transform.position - player3.transform.position;
        var heading4 = stabTarget[3].transform.position - player4.transform.position;
        var heading5 = stabTarget[4].transform.position - player5.transform.position;

        if (Input.GetKeyDown(KeyCode.A))
            rbKnife[0].AddForce(heading1 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.S))
            rbKnife[1].AddForce(heading2 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.D))
            rbKnife[2].AddForce(heading3 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.F))
            rbKnife[3].AddForce(heading4 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.G))
            rbKnife[4].AddForce(heading5 * fFallSpeed, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Z))
            rbKnife[0].AddForce(heading1 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.X))
            rbKnife[1].AddForce(heading2 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.C))
            rbKnife[2].AddForce(heading3 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.V))
            rbKnife[3].AddForce(heading4 * fFallSpeed, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.B))
            rbKnife[4].AddForce(heading5 * fFallSpeed, ForceMode.Impulse);

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
                rbKnife[i].AddForce(Vector3.up * fFallSpeed * 2, ForceMode.Impulse);
                scpKnife[i].bKnifeHitGround = false;
            }
        }

        for (int i = 0; i < rbKnife.Length; ++i)
        {
            if (scpKnife[i].bResetPos)
            {
                rbKnife[i].transform.position = knifeInitPos[i];
                scpKnife[i].bResetPos = false;
            }
        }
    }
}

