using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static Game game;
    private static Storage storage;
    private static bool isGameLoaded;
    private static int isLoad;

    private void Awake()
    {
        LeanTween.init(3200);
        storage = new Storage();
        game = new Game();
        isGameLoaded = false;
        isLoad = PlayerPrefs.GetInt("isLoad");
    }

    private void FixedUpdate()
    {
        if (!isGameLoaded && isLoad == 1)
        {
            LoadData();
        }
    }

    public static void DeleteSave()
    {
        storage.Delete();
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
        
        if(game.Container != null)
            game.Container.Load(FractionGroup.Group, ResourceGroup.Group);

        FractionGroup.OffInteractive(game.WhoWasAsked);

        isGameLoaded = true;
    }
}
