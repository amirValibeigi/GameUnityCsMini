using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    [SerializeField] private float minTimeCamp = 5f;
    [SerializeField] private float maxTimeCamp = 15f;
    private NavMeshAgent agent = null;
    private Animator animator;
    private Transform targetPlayer;
    private Transform targetCamp;
    private EnemyCamp enemyCamp;
    private float nextTimeCamp = -1;

    private BotWeaponShooting botWeaponShooting;

    private void Start()
    {
        getReferences();
        initVarables();
    }

    private void FixedUpdate()
    {
        moveToRandomCamp();
    }


    private void moveToRandomCamp()
    {
        if (isNearTarget(5f))
        {
            moveToTarget(targetPlayer);
            botWeaponShooting.shoot();
            return;
        }

        moveToTarget(targetCamp);
        setNextCamp();
    }

    private void moveToTarget(Transform target)
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);

        rotateToTarget(target);

        if (isNearTarget(target))
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void rotateToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = rotation;
    }


    public bool isNearTarget()
    {
        return isNearTarget(targetPlayer, agent.stoppingDistance);
    }

    public bool isNearTarget(float stoppingDistance)
    {
        return isNearTarget(targetPlayer, stoppingDistance);
    }

    public bool isNearTarget(Transform target)
    {
        return isNearTarget(target, agent.stoppingDistance);
    }

    public bool isNearTarget(Transform target, float stoppingDistance)
    {
        if (target == null)
            return false;


        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        return distanceToTarget <= stoppingDistance;
    }

    private void setNextCamp()
    {
        if (isNearTarget() || !isNearTarget(targetCamp) || !isNextTimeCamp())
            return;

        nextTimeCamp = -1;
        targetCamp = enemyCamp.getCamp();
    }


    public bool isNextTimeCamp()
    {
        if (nextTimeCamp == -1)
        {
            nextTimeCamp = Time.time + Random.Range(minTimeCamp, maxTimeCamp);

            return false;
        }

        return nextTimeCamp <= Time.time;
    }

    private void getReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        targetPlayer = PlayerMovement.instance.transform;
        enemyCamp = FindObjectOfType<EnemyCamp>();
        botWeaponShooting = GetComponent<BotWeaponShooting>();
    }

    private void initVarables()
    {
        targetCamp = enemyCamp.getCamp();
    }
}
