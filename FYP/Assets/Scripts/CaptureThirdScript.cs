using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureThirdScript : MonoBehaviour
{
    [SerializeField] private float currentLife = 0;
    [SerializeField] private float maxLife = 0;
    [SerializeField] private bool capturedThree = false;
    [SerializeField] private GameObject captureBar;
    [SerializeField] private UnityEngine.UI.Image ForegroundOne;
    [SerializeField] private float RemainingLife;
    [SerializeField] private FlagsCapturedScript flag;
    [SerializeField] private GameObject spawner1;
    [SerializeField] private GameObject spawner2;
    [SerializeField] private GameObject spawner3;
    [SerializeField] private FlagsCapturedScript flags;
    private PlayerMovementScript mov;
    private bool working = false;
    private bool completed1 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RemainingLife = currentLife / maxLife;
        if (mov != null)
        {
            working = true;
        }
        else
        {
            working = false;
            if (currentLife > 0 && completed1 == false)
            {
                currentLife -= Time.deltaTime;
                ForegroundOne.fillAmount = RemainingLife;
            }
        }

        if (currentLife <= 0)
        {
            captureBar.SetActive(false);
        }

        if (capturedThree == true)
        {
            flags.Flag3();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        mov = other.transform.GetComponent<PlayerMovementScript>();
        if (currentLife >= 100)
        {
            captureBar.SetActive(false);
            capturedThree = true;
            completed1 = true;
            flag.Flag3();
            spawner1.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
        }
        else if (working == true)
        {
            captureBar.SetActive(true);
            currentLife += Time.deltaTime;
            ForegroundOne.fillAmount = RemainingLife;
            spawner1.SetActive(true);
            spawner2.SetActive(true);
            spawner3.SetActive(true);
        }
    }

    public float RemainingBar()
    {
        return RemainingLife;
    }

    private void OnTriggerExit(Collider other)
    {
        mov = null;
    }
}
