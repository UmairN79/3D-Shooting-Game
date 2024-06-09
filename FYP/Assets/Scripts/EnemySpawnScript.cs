using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    [SerializeField] private GameObject[] enemy;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private bool mapOne = false;
    private float timeUntilSpawn;
    private int enemySelected;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0) 
        {
            enemySelected = Random.Range(0, enemy.Length);
            GameObject en = Instantiate(enemy[enemySelected], transform.position, Quaternion.identity);
            if (mapOne == true) 
            {
                if (enemySelected == 0)
                {
                    en.GetComponent<EnemyMovementScript>().MapOneActivate();
                }
                else if (enemySelected == 1)
                {
                    en.GetComponent<EnemyMovPistolScript>().MapOneActivate();
                }
                else if (enemySelected == 2) 
                {
                    en.GetComponent<EnemyMovShotgunScript>().MapOneActivate();
                }
            }
            SpawnTime();
        }
    }

    private void SpawnTime() 
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
