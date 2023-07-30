using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static Game game;

    private void Awake()
    {
        game = new Game();
    }

    public static Game Game
    {
        get { return game; }
    }
}
