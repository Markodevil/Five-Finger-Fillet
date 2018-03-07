using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMitch : MonoBehaviour
{
    private Knife[] goKnife;
    public Rigidbody[] rbKnife;
    private Vector3[] knifeInitPos;
    public GameObject[] stabTarget;
    public AudioManager audmanager;
    public GameObject[] goParticle;
    public ParticleSystem[] particle;

    // stab sound timer
    private bool bPlayStabSound = false;
    private float fStabSoundCount = 0.0f;
    private float fStabSoundTime = 0.315f;

    // stab sound timer
    private bool bPlayTableSound = false;
    private float fTableSoundCount = 0.0f;
    private float fTableSoundTime = 0.285f;


    // tet
    private bool bOnce = false;
    private bool bOnce1 = false;



    // Public vars for the designers
    public float fFallSpeed = 0;

    // Use this for initialization
    void Start()
    {
        // initializing vector lengths
        knifeInitPos = new Vector3[10];
        goKnife = new Knife[10];

        // saving the initial positions of each knife
        for (int i = 0; i < rbKnife.Length; ++i)
            knifeInitPos[i] = rbKnife[i].transform.position;

        // get access to the rigidbodies of each knife
        for (int i = 0; i < rbKnife.Length; ++i)
        {
            rbKnife[i] = gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
        }

        for (int i = 0; i < particle.Length; ++i)
        {
            particle[i] = goParticle[i].GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // a clean way to organize code
        knifeStabs();
        knifeFails();
        knifeResolve();
        KnifeSound();
    }

    // the action of the knifes stabbing the table
    void knifeStabs()
    {
        // if player clicks the right key then it goes straight down missing the hand
        // player 1
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rbKnife[0].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rbKnife[1].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rbKnife[2].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rbKnife[3].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            rbKnife[4].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        // player 2
        if (Input.GetKeyDown(KeyCode.Y))
        {
            rbKnife[5].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            rbKnife[6].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            rbKnife[7].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            rbKnife[8].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            rbKnife[9].AddForce(-Vector3.up * fFallSpeed, ForceMode.Impulse);
            bPlayTableSound = true;
            bOnce1 = true;
        }

    }

    // the knifes stab the fingers, dismembering them
    void knifeFails()
    {
        // player 1
        GameObject knife1 = GameObject.Find("Knife1");
        GameObject knife2 = GameObject.Find("Knife2");
        GameObject knife3 = GameObject.Find("Knife3");
        GameObject knife4 = GameObject.Find("Knife4");
        GameObject knife5 = GameObject.Find("Knife5");
        // player 2
        GameObject knife6 = GameObject.Find("Knife6");
        GameObject knife7 = GameObject.Find("Knife7");
        GameObject knife8 = GameObject.Find("Knife8");
        GameObject knife9 = GameObject.Find("Knife9");
        GameObject knife10 = GameObject.Find("Knife10");

        // Gets a vector that points from the knife's position to the target's.
        // player 1
        var heading1 = stabTarget[0].transform.position - knife1.transform.position;
        var heading2 = stabTarget[1].transform.position - knife2.transform.position;
        var heading3 = stabTarget[2].transform.position - knife3.transform.position;
        var heading4 = stabTarget[3].transform.position - knife4.transform.position;
        var heading5 = stabTarget[4].transform.position - knife5.transform.position;
        // player 2
        var heading6 = stabTarget[5].transform.position - knife6.transform.position;
        var heading7 = stabTarget[6].transform.position - knife7.transform.position;
        var heading8 = stabTarget[7].transform.position - knife8.transform.position;
        var heading9 = stabTarget[8].transform.position - knife9.transform.position;
        var heading10 = stabTarget[9].transform.position - knife10.transform.position;

        // player1
        if (Input.GetKeyDown(KeyCode.A))
        {
            rbKnife[0].AddForce(heading1 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rbKnife[1].AddForce(heading2 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[1].Play();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rbKnife[2].AddForce(heading3 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[2].Play();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            rbKnife[3].AddForce(heading4 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[3].Play();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            rbKnife[4].AddForce(heading5 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[4].Play();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rbKnife[0].AddForce(heading6 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rbKnife[1].AddForce(heading7 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[2].Play();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            rbKnife[2].AddForce(heading8 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[3].Play();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            rbKnife[3].AddForce(heading9 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[4].Play();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            rbKnife[4].AddForce(heading10 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[4].Play();
        }

        // player 2
        if (Input.GetKeyDown(KeyCode.H))
        {
            rbKnife[5].AddForce(heading6 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[5].Play();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            rbKnife[6].AddForce(heading7 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[6].Play();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            rbKnife[7].AddForce(heading8 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[7].Play();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            rbKnife[8].AddForce(heading9 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[8].Play();
        }

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            rbKnife[9].AddForce(heading10 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[9].Play();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            rbKnife[5].AddForce(heading6 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[5].Play();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            rbKnife[6].AddForce(heading7 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[6].Play();
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            rbKnife[7].AddForce(heading8 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[7].Play();
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            rbKnife[8].AddForce(heading9 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[8].Play();
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            rbKnife[9].AddForce(heading10 * fFallSpeed, ForceMode.Impulse);
            // play stab sound
            bPlayStabSound = true;
            bOnce = true;
            particle[9].Play();
        }
    }

    void knifeResolve()
    {
        for (int i = 0; i < rbKnife.Length; ++i)
        {
            goKnife[i] = gameObject.transform.GetChild(i).GetComponent<Knife>();
        }

        for (int i = 0; i < rbKnife.Length; ++i)
        {
            if (goKnife[i].bKnifeHitGround)
            {
                rbKnife[i].AddForce(Vector3.up * fFallSpeed * 2, ForceMode.Impulse);
                goKnife[i].bKnifeHitGround = false;
            }
        }

        for (int i = 0; i < rbKnife.Length; ++i)
        {
            if (goKnife[i].bResetPos)
            {
                rbKnife[i].transform.position = knifeInitPos[i];
                goKnife[i].bResetPos = false;
            }
        }
    }

    void KnifeSound()
    {
        // Stab sound
        if (bPlayStabSound)
        {
            if (fStabSoundCount < fStabSoundTime)
            {
                fStabSoundCount += Time.deltaTime;

                if (bOnce)
                {
                    audmanager.audSoundSource.clip = audmanager.arrAudio[0];
                    audmanager.audSoundSource.Play();
                    bOnce = false;
                }
            }
            else if (fStabSoundCount >= fStabSoundTime)
            {
                fStabSoundCount = 0.0f;
                bPlayStabSound = false;
            }
        }

        // hit table sound
        if (bPlayTableSound)
        {
            if (fTableSoundCount < fTableSoundTime)
            {
                fTableSoundCount += Time.deltaTime;

                if (bOnce1)
                {
                    audmanager.audSoundSource.clip = audmanager.arrAudio[1];
                    audmanager.audSoundSource.Play();
                    bOnce1 = false;
                }
            }
            else if (fTableSoundCount >= fTableSoundTime)
            {
                fTableSoundCount = 0.0f;
                bPlayTableSound = false;
            }
        }
    }
}

