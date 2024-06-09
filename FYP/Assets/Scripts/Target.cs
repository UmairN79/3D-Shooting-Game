using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private float health = 50f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Falling()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 45);
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void TakeDamage(float amount) 
    {
        health -= amount;
        if (health <= 0f) 
        {
            Die();
        }
    }
    public void Die() 
    {
        Destroy(gameObject);
    }
}
