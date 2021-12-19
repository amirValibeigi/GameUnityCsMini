using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator animator;
    [SerializeField] private Transform target;

    private void Start()
    {
        getReferences();
    }

    private void Update()
    {
        moveToTarget();
    }

    private void moveToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);

        rotateToTarget();

        if (agent.isStopped)
        {
            animator.SetFloat("Speed", 0f);
        }

    }

    private void rotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void getReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

}
