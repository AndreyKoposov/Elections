using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oligarch : Fraction
{
    private const Fractions TYPE = Fractions.OLIGARCH;
    private const ResTypes _typeRes = ResTypes.MONEY;
    [SerializeField] private TextAsset PATH;
    [SerializeField] private TextAsset HELP_FILE;
    public static List<QuestINFO> Quests = new List<QuestINFO>();
    public static FractionHelpINFO _info;


    public override Fractions Type
    {
        get { return TYPE; }
    }
    public override ResTypes TypeRes
    {
        get { return _typeRes; }
    }

    public override void InitQuests()
    {
        Quests.Clear();
        DataContainer.ReadQuestsFileToList(PATH, Quests);
    }

    public override void InitHelpInfo()
    {
        _info = DataContainer.ParseFileToInfoObj(HELP_FILE);
    }

    protected override FractionHelp GetHelp()
    {
        FractionHelp help = new FractionHelp(this, _info);
        return help;
    }
}
