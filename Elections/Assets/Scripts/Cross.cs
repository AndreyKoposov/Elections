using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cross : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        Off();
    }

    public void On()
    {
        image.gameObject.SetActive(true);
    }

    public void Off()
    {
        image.gameObject.SetActive(false);
    }
}
