using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] float chaseRange = 20f;
    [SerializeField] bool debugMode = true;

    private NavMeshAgent navMeshAgent;
    private float distanceToTarget;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        distanceToTarget = Mathf.Infinity;
    }

    private void Update()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (chaseRange < distanceToTarget)
        {
            Debug.DrawLine(transform.position, target.position, Color.yellow);
        }
        else
        {
            navMeshAgent.SetDestination(target.position);

            if (debugMode)
            {
                Debug.DrawLine(transform.position, target.position, Color.red);
            }
        }
    }
}