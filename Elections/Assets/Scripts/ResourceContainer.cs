using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceContainer : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private ResTypes _type;

    public int Value
    {
        get { return _value; }
        set
        {
            int buffer = _value;
            _value = value;
            if (_value > 100)
                _value = 100;
            if (_value < 0)
                _value = 0;
            int diff = _value - buffer;
        }
    }

    public ResTypes Type
    {
        get { return _type; }
    }

    public static int CompareResource(ResourceContainer x, ResourceContainer y)
    {
        return x.Value.CompareTo(y.Value);
    }
}
