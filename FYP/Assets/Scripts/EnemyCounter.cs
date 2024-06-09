using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;
    [SerializeField] private GameObject spawner3;
    [SerializeField] private int enemyCounter = 0;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter >= 100) 
        {
            spawner1.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            enemyCounter++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" == false) 
        {
            gameOver = true;
        }
    }

    public bool GetGameOver() 
    {
        return gameOver;
    }
}
