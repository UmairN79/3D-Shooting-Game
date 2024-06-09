using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{

    //[SerializeField] private
    [SerializeField] private Button button;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;
    private int buttonActive = 0;
    private int button2Active = 0;
    private int button3Active = 0;
    private int button4Active = 0;
    // Start is called before the first frame update
    void Start()
    {
        buttonActive = PlayerPrefs.GetInt("Level1");
        button2Active = PlayerPrefs.GetInt("Level2");
        button3Active = PlayerPrefs.GetInt("Level3");
        button4Active = PlayerPrefs.GetInt("Level4");
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonActive == 1) 
        {
            button.interactable = true;
        }
        if (button2Active == 1)
        {
            button2.interactable = true;
        }
        if (button3Active == 1)
        {
            button3.interactable = true;
        }
        if (button4Active == 1)
        {
            button4.interactable = true;
        }
    }
}
