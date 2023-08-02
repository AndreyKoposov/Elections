using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static Game game;

    private void Awake()
    {
        LeanTween.init(800);
        game = new Game();
    }

    public static Game Game
    {
        get { return game; }
    }
}
