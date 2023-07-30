using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkController : MonoBehaviour
{
    private static DarkController instance;
    private RectTransform rect;
    
    public static DarkController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
        rect = GetComponent<RectTransform>();
    }

    void Start()
    {
        ResetDark();
    }


    public void MakeDark()
    {
        LeanTween.color(rect, new Color(0, 0, 0, 1f), 0.5f);
    }

    public void ResetDark()
    {
        LeanTween.color(rect, new Color(0, 0, 0, 0), 0.5f);
    }
}
