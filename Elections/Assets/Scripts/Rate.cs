using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rate : MonoBehaviour
{
    private float lerpSpeed;
    private Color salat;
    private Color red;
    private Color yel;
    [SerializeField] private float startRate = 50;
    [SerializeField] private Image rateBar;
    private RectTransform rect;

    private void Awake()
    {
        salat = new Color(56f / 255f, 239f / 255f, 125f / 255f);
        red = new Color(239f / 255f, 56f / 255f, 58f / 255f);
        yel = new Color(255f / 255f, 239f / 255f, 125f / 255f);
        rect = rateBar.gameObject.GetComponent<RectTransform>();
    }

    private void Start()
    {
        SetRate(startRate);
        ChangeColor();
    }

    private void Update()
    {
        SetRate(startRate);
        ChangeColor();
        lerpSpeed = 3f * Time.deltaTime;
    }

    public void SetRate(float rate)
    {
        startRate = rate;
        rateBar.fillAmount = Mathf.Lerp(rateBar.fillAmount, rate / Fraction.MAX_RATE, lerpSpeed);
    }

    public void ChangeColor()
    {
        if (startRate / Fraction.MAX_RATE <= 0.25f)
        {
            LeanTween.color(rect, red, 0.4f);
            return;
        }
        if (startRate / Fraction.MAX_RATE >= 0.75f)
        {
            LeanTween.color(rect, salat, 0.4f);
            return;
        }
        LeanTween.color(rect, yel, 0.4f);
    }
}
