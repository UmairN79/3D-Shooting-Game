using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMovement : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform player;
    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;
    private bool mouseLock = false;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1) 
        {
            mouseLock = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }

    public void EnableMouseLock() 
    {
        mouseLock = true;
    }

    public void DisableMouseLock() 
    {
        mouseLock = false;
    }
}
