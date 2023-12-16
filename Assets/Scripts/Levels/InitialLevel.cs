using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InitialLevel : Level
{
    [Inject] private LevelManager lm;
    [SerializeField] private bool isCancel = false;
    public override void Enter(Animator _animator)
    {
        animator = _animator;
        animator.Play("InitialEnter");
    }

    public override void Exit()
    {
        animator.Play("InitialExit");
    }

    public void SwitchAnim()
    {
        if (isCancel)
        {
            Exit();
        }
    }

    public void LoadNextLevel()
    {
        lm.Load2Level();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isCancel = true;
        }
    }

    private IEnumerator CycleAnim()
    {
        yield return null;
    }

}
