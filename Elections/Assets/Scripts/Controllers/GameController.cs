using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static Game game;
    private static Storage storage;
    private static TurnStorage turnStorage;
    private static SettingsStorage settingsStorage;
    private static bool isGameLoaded;
    private static int isLoad;
    private static int RecordTurn;
    private static Settings settings;


    private void Awake()
    {
        LeanTween.init(3200);
        storage = new Storage();
        turnStorage = new TurnStorage();
        settingsStorage = new SettingsStorage();
        game = new Game();
        settings = new Settings();
        isGameLoaded = false;
        isLoad = PlayerPrefs.GetInt("isLoad");


        RecordTurn = (int)turnStorage.Load(1);
        settings = settingsStorage.Load(settings) as Settings;
    }

    private void Start()
    {
        SoundsController.SwitchSounds(settings.Sound);
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

    public static void UpdateRecord(int turn)
    {
        if (turn > RecordTurn)
        {
            RecordTurn = turn;
            turnStorage.Save(turn);
        }
    }
}
