using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    protected const float MOVE_TIME = 0.6f;
    protected RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public virtual void Show()
    {

    }

    public virtual void Hide()
    {

    }
}
