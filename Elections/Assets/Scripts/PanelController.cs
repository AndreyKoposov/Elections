using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    private static PanelController instance;
    public TextMeshProUGUI _text;
    public TextMeshProUGUI _leftButtonText;
    public TextMeshProUGUI _rightButtonText;
    public TextMeshProUGUI _centerButtonText;
    private ActionPerform _performRight;
    private ActionPerform _performLeft;
    [SerializeField] private ResourceGroup _resGroup;
    [SerializeField] private FractionGroup _fractionGroup;

    public static PanelController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }
    
    public ActionPerform Right
    {
        set { _performRight = value; }
    }

    public ActionPerform Left
    {
        set { _performLeft = value; }
    }

    public void MoveToCenter()
    {
        LeanTween.moveLocalX(gameObject, 30f, 0.3f);
    }

    public void RemoveFromCenter()
    {
        LeanTween.moveLocalX(gameObject, 1740f, 0.3f);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void SetRightButtonText(string text)
    {
        _rightButtonText.text = text;
    }

    public void SetLeftButtonText(string text)
    {
        _leftButtonText.text = text;
    }

    public void SetCenterButtonText(string text)
    {
        _centerButtonText.text = text;
    }

    public void RightClick()
    {
        _performRight(_fractionGroup, _resGroup);
        RemoveFromCenter();
    }

    public void LeftClick()
    {
        _performLeft(_fractionGroup, _resGroup);
        RemoveFromCenter();
    }
}
