using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityScript : MonoBehaviour
{

    [SerializeField] private HealthScript healthScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        healthScript.IsInvincible = true;
        yield return new WaitForSeconds(duration);
        healthScript.IsInvincible = false;
    }
}