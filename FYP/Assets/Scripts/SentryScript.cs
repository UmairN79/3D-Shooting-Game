using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryScript : MonoBehaviour
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
    private GameObject enemy;
    [SerializeField] private ParticleSystem ps;
    //[SerializeField] private Animator animator;

    private float nextFire = 0f;
    private bool isReloading = false;
    [SerializeField] private bool canFire;
    [SerializeField] private bool hasTarget = false;
    private float healthMark = 0;
    // Start is called before the first frame update
    void Start()
    {
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

        if (healthMark <= 0) 
        {
            hasTarget = false;
            OffFire();
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
        //LookAtTarget();
        RaycastHit hit;
        Debug.DrawRay(weapTransform.transform.position, weapTransform.transform.forward * range, Color.green);
        if (Physics.Raycast(weapTransform.transform.position, weapTransform.transform.forward, out hit, range))
        {

            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if (target != null)
            {
                target.TakeDamage(damage);
                healthMark = target.GetHealth();
                Debug.Log("WE FIREEEEEEEEE");
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

    private void OnTriggerStay(Collider other)
    {
        if (hasTarget == true)
        {
            return;
        }
        /*if (other.gameObject.tag == "Enemy")
        {
            SetFire();
        }*/
        if (hasTarget == false && other.gameObject.tag == "Enemy")
        {
            hasTarget = true;
            enemy = other.gameObject;
            SetFire();
        }
    }
    private void LookAtTarget()
    {
        Vector3 pos = enemy.transform.position - transform.position;
        pos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(-90, 90, rotation.z, rotation.w), 0.5f);
    }
}
