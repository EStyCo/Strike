using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSwitcher : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void AttackToogle()
    {
        _animator.SetBool("attack", false);
    }
}
