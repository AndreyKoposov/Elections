using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceContainer : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private ResTypes _type;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private AudioSource _countSound;
    [SerializeField] private Image greenArrow;
    [SerializeField] private Image redArrow;

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
                _countSound.Play();
                _count.text = valueBefore.ToString();
                yield return new WaitForSeconds(0.03f);
            }
        }
        else
        {
            while (valueBefore < valueNow)
            {
                valueBefore++;
                _countSound.Play();
                _count.text = valueBefore.ToString();
                yield return new WaitForSeconds(0.03f);
            }
        }
        SetCountColor();
    }

    private void SetCountColor()
    {
        if (_value <= 25)
        {
            _count.color = Color.red;
            return;
        }
        if (_value >= 75)
        {
            _count.color = Color.green;
            return;
        }
        _count.color = Color.white;
    }

    public ResTypes Type
    {
        get { return _type; }
    }

    public static int CompareResource(ResourceContainer x, ResourceContainer y)
    {
        return x.Value.CompareTo(y.Value);
    }

    public void SetGreenArrow()
    {
        greenArrow.gameObject.SetActive(true);
    }

    public void SetRedArrow()
    {
        redArrow.gameObject.SetActive(true);
    }

    public void ResetArrows()
    {
        greenArrow.gameObject.SetActive(false);
        redArrow.gameObject.SetActive(false); ;
    }
}
