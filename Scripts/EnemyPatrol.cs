using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;          // 巡邏點
    public Transform player;                  // 玩家
    public float patrolStopDistance = 1f;     // 接近巡邏點時轉下一點
    public float attackRange = 5f;            // 玩家靠近巡邏點的範圍
    public float playerCatchDistance = 2f;    // 攻擊距離
    public float attackCooldown = 1f;         // 攻擊冷卻時間
    public int attackDamage = 10;             // 攻擊傷害

    private NavMeshAgent agent;
    private int currentPointIndex = 0;
    private bool isChasing = false;
    private float lastAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0 || player == null) return;

        float distanceToCurrentPoint = Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distancePlayerToPatrolPoint = Vector3.Distance(player.position, patrolPoints[currentPointIndex].position);

        // 條件：玩家靠近目前巡邏點才進入追擊
        if (distancePlayerToPatrolPoint < attackRange)
        {
            isChasing = true;
        }
        else if (distanceToPlayer > attackRange * 1.5f)
        {
            // 玩家離太遠，停止追擊，恢復巡邏
            isChasing = false;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }

        if (isChasing)
        {
            agent.SetDestination(player.position);

            if (distanceToPlayer <= playerCatchDistance && Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                AttackPlayer();
            }
        }
        else
        {
            // 正常巡邏
            if (distanceToCurrentPoint < patrolStopDistance)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPointIndex].position);
            }
        }
    }

    void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("敵人攻擊玩家！");
        }
    }
}
