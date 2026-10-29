using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public Transform player;
    public float detectionRange = 10f;

    public float attackDamage = 10f;

    private PlayerHealth playerHealth;

    public float attackRange = 2f;
    public float attackCooldown = 2f;

    private float lastAttackTime;

    private NavMeshAgent agent;
    private Animator animator;
    private Transform currentPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();

        currentPoint = patrolPoint1;
        agent.SetDestination(currentPoint.position);
    }



    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // ATTACK
        if (distanceToPlayer <= attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("isMoving", false);

            // Face the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            // Attack every 2 seconds
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time;
            }
        }

        // CHASE
        else if (distanceToPlayer <= detectionRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            animator.SetBool("isMoving", agent.velocity.magnitude > 0.1f);
        }

        // PATROL
        else
        {
            agent.isStopped = false;

            if (!agent.pathPending &&
                agent.remainingDistance <= agent.stoppingDistance)
            {
                if (currentPoint == patrolPoint1)
                {
                    currentPoint = patrolPoint2;
                }
                else
                {
                    currentPoint = patrolPoint1;
                }

                agent.SetDestination(currentPoint.position);
            }

            animator.SetBool("isMoving", agent.velocity.magnitude > 0.1f);
        }
    }
        public void DealDamage()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
