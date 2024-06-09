using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunPistolScript : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int ammoClip;
    private int currentAmmo;
    private int maxAmmoClip;
    [SerializeField] private float reloadTime;
    [SerializeField] private Camera cam;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audio;
    [SerializeField] private TextMeshProUGUI ammo;
    [SerializeField] private TextMeshProUGUI currentAmmoUI;
    //[SerializeField] private AudioSource audio;
    private float nextFire = 0f;
    private bool isReloading = false;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        maxAmmoClip = ammoClip;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    // Update is called once per frame
    void Update()
    {
        ammo.text = ammoClip.ToString();
        currentAmmoUI.text = "/" + currentAmmo.ToString();
        if (isReloading)
        {
            return;
        }

        if ((ammoClip <= 0 && currentAmmo > 0) || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextFire && ammoClip > 0)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        if (currentAmmo + ammoClip >= maxAmmoClip)
        {
            int temp = maxAmmoClip - ammoClip;
            ammoClip = maxAmmoClip;
            currentAmmo -= temp;
        }
        else if (currentAmmo > 0)
        {
            ammoClip = ammoClip + currentAmmo;
            currentAmmo = 0;
        }
        isReloading = false;
    }

    private void Shoot()
    {
        ps.Play();
        ammoClip--;
        audio.volume = 0.1f;
        audio.Play();
        RaycastHit hit;
        //Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Target target = hit.transform.GetComponent<Target>();
            HealthScript health = hit.transform.GetComponent<HealthScript>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
    public void GetPistolAmmo()
    {
        currentAmmo = maxAmmo;
    }
}
