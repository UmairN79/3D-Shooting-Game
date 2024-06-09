using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountingScript : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    [SerializeField] private LevelLoadingScript levelLoadingScript;
    [SerializeField] private float waitingTime;
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;
    [SerializeField] private GameObject spawner3;
    [SerializeField] private int enemyNumber = 0;
    private int level1Active = 0;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNumber >= 100) 
        {
            spawner1.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
        }
        if (gameOver == true) 
        {
            level1Active = 1;
            PlayerPrefs.SetInt("Level1", level1Active);
            levelLoader.SetActive(true);
            StartCoroutine(Waiting());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyNumber++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (enemyNumber >= 100) 
        {
            if (other.gameObject.tag == "Enemy" == false)
            {
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    IEnumerator Waiting() 
    {
        yield return new WaitForSeconds(waitingTime);
        levelLoadingScript.LoadNextLevel();
    }
}
