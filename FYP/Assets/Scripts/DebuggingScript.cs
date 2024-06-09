using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebuggingScript : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    [SerializeField] private LevelLoadingScript levelLoadingScript;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) 
        {
            timer = timer - Time.deltaTime;
            timerText.text = timer.ToString();
        }
        if (timer <= 0) 
        {
            timer = 0;
            timerText.text = timer.ToString();
            levelLoader.SetActive(true);
            levelLoadingScript.LoadNextLevel();
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("WORKING????");
    }*/
}
