using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceContainer : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private ResTypes _type;
    [SerializeField] private TextMeshProUGUI _count;

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
            StartCoroutine(SetValueToCount(_value, buffer));
        }
    }

    private IEnumerator SetValueToCount(int valueNow, int valueBefore)
    {
        if(valueNow < valueBefore)
        {
            while(valueBefore > valueNow)
            {
                valueBefore--;
                _count.text = valueBefore.ToString();
                yield return new WaitForSeconds(0.03f);
            }
        }
        else
        {
            while (valueBefore < valueNow)
            {
                valueBefore++;
                _count.text = valueBefore.ToString();
                yield return new WaitForSeconds(0.03f);
            }
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
