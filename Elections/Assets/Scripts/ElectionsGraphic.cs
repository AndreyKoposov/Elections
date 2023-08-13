using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectionsGraphic : MonoBehaviour
{
    [SerializeField] private VoteCircle red;
    [SerializeField] private VoteCircle green;


    public void SetRed(int vote)
    {
        red.SetVote(vote);
    }

    public void SetGreen(int vote)
    {
        green.SetVote(vote);
    }

    public void ResetBoth()
    {
        green.SetVote(0);
        red.SetVote(0);
    }
}
