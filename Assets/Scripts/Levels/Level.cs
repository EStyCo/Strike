using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    protected bool isFinished = false;
    protected Animator animator;
    
    public abstract void Enter(Animator _animator);
    public abstract void Exit();
}
