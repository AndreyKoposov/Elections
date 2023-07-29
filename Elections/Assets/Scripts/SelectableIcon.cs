using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableIcon : MonoBehaviour
{
    private RectTransform rect;
    private float startTransparent;
    [SerializeField] private float _transparent;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startTransparent = gameObject.GetComponent<Image>().color.a;
    }
    public void Select()
    {
        LeanTween.scale(rect, new Vector2(1.1f, 1.1f), 0.2f);
        LeanTween.color(rect, new Color(1f, 1f, 1f, _transparent), 0.1f);
    }

    public void Deselect()
    {
        LeanTween.scale(rect, new Vector2(1f, 1f), 0.2f);
        LeanTween.color(rect, new Color(1f, 1f, 1f, startTransparent), 0.1f);
    }
}
