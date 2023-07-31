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
    public GameButton _rightButton;
    public GameButton _leftButton;
    public GameButton _centerButton;
    private ActionPerform _performRight;
    private ActionPerform _performLeft;
    [SerializeField] private ResourceGroup _resGroup;
    [SerializeField] private FractionGroup _fractionGroup;
    private MoveableImage _infoIamge;

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

    public MoveableImage InfoIamge
    {
        set { _infoIamge = value; }
    }

    public void MoveToCenter()
    {
        LeanTween.moveLocalX(gameObject, 30f, 0.3f);
    }

    public void RemoveFromCenter()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        LeanTween.moveLocalX(gameObject, 1740f, 0.3f);
        LeanTween.moveLocalX(_infoIamge.gameObject, 1740f, 0.3f);

        yield return new WaitForSeconds(0.3f);

        _infoIamge.ResetImage();
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
        GameController.Game.NextTurn();
    }

    public void LeftClick()
    {
        _performLeft(_fractionGroup, _resGroup);
        RemoveFromCenter();
        GameController.Game.NextTurn();
    }

    public void SetChooseMode()
    {
        _rightButton.gameObject.SetActive(true);
        _leftButton.gameObject.SetActive(true);
        _centerButton.gameObject.SetActive(false);
    }

    public void SetDefaultMode()
    {
        _rightButton.gameObject.SetActive(false);
        _leftButton.gameObject.SetActive(false);
        _centerButton.gameObject.SetActive(true);
    }
}
