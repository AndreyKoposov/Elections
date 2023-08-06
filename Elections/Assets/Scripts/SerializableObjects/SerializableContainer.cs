using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializableContainer
{
    private Dictionary<int, FractionSerializable> _fractions;
    private Dictionary<int, ResourceSerializable> _resources;

    public SerializableContainer(Dictionary<Fractions, Fraction> fractions, Dictionary<ResTypes, ResourceContainer> resources)
    {
        _resources = new Dictionary<int, ResourceSerializable>();
        _fractions = new Dictionary<int, FractionSerializable>();
        foreach(var pair in fractions)
        {
            _fractions.Add((int)pair.Key, new FractionSerializable(pair.Value));
        }
        foreach (var pair in resources)
        {
            _resources.Add((int)pair.Key, new ResourceSerializable(pair.Value));
        }
    }

    public void Load(Dictionary<Fractions, Fraction> fractions, Dictionary<ResTypes, ResourceContainer> resources)
    {
        foreach (var pair in _fractions)
        {
            pair.Value.Load(fractions[(Fractions)pair.Key]);
        }
        foreach (var pair in _resources)
        {
            pair.Value.Load(resources[(ResTypes)pair.Key]);
        }
    }
}
