using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InitialLevel initialLevel;

    [Header("Current Level")] 
    public Level currentLevel;
    
    void Start()
    {
        currentLevel = initialLevel;
        currentLevel.Enter(animator);
        
        
    }

    public void Load2Level()
    {
        animator.Play("Shape");
    }

}
