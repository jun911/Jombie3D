using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField][Range(0, 10)] private float speed = 1f;
    [SerializeField][Range(0, 10)] private float returnSpeed = 0.5f;
    [SerializeField][Range(0, 50)] private float chaseRange = 20f;
    [SerializeField] private bool debugMode = true;

    private NavMeshAgent navMeshAgent;
    private Vector3 startPosition;
    private STATE_ENEMY stateEnemy;
    private float distanceToTarget;

    private enum STATE_ENEMY
    {
        PEACE,
        ENGAGE
        //PROVOKE
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    private void Update()
    {
        EnemyProcessing();
    }

    private void EnemyProcessing()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        // distance check
        stateEnemy = (distanceToTarget <= chaseRange) ? STATE_ENEMY.ENGAGE : STATE_ENEMY.PEACE;

        switch (stateEnemy)
        {
            case STATE_ENEMY.PEACE:
                MoveToStart();
                break;

            case STATE_ENEMY.ENGAGE:
                EngageTarget();
                break;

            default:
                break;
        }
    }

    private void MoveToStart()
    {
        navMeshAgent.speed = returnSpeed;
        navMeshAgent.SetDestination(startPosition);
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.speed = speed;
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log($"{name} has seeked and is destroying {target.name}");
    }

    private void OnDrawGizmosSelected()
    {
        if (debugMode)
        {
            Color color;

            switch (stateEnemy)
            {
                case STATE_ENEMY.ENGAGE:
                    color = Color.red;
                    break;

                default:
                    color = Color.yellow;
                    break;
            }

            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
            Debug.DrawLine(transform.position, target.position, color);
        }
    }
}