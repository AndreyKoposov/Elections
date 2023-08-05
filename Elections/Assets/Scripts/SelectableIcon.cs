using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableIcon : MonoBehaviour
{
    private RectTransform rect;
    private float startTransparent;
    private Button button;
    [SerializeField] private float _transparent;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startTransparent = gameObject.GetComponent<Image>().color.a;
        button = GetComponent<Button>();
    }

    public void SetSmaller()
    {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x * 0.9f, rect.sizeDelta.y * 0.9f);
        Vector2 temp = rect.localPosition;
        temp.y -= 15;
        rect.localPosition = temp;
    }

    private void Update()
    {
        if(button != null)
            button.interactable = !PanelController.Instance.InfoMode;
    }

    public void Select()
    {
        LeanTween.scale(rect, new Vector2(1.07f, 1.07f), 0.2f);
        LeanTween.color(rect, new Color(1f, 1f, 1f, _transparent), 0.1f);
    }

    public void Deselect()
    {
        LeanTween.scale(rect, new Vector2(1f, 1f), 0.2f);
        LeanTween.color(rect, new Color(1f, 1f, 1f, startTransparent), 0.1f);
    }
}
