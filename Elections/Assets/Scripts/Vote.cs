using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VoteState
{
    None, Against, For
}

public class Vote : MonoBehaviour
{
    private Check check;
    private Cross cross;
    private VoteState state;

    public VoteState State
    {
        get { return state; }
    }

    private void Awake()
    {
        state = VoteState.None;
        check = GetComponentInChildren<Check>();
        cross = GetComponentInChildren<Cross>();
    }

    public void SetFor()
    {
        state = VoteState.For;
        check.On();
    }

    public void SetAgainst()
    {
        state = VoteState.Against;
        cross.On();
    }

    public void ResetState()
    {
        state = VoteState.None;
        cross.Off();
        check.Off();
    }

    public void SetRandomState(int rate)
    {
        int randomNumber = Randomizer.GetRandom(Fraction.MIN_RATE, Fraction.MAX_RATE + 1);

        if (randomNumber < rate)
            SetFor();
        else
            SetAgainst();
    }
}
