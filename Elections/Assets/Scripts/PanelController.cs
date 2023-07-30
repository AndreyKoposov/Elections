using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    private static PanelController instance;

    public static PanelController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    public void MoveToCenter()
    {
        LeanTween.moveLocalX(gameObject, 30f, 0.3f);
    }

    public void RemoveFromCenter()
    {
        LeanTween.moveLocalX(gameObject, 1740f, 0.3f);
    }
}
