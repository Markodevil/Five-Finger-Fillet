using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
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

    public int RoundsTotoal = 5;

    private int currentRound = 0;
    private int currentFingureIndex = 0;

    private int playerOnePoints = 0;
    private int playerTwoPoints = 0;



    private bool playerOneSucceds = false;
    private bool playerTwoSucceds = false;

    private bool playerOneHasFailedThisRound = false;
    private bool playerTwoHasFailedThisRound = false;


    public float WaitStateTime = 1.0f;
    private float waitStateTimer = 0.0f;
    //private float keyPressTimer = 0.0f;

    private enum State
    {
        STATE_WAIT,
        STATE_PLAY,
        STATE_END,
    }

    private State state;



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
        FingerSets.Add(new List<Fingers>
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
        switch(state)
        {
            case State.STATE_WAIT:
                update_WaitState();
                break;
            case State.STATE_PLAY:
                update_PlayState();
                break;
        }
    }

    void update_WaitState()
    {
        Fingers currentFinger = RoundRequiredFingers[currentRound][currentFingureIndex];
        print(currentFinger);

        if(playerOneSucceds == false)
        {
            playerOneSucceds = GetKeyWasPressed(currentFinger, 1);
        }
        if (playerTwoSucceds == false)
        {
            playerTwoSucceds = GetKeyWasPressed(currentFinger, 2);
        }


        //Transition
        waitStateTimer += Time.deltaTime;
        if(waitStateTimer > WaitStateTime)
        {
            waitStateTimer = 0.0f;
            state = State.STATE_PLAY;
            Debug.Log(waitStateTimer);
        }
   
    }

    void update_PlayState()
    {
        if (!playerOneHasFailedThisRound && playerOneSucceds == true)
        {
            print(playerOnePoints++);
        }
        else
        {
            playerOneHasFailedThisRound = true;
        }

        if (!playerTwoHasFailedThisRound && playerTwoSucceds == true)
        {
            print(playerTwoPoints++);
        }
        else
        {
            playerTwoHasFailedThisRound = true;
        }

        playerOneSucceds = false;
        playerTwoSucceds = false;

        currentFingureIndex++;
        if (currentFingureIndex >= RoundRequiredFingers[currentRound].Count)
        {
            playerOneHasFailedThisRound = false;
            playerTwoHasFailedThisRound = false;

            currentFingureIndex = 0;
            currentRound++;
        }

        //Transition
        if (currentRound >= RoundRequiredFingers.Count)
        {
            state = State.STATE_END;
        }
        else
        {
            state = State.STATE_WAIT;
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




