using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] Rigidbody door1;
    [SerializeField] Rigidbody door2;
    [SerializeField] Rigidbody door3;
    private bool key1 = false;
    private bool key2 = false;
    private bool key3 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (key1 == true) 
        {
            door1.isKinematic = false;
        }
        if (key2 == true)
        {
            door2.isKinematic = false;
        }
        if (key3 == true)
        {
            door3.isKinematic = false;
        }
    }

    public void ActivateDoor1() 
    {
        key1 = true;
    }
    public void ActivateDoor2()
    {
        key2 = true;
    }
    public void ActivateDoor3()
    {
        key3 = true;
    }
}
