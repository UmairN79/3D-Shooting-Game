using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgunScript : MonoBehaviour
{

    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 15f;
    [SerializeField] private int maxAmmo = 110;
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
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit hit4;
        //Debug.DrawRay(weapTransform.transform.position, weapTransform.transform.forward * 10, Color.red);
        //Debug.DrawRay(weapTransform.transform.position, weapTransform.transform.forward + new Vector3(-0.5f, 0f, 0f), Color.blue);
        //Debug.DrawRay(weapTransform.transform.position, weapTransform.transform.forward + new Vector3(0.5f, 0f, 0f), Color.green);
        if (Physics.Raycast(transform.position, weapTransform.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Target target = hit.transform.GetComponent<Target>();
            HealthScript health = hit.transform.GetComponent<HealthScript>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        if (Physics.Raycast(transform.position, weapTransform.transform.forward, out hit2, range))
        {
            //Target target = hit.transform.GetComponent<Target>();
            HealthScript health = hit2.transform.GetComponent<HealthScript>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        if (Physics.Raycast(transform.position, weapTransform.transform.forward + new Vector3(-0.5f, 0f, 0f), out hit3, range))
        {
            //Target target = hit.transform.GetComponent<Target>();
            HealthScript health = hit3.transform.GetComponent<HealthScript>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        if (Physics.Raycast(transform.position, weapTransform.transform.forward + new Vector3(0.5f, 0f, 0f), out hit4, range))
        {
            //Target target = hit.transform.GetComponent<Target>();
            HealthScript health = hit4.transform.GetComponent<HealthScript>();
            if (health != null)
            {
                health.TakeDamage(damage);
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

    public void SetAudio(AudioSource audioSource)
    {
        audio = audioSource;
    }
}
