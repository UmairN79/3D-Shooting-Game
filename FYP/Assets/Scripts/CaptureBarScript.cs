using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureBarScript : MonoBehaviour
{

    [SerializeField] private UnityEngine.UI.Image foregroundOne;
    [SerializeField] private CaptureScript captureScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCaptureBar() 
    {
        foregroundOne.fillAmount = captureScript.RemainingBar();
    }
}
