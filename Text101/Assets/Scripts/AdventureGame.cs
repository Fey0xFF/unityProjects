using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    public bool amuletBoss = false;
    public bool amuletBossLive = false;

    State state;

    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {

        var nextStates = state.GetNextStates();

        if (nextStates[0].name =="GoodEnding" && !amuletBoss)
        {
            amuletBoss = true;
            amuletBossLive = true;
        }

        if (amuletBossLive)
        {
            if (Input.GetKeyDown(KeyCode.S)) {
                state = nextStates[0];
                ResetState();
                
            }
            else if (Input.anyKeyDown) {
                state = nextStates[1];
                ResetState();
            }
        }

        if (!amuletBossLive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = nextStates[0];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = nextStates[1];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = nextStates[2];
            }
        }

        textComponent.text = state.GetStateStory();
    }

    private void ResetState()
    {
        amuletBossLive = false;
        amuletBoss = false;
    }

}
