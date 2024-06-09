using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageInvincibilityScript : MonoBehaviour
{

    [SerializeField] private float invincibilityDuration;
    [SerializeField] private InvincibilityScript invincibilityScript;
    // Start is called before the first frame update
    void Start()
    {
        //invincibilityScript = GetComponent<InvincibilityScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartInvincibility()
    {
        invincibilityScript.StartInvincibility(invincibilityDuration);
    }
}
