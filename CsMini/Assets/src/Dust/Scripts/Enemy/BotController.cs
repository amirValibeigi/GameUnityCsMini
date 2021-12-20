using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator animator;
    private Transform targetPlayer;
    private Transform targetCamp;
    private EnemyCamp enemyCamp;

    private void Start()
    {
        getReferences();
        initVarables();
    }

    private void Update()
    {
        moveToRandomCamp();
    }


    private void moveToRandomCamp()
    {
        if (isNearTarget(5f))
        {
            moveToTarget(targetPlayer);
            return;
        }

        moveToTarget(targetCamp);
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


    private bool isNearTarget()
    {
        return isNearTarget(targetPlayer, agent.stoppingDistance);
    }

    private bool isNearTarget(float stoppingDistance)
    {
        return isNearTarget(targetPlayer, stoppingDistance);
    }

    private bool isNearTarget(Transform target)
    {
        return isNearTarget(target, agent.stoppingDistance);
    }

    private bool isNearTarget(Transform target, float stoppingDistance)
    {
        float distanceToTarget = Vector3.Distance(target.position, transform.position);

        return distanceToTarget <= stoppingDistance;
    }

    private void getReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        targetPlayer = PlayerMovement.instance.transform;
        enemyCamp = FindObjectOfType<EnemyCamp>();
    }

    private void initVarables()
    {
        targetCamp = enemyCamp.getCamp();
        Debug.Log(targetCamp.position);
    }
}
