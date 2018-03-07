using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SETS;

public class ToggleKeyPrompt : MonoBehaviour
{

    public Sets sets;
    public GameObject Q;
    public GameObject W;
    public GameObject E;
    public GameObject R;
    public GameObject T;


    public GameObject Y;
    public GameObject U;
    public GameObject I;
    public GameObject O;
    public GameObject P;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (sets.Q == true)
            Q.SetActive(true);
        else if (!sets.Q)
        {
            Q.SetActive(false);
        }

        if (sets.W == true)
            W.SetActive(true);
        else if (!sets.W)
        {
            W.SetActive(false);
        }

        if (sets.E == true)
            E.SetActive(true);
        else if (!sets.E)
        {
            E.SetActive(false);
        }

        if (sets.R == true)
            R.SetActive(true);
        else if (!sets.R)
        {
            R.SetActive(false);
        }

        if (sets.T == true)
            T.SetActive(true);
        else if (!sets.T)
        {
            T.SetActive(false);
        }

        if (sets.Y == true)
            Y.SetActive(true);
        else if (!sets.Y)
        {
            Y.SetActive(false);
        }

        if (sets.U == true)
            U.SetActive(true);
        else if (!sets.U)
        {
            U.SetActive(false);
        }

        if (sets.I == true)
            I.SetActive(true);
        else if (!sets.I)
        {
            I.SetActive(false);
        }

        if (sets.O == true)
            O.SetActive(true);
        else if (!sets.O)
        {
            O.SetActive(false);
        }

        if (sets.P == true)
            P.SetActive(true);
        else if (!sets.P)
        {
            P.SetActive(false);
        }

    }
}
