using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUIScript : MonoBehaviour
{
    [SerializeField] private HealthScript health;
    [SerializeField] private TextMeshProUGUI healthUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = health.GetHealth().ToString();
    }
}
