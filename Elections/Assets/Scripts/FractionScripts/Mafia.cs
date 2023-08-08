using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Mafia : Fraction
{
    private const Fractions TYPE = Fractions.MAFIA;
    private const ResTypes _typeRes = ResTypes.METAL;
    [SerializeField] private TextAsset QUEST_FILE;
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
        DataContainer.ReadQuestsFileToList(QUEST_FILE, Quests);

        StringBuilder stringBuilder = new StringBuilder();
        foreach (QuestINFO info in Quests)
        {
            stringBuilder.AppendLine(info._text + " " + info._type + "\n");
        }
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
