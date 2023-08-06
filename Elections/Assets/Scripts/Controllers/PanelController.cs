using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    private static PanelController instance;
    public ElectionsGraphic graphic;
    public TextMeshProUGUI _text;
    private RectTransform _textRect;
    public TextMeshProUGUI _leftButtonText;
    public TextMeshProUGUI _rightButtonText;
    public TextMeshProUGUI _centerButtonText;
    public GameButton _rightButton;
    public GameButton _leftButton;
    public GameButton _centerButton;
    private ActionPerform _performRight;
    private ActionPerform _performLeft;
    private CenterButtonAction _performCenterButton;
    [SerializeField] private ResourceGroup _resGroup;
    [SerializeField] private FractionGroup _fractionGroup;
    private MoveableImage _fractionImage;
    [SerializeField] private GameObject _infoImage;
    private Animator _animator; 
    private bool infoMode = false;
    private bool teachMode = false;
    [SerializeField] private GameObject cancelButton;

    public static PanelController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
        _animator = _infoImage.GetComponent<Animator>();
        HidePanelImage();
        _performCenterButton = () => { };
        _textRect = _text.gameObject.GetComponent<RectTransform>();
    }
    
    public ActionPerform Right
    {
        set { _performRight = value; }
    }

    public bool InfoMode
    {
        get { return infoMode; }
    }

    public ActionPerform Left
    {
        set { _performLeft = value; }
    }

    public MoveableImage InfoIamge
    {
        set { _fractionImage = value; }
    }

    public void MoveToCenter(float secondsToWait)
    {
        ExitGame.Instance.interactable = false;
        StartCoroutine(MoveToCenterAnimation(secondsToWait));
    }

    public void MoveToCenter(float secondsToWait, int forVotes)
    {
        ExitGame.Instance.interactable = false;
        StartCoroutine(MoveToCenterAnimationElection(secondsToWait, forVotes));
    }

    public void RemoveFromCenter()
    {
        infoMode = false;
        StartCoroutine(Animation());
        ExitGame.Instance.interactable = true;
    }

    private IEnumerator MoveToCenterAnimation(float secondToWait)
    {
        yield return new WaitForSeconds(secondToWait);
        LeanTween.moveLocalX(gameObject, 30f, 0.3f);
    }

    private IEnumerator MoveToCenterAnimationElection(float secondToWait, int forVotes)
    {
        yield return new WaitForSeconds(secondToWait);
        LeanTween.moveLocalX(gameObject, 30f, 0.3f);
        yield return new WaitForSeconds(0.2f);
        Instance.graphic.SetGreen(forVotes);
        Instance.graphic.SetRed(Game.TOTAL_VOTES - forVotes);
    }

    private IEnumerator Animation()
    {
        LeanTween.moveLocalX(gameObject, 1740f, 0.3f);

        if(_fractionImage != null)
         LeanTween.moveLocalX(_fractionImage.gameObject, 1740f, 0.3f);

        yield return new WaitForSeconds(0.3f);

        if (_fractionImage != null)
            _fractionImage.ResetImage();
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
        if (!infoMode)
        {
            EndTurn(0.3f);
        }
    }

    public void LeftClick()
    {
        _performLeft(_fractionGroup, _resGroup);
        RemoveFromCenter();
        if (!infoMode)
        {
            EndTurn(0.3f);
        }
    }

    public void CenterClick()
    {
        if(!teachMode)
            RemoveFromCenter();
        if (!infoMode && !teachMode)
        {
            EndTurn(0.3f);
        }
        _performCenterButton();
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

    public void SetInfoMode()
    {
        infoMode = true;
        teachMode = false;
    }

    public void SetGameMode()
    {
        infoMode = false;
        teachMode = false;
    }

    public void SetTeachMode()
    {
        teachMode = true;
    }

    public static void SetUpPanel(Quest quest)
    {
        Instance.SetGameMode();
        Instance.SetChooseMode();
        Instance.SetText(quest._info._text);
        Instance.SetLeftButtonText(quest._info._yesAnswer);
        Instance.SetRightButtonText(quest._info._noAnswer);
        Instance.Left = quest._taskAcception;
        Instance.Right = quest._taskDeviation;
    }

    public static void SetUpPanel(FractionHelp help)
    {
        Instance.SetGameMode();
        Instance.SetChooseMode();
        Instance.SetText(help._info._text);
        Instance.SetLeftButtonText(help._info._yesAnswer);
        Instance.SetRightButtonText(help._info._noAnswer);
        Instance.Left = help._leftChoose;
        Instance.Right = help._rightChoose;
    }

    public static void SetUpPanel(GameOverINFO over)
    {
        Instance.SetInfoMode();
        Instance.SetText(over._text);
        Instance.SetCenterButtonText(over._answer);
        Instance.SetPanelImage((int)over._reason + 1);
        Instance._performCenterButton = over._ButtonClick;
    }

    public static void SetUpPanel(ElectionINFO election)
    {
        Instance.graphic.gameObject.SetActive(true);
        Instance.SetInfoMode();
        Instance.SetText(election._text);
        Instance.SetCenterButtonText(election._answerText);
        Instance.SetPanelImage(election._win);
        Instance._performCenterButton = election._ButtonClick;
    }


    public void EndTurn(float seconds)
    {
        StartCoroutine(Coroutine(seconds));
    }

    private IEnumerator Coroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameController.Game.NextTurn();
    }

    private void SetPanelImage(int type)
    {
        _infoImage.SetActive(true);
        Instance._animator.SetInteger("type", type);
    }
    private void SetPanelImage(bool isWin)
    {
        _infoImage.SetActive(true);
        if(isWin)
            Instance._animator.SetInteger("type", 5);
        else
            Instance._animator.SetInteger("type", 6);
    }

    public void HidePanelImage()
    {
        _infoImage.SetActive(false);
        Instance._animator.SetInteger("type", 0);
    }

    public void EndGame()
    {
        StartCoroutine(Courutine());
    }

    private IEnumerator Courutine()
    {
        Instance.RemoveFromCenter();
        DarkController.Instance.MakeDark();
        yield return new WaitForSeconds(0.5f);
        GameController.DeleteSave();
        SceneManager.LoadScene(0);
    }

    public void StartTeach()
    {
        Instance.SetTeachMode();
        Instance.SetDefaultMode();
        MoveToCenter(0);
        cancelButton.SetActive(true);

        MoveTextLocalY(40);

        FirstTeach();
    }

    private void FirstTeach()
    {
        Instance.SetText(DataContainer.StartText);
        Instance.SetCenterButtonText("Спасибо!");
        Instance.SetPanelImage(9);
        Instance._performCenterButton = () => { SecondTeach(); };
    }

    private void SecondTeach()
    {
        Instance.SetText(DataContainer.LearnText);
        Instance.SetCenterButtonText("Понятно");
        Instance.SetPanelImage(0);
        Instance.SetPanelImage(7);
        Instance._performCenterButton = () => { ThirdTeach(); };
    }

    private void ThirdTeach()
    {
        Instance.SetText(DataContainer.LearnMarkText);
        Instance.SetCenterButtonText("Приступим!");
        Instance.SetPanelImage(0);
        Instance.SetPanelImage(8);
        Instance._performCenterButton = () => { EndTeach(); };
    }

    public void EndTeach()
    {
        Instance.SetDefaultMode();
        RemoveFromCenter();
        HidePanelImage();
        cancelButton.SetActive(false);

        MoveTextLocalY(-40);
    }

    private void MoveTextLocalY(float value)
    {
        Vector2 temp = _textRect.localPosition;
        temp.y += value;
        _textRect.localPosition = temp;
    }
}
