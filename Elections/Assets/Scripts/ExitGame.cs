using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private static ExitGame instance;
    private Button button;

    public static Button Instance
    {
        get { return instance.button; }
    }

    private void Awake()
    {
        instance = this;
        button = GetComponent<Button>();
    }

    public void BackToMenu()
    {
        StartCoroutine(Courutine());
    }

    private IEnumerator Courutine()
    {
        PanelController.Instance.RemoveFromCenter();
        DarkController.Instance.MakeDark();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}
