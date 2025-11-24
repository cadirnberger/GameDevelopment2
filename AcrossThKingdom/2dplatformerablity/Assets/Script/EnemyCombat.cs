using UnityEngine;

public class EnemyCombat : MonoBehaviour, IAttacker
{
    EnemyStats stats;  
    LayerMask playerLayer;
    EnemyAnimation anim;

    [SerializeField] private float attackCooldown = 1f;
    private float lastAttackTime = -999f;  // enemy can attack immediately

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        playerLayer = LayerMask.GetMask("Player");
        anim = GetComponent<EnemyAnimation>();
    }

    public float GetDamage()
    {
        return stats.Attack;
    }

    public void PerformHitDetection()
    {
        // --- COOLDOWN CHECK ---
        if (Time.time < lastAttackTime + attackCooldown)
            return; // still cooling down, don't attack

        // Try to hit the player
        Collider2D hit = Physics2D.OverlapCircle(transform.position, stats.AttackRange, playerLayer);

        if (hit != null)
        {
            IDamageable damageable =
                hit.GetComponent<IDamageable>() ??
                hit.GetComponentInParent<IDamageable>() ??
                hit.GetComponentInChildren<IDamageable>();

            damageable?.TakeDamage(GetDamage());
            anim.PlayAttack();

            // Reset cooldown
            lastAttackTime = Time.time;
        }
    }
}
