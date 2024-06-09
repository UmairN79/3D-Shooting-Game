using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagsCapturedScript : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    [SerializeField] private LevelLoadingScript levelLoadingScript;
    private bool flag1 = false;
    private bool flag2 = false;
    private bool flag3 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag1 == true && flag2 == true && flag3 == true) 
        {
            levelLoader.SetActive(true);
            levelLoadingScript.LoadNextLevel();
        }
    }

    public void Flag1() 
    {
        flag1 = true;
    }
    public void Flag2()
    {
        flag2= true;
    }
    public void Flag3()
    {
        flag3 = true;
    }
}
