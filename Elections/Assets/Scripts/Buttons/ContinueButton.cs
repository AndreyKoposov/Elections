using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : GameButton
{
    void Start()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, 0f), 0.001f);
    }

    public override void Show()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, 0.6f), 1f);
    }

    public override void Hide()
    {
        LeanTween.color(rect, new Color(1f, 1f, 1f, 0f), 0.4f);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("isLoad", 1);
        StartCoroutine(waiter());
    }

    private IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(1);
    }
}