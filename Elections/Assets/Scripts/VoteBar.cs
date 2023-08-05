using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteBar : MonoBehaviour
{
    private List<Vote> votes;

    private void Awake()
    {
        InitVoteList();
    }

    public VoteState this[int k]
    {
        get { return votes[k].State; }
    }

    public int Lenght
    {
        get { return votes.Count; }
    }

    private void InitVoteList()
    {
        Vote[] votesArray = GetComponentsInChildren<Vote>();
        votes = new List<Vote>(votesArray);
    }

    public void SetForLast(int numberOfVotes)
    {
        foreach(Vote vote in votes)
        {
            if(isNone(vote) && numberOfVotes > 0)
            {
                vote.SetFor();
                numberOfVotes--;
            }
        }
    }

    public void SetAgainstLast(int numberOfVotes)
    {
        foreach (Vote vote in votes)
        {
            if (isNone(vote) && numberOfVotes > 0)
            {
                vote.SetAgainst();
                numberOfVotes--;
            }
        }
    }

    public void ResetAll()
    {
        foreach (Vote vote in votes)
        {
            vote.ResetState();
        }
    }

    public void FillReamaining(int rate)
    {
        foreach (Vote vote in votes)
        {
            if (isNone(vote))
                vote.SetRandomState(rate);
        }
    }

    public int CountVotes()
    {
        int counter = 0;
        foreach (Vote vote in votes)
        {
            if(isFor(vote))
                counter++;
        }
        return counter;
    }

    public bool isFilled()
    {
        foreach (Vote vote in votes)
        {
            if (isNone(vote))
                return false;
        }
        return true;
    }

    private bool isNone(Vote vote) 
    { 
        return vote.State == VoteState.None;
    }

    private bool isFor(Vote vote)
    {
        return vote.State == VoteState.For;
    }
}
