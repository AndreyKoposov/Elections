using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    private static TurnStorage turnStorage;
    private static SettingsStorage settingsStorage;
    private static int recordTurn;
    private static Settings settings;

    private void Awake()
    {
        LeanTween.init(800);
        turnStorage = new TurnStorage();
        settingsStorage = new SettingsStorage();
        settings = new Settings();

        recordTurn = (int)turnStorage.Load(1);

        settings = settingsStorage.Load(settings) as Settings;
        if (settings == null)
            InitSettingByDefault();
    }

    private void Start()
    {
        SoundsController.SwitchSounds(settings.Sound);
    }

    public static Settings Settings
    {
        get { return settings; }
    }

    public static int RecordTurn
    {
        get { return recordTurn; }
    }

    public static void SaveSettings()
    {
        settingsStorage.Save(settings);
    }

    public void InitSettingByDefault()
    {
        settings = new Settings();
    }
}
