using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingScript : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    [SerializeField] private LevelLoadingScript levelLoadingScript;
    [SerializeField] private int rayDistance;
    [SerializeField] private Camera cam;
    [SerializeField] private DoorScript doorScript;
    [SerializeField] private GunScript gunScript;
    [SerializeField] private GunShotgunScript gunShotgunScript;
    [SerializeField] private GunPistolScript gunPistolScript;
    [SerializeField] private HealthScript health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject.tag == "Key1" && Input.GetKeyDown(KeyCode.E))
            {
                doorScript.ActivateDoor1();
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.tag == "Key2" && Input.GetKeyDown(KeyCode.E))
            {
                doorScript.ActivateDoor2();
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.tag == "Key3" && Input.GetKeyDown(KeyCode.E))
            {
                doorScript.ActivateDoor3();
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.tag == "Ammo" && Input.GetKeyDown(KeyCode.E))
            {
                gunScript.GetAssaultAmmo();
                gunShotgunScript.GetShotgunAmmo();
                gunPistolScript.GetPistolAmmo();
            }
            if (hit.collider.gameObject.tag == "MedPack" && Input.GetKeyDown(KeyCode.E))
            {
                health.FullHealth();
            }
            if (hit.collider.gameObject.tag == "EndDoor" && Input.GetKeyDown(KeyCode.E))
            {
                levelLoader.SetActive(true);
                levelLoadingScript.LoadNextLevel();
            }
        }
    }
}
