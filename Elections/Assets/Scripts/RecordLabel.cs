using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordLabel : MonoBehaviour
{
    private static TextMeshProUGUI label;
    private static string text = "¬¿ÿ À”◊ÿ»… –≈«”À‹“¿“ : ";

    private void Awake()
    {
        label = GetComponent<TextMeshProUGUI>();
        label.text = text + 1.ToString();
    }

    private void Start()
    {
        SetText();
    }

    public void SetText()
    {
        int record = InitScene.RecordTurn;
        label.text = text + record.ToString();
    }
}
