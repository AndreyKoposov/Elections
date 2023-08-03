using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLeanTween : MonoBehaviour
{
    private void Awake()
    {
        LeanTween.init(800);
    }
}
