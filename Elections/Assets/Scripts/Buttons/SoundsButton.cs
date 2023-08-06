using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsButton : MonoBehaviour
{
    private bool state;
    private Animator _animator;

    private void Awake()
    {
        state = true;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!InitScene.Settings.Sound)
            ChangeState();
    }

    public void ChangeState()
    {
        state = !state;
        _animator.SetBool("isSound", state);

        InitScene.Settings.Sound = state;
    
        SoundsController.SwitchSounds(state);
        InitScene.SaveSettings();
    }
}
