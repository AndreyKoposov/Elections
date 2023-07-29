using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkController : MonoBehaviour
{
    private RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    void Start()
    {
        LeanTween.color(rect, new Color(0, 0, 0, 0), 100f);
    }


    public void MakeDark()
    {
        LeanTween.color(rect, new Color(0, 0, 0, 255), 50f);
    }
}
