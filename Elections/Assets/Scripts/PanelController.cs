using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    private static PanelController instance;
    public TextMeshProUGUI _text;
    public GameButton _leftButton;
    public GameButton _rightButton;
    public GameButton _centerButton;
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
        set { _performLeft = value; }
    }

    public ActionPerform Left
    {
        set { _performRight = value; }
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
