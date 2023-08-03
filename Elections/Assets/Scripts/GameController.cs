using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static Game game;
    public static Storage storage;

    private void Awake()
    {
        LeanTween.init(1600);
        storage = new Storage();
        game = new Game();
    }

    private void Start()
    {
        int isLoad = PlayerPrefs.GetInt("isLoad");
        if (isLoad == 1)
        {
            LoadData();
        }
    }



    public static Game Game
    {
        get { return game; }
    }

    public static void SaveGame()
    {
        game.Container = new SerializableContainer(FractionGroup.Group, ResourceGroup.Group);

        storage.Save(game);
    }

    private static void LoadData()
    {
        game = storage.Load(game) as Game;
        
        game.Container.Load(FractionGroup.Group, ResourceGroup.Group);
    }
}
