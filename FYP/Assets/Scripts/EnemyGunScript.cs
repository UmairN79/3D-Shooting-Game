using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : MonoBehaviour
{

    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private int maxAmmo = 100;
    [SerializeField] private GameObject weapTransform;
    [SerializeField] private AudioSource audio;
    private int currentAmmo;
    [SerializeField] private float reloadTime = 1f;
    //[SerializeField] private Camera cam;
    EnemyMovementScript enemyMov;
    [SerializeField] private ParticleSystem ps;
    //[SerializeField] private Animator animator;

    private float nextFire = 0f;
    private bool isReloading = false;
    private bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        //enemyMov = GetComponent<EnemyMovementScript>();
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        //animator.SetBool("Reloading", false);
    }
    // Update is called once per frame
    void Update()
    {   
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (canFire == true && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        //animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        //animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public void Shoot()
    {
        ps.Play();
        currentAmmo--;
        audio.time = 0.2f;
        audio.volume = 0.01f;
        audio.Play();
        RaycastHit hit;
        //Debug.DrawRay(transform.position, weapTransform.transform.forward * 10, Color.green);
        if (Physics.Raycast(transform.position,weapTransform.transform.forward, out hit, range))
        {
            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    public void SetFire() 
    {
        canFire = true;
    }

    public void OffFire() 
    {
        canFire = false;
    }
}
