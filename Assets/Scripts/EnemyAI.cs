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
    private float distanceToTarget = Mathf.Infinity;
    private Vector3 startPosition;
    private STATE_ENEMY_MOVE stateEnemyMove;

    private enum STATE_ENEMY_MOVE
    {
        FOLLOW,
        RETURN
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    private void Update()
    {
        SetDestination();
        MoveEnemy();
    }

    private void OnDrawGizmosSelected()
    {
        Color color;

        switch (stateEnemyMove)
        {
            case STATE_ENEMY_MOVE.FOLLOW:
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

    private void SetDestination()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        stateEnemyMove = (distanceToTarget <= chaseRange) ? STATE_ENEMY_MOVE.FOLLOW : STATE_ENEMY_MOVE.RETURN;
    }

    private void MoveEnemy()
    {
        switch (stateEnemyMove)
        {
            case STATE_ENEMY_MOVE.FOLLOW:
                navMeshAgent.speed = speed;
                navMeshAgent.SetDestination(target.position);
                break;

            case STATE_ENEMY_MOVE.RETURN:
                navMeshAgent.speed = returnSpeed;
                navMeshAgent.SetDestination(startPosition);
                break;
        }
    }
}