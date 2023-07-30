using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPES
{
    TYPE1, TYPE2, TYPE3, TYPE4, TYPE5, TYPE6
}

public class QuestINFO
{
    public string _text;
    public string _yesAnswer;
    public string _noAnswer;
    public TYPES _type;
    public List<Fractions> _fractions;
    public List<ResTypes> _resources;

    public QuestINFO(string text, string yes, string no, TYPES type,
                     List<Fractions> fractions, List<ResTypes> resources)
    {
        _text = text;
        _yesAnswer = yes;
        _noAnswer = no;
        _type = type;
        _fractions = fractions;
        _resources = resources;
    }
}
