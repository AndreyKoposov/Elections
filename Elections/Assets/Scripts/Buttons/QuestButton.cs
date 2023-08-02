using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : GameButton
{
    private RectTransform rect;
    private float startTransparent;
    [SerializeField] private float _transparent;
    [SerializeField] private int direction;

    private void Awake()
    {
        rect = gameObject.GetComponent<RectTransform>();
        startTransparent = gameObject.GetComponent<Image>().color.a;
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        LeanTween.color(rect, new Color(1f, 1f, 1f, _transparent), 0.2f);
        LeanTween.moveLocalX(gameObject, 325 * direction, MOVE_TIME / 8);
    }

    public override void Hide()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, startTransparent), 0.1f);
        LeanTween.moveLocalX(gameObject, 0, MOVE_TIME / 20);
        gameObject.SetActive(false);
    }
}
