using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    public void Show()
    {
        LeanTween.moveLocalY(gameObject, 0, 0.7f);
    }

    public void Hide()
    {
        LeanTween.moveLocalY(gameObject, -1003, 0.4f);
    }
}
