using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandlerScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu() 
    {
        animator.Play("AlphaControlClip");
    }
}
