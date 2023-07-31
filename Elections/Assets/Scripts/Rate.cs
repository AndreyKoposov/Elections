using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rate : MonoBehaviour
{
    private float lerpSpeed;
    [SerializeField] private float startRate = 50;
    [SerializeField] private Image rateBar;

    private void Start()
    {
        SetRate(startRate);
    }

    private void Update()
    {
        SetRate(startRate);
        lerpSpeed = 3f * Time.deltaTime;
    }

    public void SetRate(float rate)
    {
        startRate = rate;
        rateBar.fillAmount = Mathf.Lerp(rateBar.fillAmount, rate / Fraction.MAX_RATE, lerpSpeed);
    }
}
