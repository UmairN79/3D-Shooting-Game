using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{

    //[SerializeField] private RaycastingScript raycasting;
    [SerializeField] private float currentHealth;
    //[SerializeField] private float maskHealth;
    [SerializeField] private float maxHealth;
    private bool checkMask;
    private float checkMaskHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent Death;
    public UnityEvent OnDamage;

    public void TakeDamage(float damage)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }
        //checkMask = raycasting.IsWearingMask();
        /*if (checkMask == true)
        {
            TakeDamageMask(damage);
            return;
        }*/

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth == 0)
        {
            Death.Invoke();
        }
        else
        {
            OnDamage.Invoke();
        }
    }

    /*public void TakeDamageMask(float damage)
    {
        if (maskHealth == 0)
        {
            TakeDamage(damage);
        }

        if (IsInvincible)
        {
            return;
        }

        maskHealth -= damage;

        if (maskHealth < 0)
        {
            maskHealth = 0;
        }
        if (maskHealth == 0)
        {
            Death.Invoke();
        }
        else
        {
            OnDamage.Invoke();
        }
    }*/

    public void AddHealth(float amount)
    {
        if (currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void FullHealth()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    /*public void GiveHealth()
    {
        maskHealth = 100;
    }*/
}
