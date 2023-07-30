using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : GameButton
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Show()
    {
        LeanTween.moveLocalX(gameObject, 0, MOVE_TIME);
    }

    public override void Hide()
    {
        LeanTween.moveLocalX(gameObject, 1400, MOVE_TIME);
    }

    public void StartGame()
    {
        StartCoroutine(waiter());
    }

    private IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(1);
    }
}
