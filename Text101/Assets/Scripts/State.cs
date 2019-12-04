using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    // Start is called before the first frame update
    [TextArea(15, 20)][SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    //[SerializeField] State[] inventory;
    //[SerializeField] State[] amuletStates;
    //[SerializeField] State[] keyStates;
    //[SerializeField] State[] ringStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    //public State[] GetNextAmuletStates()
    //{
    //    return nextStates;
    //}

    //public State[] GetNextKeyStates()
    //{
    //    return nextStates;
    //}

    //public State[] GetNextRingStates()
    //{
    //    return nextStates;
    //}

}
