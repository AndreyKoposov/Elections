using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : GameButton
{
    void Start()
    {

    }

    public override void Show()
    {
        LeanTween.moveLocalX(gameObject, 0, MOVE_TIME);
    }

    public override void Hide()
    {
        LeanTween.moveLocalX(gameObject, 1400, MOVE_TIME);
    }
}