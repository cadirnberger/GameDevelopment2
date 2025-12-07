using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform player;
    EnemyCombat combat;
    EnemyStats stats;
    EnemyAnimation anim;
    Rigidbody2D rb;

    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if(player == null)
        {
            Debug.LogError("Player not found! Make sure the player is tagged 'Player'.");
        }

        combat = GetComponent<EnemyCombat>();
        stats = GetComponent<EnemyStats>();
        anim = GetComponent<EnemyAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HandleMovement();
        HandleFacing();
    }

    void HandleMovement()
    {
        if (player == null || stats == null || combat == null)
        {
            Debug.LogError("Missing components in EnemyAI.");
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        // If player is out of attack range but inside detection
        if (distance > stats.AttackRange && distance < stats.DetectionRange)
        {
            Vector2 dir = (player.position - transform.position).normalized;

            // Move enemy
            rb.linearVelocity = new Vector2(dir.x * stats.Speed, rb.linearVelocity.y);

            // PLAY MOVEMENT ANIMATION
            anim.SetMoving(true);
        }
        else
        {
            // Stop moving when attacking or idle
            rb.linearVelocity = new Vector2(0, 0);
            anim.SetMoving(false);

            if (distance <= stats.AttackRange)
            {

                // Apply hit logic
                combat.PerformHitDetection();
            }
        }
    }
    void HandleFacing()
    {
        if (player == null) return;

        float horizontal = player.position.x - transform.position.x;
        int facingDirection;
        if (horizontal > 0) facingDirection = 1;
        else if (horizontal < 0) facingDirection = -1;
        else facingDirection = 1;

        GetComponent<SpriteRenderer>().flipX = facingDirection == -1;
    }
}
