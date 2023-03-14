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
    [SerializeField] private STATE_ENEMY stateEnemy;
    private float distanceToTarget;
    Animator animator;

    private enum STATE_ENEMY
    {
        IDLE,
        MOVE,
        ATTACK,
        RETURN
        //PROVOKE
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        EnemyProcessing();
    }

    private void EnemyProcessing()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        // distance check
        if (distanceToTarget > chaseRange)
        {
            //if(transform.position == startPosition)
            //{
                stateEnemy = STATE_ENEMY.IDLE;
            //}
            //else
            //{
            //    stateEnemy = STATE_ENEMY.RETURN;
            //}
        }
        else
        {
            if (distanceToTarget >= navMeshAgent.stoppingDistance)
            {
                stateEnemy = STATE_ENEMY.MOVE;
            }
            else
            {
                stateEnemy = STATE_ENEMY.ATTACK;
            }
        }


        switch (stateEnemy)
        {
            case STATE_ENEMY.IDLE:
                animator.SetTrigger("Idle");
                break;

            case STATE_ENEMY.RETURN:
                MoveToStart();
                break;

            case STATE_ENEMY.MOVE:
                animator.SetBool("Attack", false);
                animator.SetTrigger("Move");
                MoveToTarget();
                break;

            case STATE_ENEMY.ATTACK:
                animator.SetBool("Attack", true);
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

    private void MoveToTarget()
    {
        Debug.Log("move To Target");
        navMeshAgent.speed = speed;
        navMeshAgent.SetDestination(target.position);
    }

    private void EngageTarget()
    {
        AttackTarget();
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
                case STATE_ENEMY.MOVE:
                    color = Color.green;
                    break;

                case STATE_ENEMY.ATTACK:
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