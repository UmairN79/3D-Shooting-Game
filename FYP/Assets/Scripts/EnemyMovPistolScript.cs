using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovPistolScript : MonoBehaviour
{
    [SerializeField] private GameObject weap;
    [SerializeField] private GameObject targetweap;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;
    [SerializeField] private EnemyPistolScript enemyGun;
    [SerializeField] private bool mapOne = false;
    [SerializeField] private Transform[] transforms;
    [SerializeField] private NavMeshAgent nav;
    private int barricadeSelect = 0;
    private bool canFire = false;
    private float shootingDistance;
    private Coroutine death;
    // Start is called before the first frame update
    void Start()
    {
        if (mapOne == true)
        {
            transforms[0] = GameObject.FindGameObjectWithTag("Barricade1").GetComponent<Transform>();
            transforms[1] = GameObject.FindGameObjectWithTag("Barricade2").GetComponent<Transform>();
            transforms[2] = GameObject.FindGameObjectWithTag("Barricade3").GetComponent<Transform>();
            transforms[3] = GameObject.FindGameObjectWithTag("Barricade4").GetComponent<Transform>();
            transforms[4] = GameObject.FindGameObjectWithTag("Barricade5").GetComponent<Transform>();
            barricadeSelect = Random.Range(0, transforms.Length);
            target = transforms[barricadeSelect];
            nav.stoppingDistance = 7;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shootingDistance = agent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;
            if (inRange == true)
            {
                LookAtTarget();
                animator.SetBool("IsFiring", true);
                enemyGun.SetFire();
                //animator.SetBool("IsMoving", false);
                weap.SetActive(true);
                targetweap.SetActive(false);
            }
            else
            {
                UpdatePath();
                animator.SetBool("IsFiring", false);
                animator.SetBool("IsMoving", true);
                enemyGun.OffFire();
                weap.SetActive(false);
                targetweap.SetActive(true);
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 pos = player.position - transform.position;
        pos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    {
        agent.SetDestination(target.position);
    }

    public bool CanFire()
    {
        return canFire;
    }

    public void HasDied()
    {
        death = StartCoroutine(Died());
    }

    private IEnumerator Died()
    {
        animator.SetBool("IsFiring", false);
        animator.SetBool("IsMoving", false);
        animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void MapOneActivate()
    {
        mapOne = true;
    }
}
