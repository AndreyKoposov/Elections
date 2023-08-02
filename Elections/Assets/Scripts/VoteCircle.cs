using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoteCircle : MonoBehaviour
{
    private float lerpSpeed;
    [SerializeField] private float startVote = 0;
    [SerializeField] private Image circleBar;
    [SerializeField] private TextMeshProUGUI percent;

    
    private void Start()
    {
        SetVote(startVote);
    }

    private void Update()
    {
        SetVote(startVote);
        lerpSpeed = 3f * Time.deltaTime;
    }

    public void SetVote(float vote)
    {
        startVote = vote;

        float percentVote = vote / Game.TOTAL_VOTES;
        SetText(percentVote);

        circleBar.fillAmount = Mathf.Lerp(circleBar.fillAmount, percentVote, lerpSpeed);
    }

    private void SetText(float vote) 
    {
        percent.text = (ToIntegerPercent(vote)).ToString() + "%";
    }

    private int ToIntegerPercent(float vote)
    {
        return (int)(vote * 100);
    }
}
