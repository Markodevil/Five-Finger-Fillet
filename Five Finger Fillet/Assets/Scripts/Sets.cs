using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Sets : MonoBehaviour
{
    private enum Fingers
    {
        Finger1,
        Finger2,
        Finger3,
        Finger4,
        Finger5
    };

    List<List<Fingers>> RoundRequiredFingers = new List<List<Fingers>>();
    List<List<Fingers>> FingerSets = new List<List<Fingers>>();

    public float KeyPressTime = 1.0f;
    public int RoundsTotoal = 5;

    private int currentRound = 0;
    private int currentKeypressIndex = 0;
    private float keypressTimer = 0.0f;

    private int playerOnePoints = 0;
    private int playerTwoPoints = 0;

    private bool playerOneSucceds = true;
    private bool playerTwoSucceds = true;



    // Use this for initialization
    void Start()
    {
        //Random Round Sets
        // 
        // Set 1: q,w,e,r,t     Set 2: q,e,w,r,t      Set 3: q,r,w,e,t
        // Set 4: q,t,w,e,r     Set 5: w,q,e,r,t      Set 6: w,e,q,r,t
        // Set 7: w,r,q,e,t     Set 8: e,q,w,r,t      Set 9: e,w,q,r,t
        // Set 10: e,r,q,w,t    Set 11:r,q,w,e,t      Set 12: r,w,q,e,t
        // Set 13: r,e,q,w,t    Set 14: r,t,q,w,e     Set 15: t,q,w,e,r
        // Set 16: t,w,q,e,r    Set 17: t,e,q,w,r     Set 18: t,r,q,w,e
        // Set 19: t,r,e,w,q    Set 20: t,e,r,w,q

        //Set 1:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger3,
            Fingers.Finger4,
            Fingers.Finger5
        });

        //Set2:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger1,
            Fingers.Finger3,
            Fingers.Finger2,
            Fingers.Finger4,
            Fingers.Finger5
        });

        //Set3:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger1,
            Fingers.Finger4,
            Fingers.Finger2,
            Fingers.Finger3,
            Fingers.Finger5
        });

        //Set4:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger1,
            Fingers.Finger5,
            Fingers.Finger2,
            Fingers.Finger3,
            Fingers.Finger4
        });

        //Set5:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger2,
            Fingers.Finger1,
            Fingers.Finger3,
            Fingers.Finger4,
            Fingers.Finger5
        });

        //Set6:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger2,
            Fingers.Finger3,
            Fingers.Finger1,
            Fingers.Finger4,
            Fingers.Finger5
        });

        //Set7:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger2,
            Fingers.Finger4,
            Fingers.Finger1,
            Fingers.Finger3,
            Fingers.Finger5
        });

        //Set8:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger3,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger4,
            Fingers.Finger5
        });

        //Set9:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger3,
            Fingers.Finger2,
            Fingers.Finger1,
            Fingers.Finger4,
            Fingers.Finger5
        });

        //Set10:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger3,
            Fingers.Finger4,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger5
        });

        //Set11:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger4,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger3,
            Fingers.Finger5
        });

        //Set12:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger4,
            Fingers.Finger2,
            Fingers.Finger1,
            Fingers.Finger3,
            Fingers.Finger5
        });

        //Set13:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger4,
            Fingers.Finger3,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger5
        });

        //Set14:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger4,
            Fingers.Finger5,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger3
        });

        //Set15:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger5,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger3,
            Fingers.Finger4
        });

        //Set16:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger5,
            Fingers.Finger2,
            Fingers.Finger1,
            Fingers.Finger3,
            Fingers.Finger4
        });

        //Set17:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger5,
            Fingers.Finger3,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger4
        });

        //Set18:
        FingerSets.Add( new List<Fingers>
        {
            Fingers.Finger5,
            Fingers.Finger4,
            Fingers.Finger1,
            Fingers.Finger2,
            Fingers.Finger3
        });

        //Set19:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger5,
            Fingers.Finger4,
            Fingers.Finger3,
            Fingers.Finger2,
            Fingers.Finger1
        });

        //Set20:
        FingerSets.Add(new List<Fingers>
        {
            Fingers.Finger5,
            Fingers.Finger3,
            Fingers.Finger4,
            Fingers.Finger2,
            Fingers.Finger1
        });

        for (int i = 0; i < RoundsTotoal; ++i)
        {
            List<Fingers> set = FingerSets[UnityEngine.Random.Range(0, FingerSets.Count - 1)];
            RoundRequiredFingers.Add(set);
        }
    }
    // Update is called once per frame
    void Update()
    {
        keypressTimer += Time.deltaTime;
        if (keypressTimer > KeyPressTime)
        {
            keypressTimer = 0.0f;
            if (currentRound <= RoundRequiredFingers.Count)
            {
                if (currentKeypressIndex < RoundRequiredFingers[currentRound].Count)
                {
                    Fingers currentFinger = RoundRequiredFingers[currentRound][currentKeypressIndex];
                    print(currentFinger);
                    bool playerOnePressed = GetKeyWasPressed(currentFinger, 1);
                    bool playerTwoPressed = GetKeyWasPressed(currentFinger, 2);

                    print(playerOnePoints);
                    print(playerTwoPoints);

                    //Resolve key
                    if (playerOnePressed == true && playerTwoPressed == true)
                    {
                        if (playerOneSucceds == true)
                            print(playerOnePoints++);

                        if (playerTwoSucceds == true)
                            print(playerTwoPoints++);
                    }
                    if (playerOnePressed == true && playerTwoPressed == false)
                    {
                        if (playerOneSucceds == true)
                            print(playerOnePoints++);

                        playerTwoSucceds = false;
                    }
                    if (playerTwoPressed == true && playerOnePressed == false)
                    {
                        if (playerTwoSucceds == true)
                            print(playerTwoPoints++);

                        playerOneSucceds = false;
                    }
                    if (playerOnePressed == false && playerTwoPressed == false)
                    {
                        playerOneSucceds = false;
                        playerOneSucceds = false;
                    }

                    currentKeypressIndex++;
                    if (currentKeypressIndex >= RoundRequiredFingers[currentRound].Count)
                    {
                        playerOneSucceds = true;
                        playerTwoSucceds = true;
                        currentKeypressIndex = 0;
                        currentRound++;
                        KeyPressTime *= 0.9f;
                    }
                }
            }
        }
    }

    private bool GetKeyWasPressed(Fingers currentFinger, int v)
    {
        if (currentFinger == Fingers.Finger1)
        {
            if (v == 1) return Input.GetKey(KeyCode.Q);
            if (v == 2) return Input.GetKey(KeyCode.Y);
        }
        if (currentFinger == Fingers.Finger2)
        {
            if (v == 1) return Input.GetKey(KeyCode.W);
            if (v == 2) return Input.GetKey(KeyCode.U);
        }
        if (currentFinger == Fingers.Finger3)
        {
            if (v == 1) return Input.GetKey(KeyCode.E);
            if (v == 2) return Input.GetKey(KeyCode.I);
        }
        if (currentFinger == Fingers.Finger4)
        {
            if (v == 1) return Input.GetKey(KeyCode.R);
            if (v == 2) return Input.GetKey(KeyCode.O);
        }
        if (currentFinger == Fingers.Finger5)
        {
            if (v == 1) return Input.GetKey(KeyCode.T);
            if (v == 2) return Input.GetKey(KeyCode.P);
        }
        return false;
    }
}




