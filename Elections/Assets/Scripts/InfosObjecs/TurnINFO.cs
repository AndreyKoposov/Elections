using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TurnINFO
{
    private string _header;
    private Dictionary<Fractions, int> _infoFractions;
    private Dictionary<ResTypes, int> _infoResources;

    public TurnINFO(int turnNumber)
    {
        _header = $"Результаты хода {turnNumber}\n";
        _infoFractions = new Dictionary<Fractions, int>();
        _infoResources = new Dictionary<ResTypes, int>();
    }

    public void AddNewChangeInfo(Fractions fraction, int value)
    {
        if (value == 0) return;
        if (_infoFractions.ContainsKey(fraction))
        {
            _infoFractions[fraction] += value;
        }
        else
            _infoFractions.Add(fraction, value);
    }

    public void AddNewChangeInfo(ResTypes type, int value)
    {
        if (value == 0) return;
        if (_infoResources.ContainsKey(type))
        {
            _infoResources[type] += value;
        }
        else
            _infoResources.Add(type, value);
    }

    public string InfoToStringLine(Fractions fraction, int value)
    {
        char arrow = GetArrowDirect(value);
        value = Mathf.Abs(value);
        string infoLine = $"\n - Фракция {EnumConverter.ToString(fraction)}:   {arrow} {value}";
        return infoLine;
    }

    public string InfoToStringLine(ResTypes type, int value)
    {
        char arrow = GetArrowDirect(value);
        value = Mathf.Abs(value);
        string infoLine = $"\n - {EnumConverter.ToString(type)}:   {arrow} {value}";
        return infoLine;
    }

    private char GetArrowDirect(int value)
    {
        char arrow = ' ';
        if (value > 0)
            return arrow = '?';
        if (value < 0)
            return arrow = '?';
        return arrow;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_header);
        sb.Append(DictToString(_infoFractions));
        sb.Append(DictToString(_infoResources));
        return sb.ToString();
    }

    private string DictToString(Dictionary<Fractions, int> dict)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var pair in dict)
        {
            string infoLine = InfoToStringLine(pair.Key, pair.Value);
            sb.Append(infoLine);
        }
        return sb.ToString();
    }

    private string DictToString(Dictionary<ResTypes, int> dict)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var pair in dict)
        {
            string infoLine = InfoToStringLine(pair.Key, pair.Value);
            sb.Append(infoLine);
        }
        return sb.ToString();
    }
}
