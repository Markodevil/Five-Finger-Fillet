using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SETS;

public class ToggleKeyPrompt : MonoBehaviour
{

    public Sets sets;
    private Image image;
    public GameObject Q;
    public GameObject W;
    public GameObject E;
    public GameObject R;
    public GameObject T;

    // Use this for initialization
    void Start()
    {

        image = GetComponent<Image>();
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

    }
}
