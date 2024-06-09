using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingScript : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private float transitionTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) 
        {
            LoadNextLevel();
        }*/
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        if (levelIndex >= 4)
        {
            SceneManager.LoadScene(0);
        }
        else 
        {
            SceneManager.LoadScene(levelIndex);
        }
    }

    public void LoadLevel1() 
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadLevel2()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void LoadLevel3()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void LoadLevel4()
    {
        StartCoroutine(LoadLevel(4));
    }
}
