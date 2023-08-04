using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : GameButton
{
    void Start()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, 0f), 0.001f);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public override void Show()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, 0.6f), 0.7f);
    }

    public override void Hide()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, 0f), 0.4f);
    }
}