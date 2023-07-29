using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    private Button[] buttons;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    void Start()
    {
        Show();
    }

    public void Show()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<GameButton>().Show();
        }
    }

    public void Hide()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<GameButton>().Hide();
        }
    }
}
