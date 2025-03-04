using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float detectionRange = 10f; // Range within which the enemy detects the player
    public float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    public float wanderSpeed = 1f; // Speed at which the enemy wanders
    public float wanderRadius = 5f; // Radius within which the enemy wanders
    public float wanderInterval = 2f; // Time interval between changing wander direction

    private Transform player;
    private Vector3 wanderTarget;
    private float wanderTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Ensure the player GameObject has the tag 'Player'.");
        }

        wanderTimer = wanderInterval;
        SetNewWanderTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Wander();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void Wander()
    {
        wanderTimer -= Time.deltaTime;
        if (wanderTimer <= 0)
        {
            SetNewWanderTarget();
            wanderTimer = wanderInterval;
        }

        Vector3 direction = (wanderTarget - transform.position).normalized;
        transform.position += direction * wanderSpeed * Time.deltaTime;
    }

    void SetNewWanderTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        randomDirection.y = transform.position.y; // Keep the enemy on the same height level
        wanderTarget = randomDirection;
    }
}
