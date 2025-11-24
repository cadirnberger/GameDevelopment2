using UnityEngine;

public class Combat : MonoBehaviour, IAttacker
{
    
    HK_Input input;
    Movement movement;
    Animator animator;
    LayerMask enemyLayer;
    PlayerStats stats;
    

    int combo = 0;
    float attackTimer = 0;

    void Awake()
    {
        input = GetComponent<HK_Input>();
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        stats = GetComponent<PlayerStats>();
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (input.Death) animator.SetTrigger("Death");
        if (input.Hurt) animator.SetTrigger("Hurt");

        HandleBlock();
        HandleAttack();
    }

    void HandleBlock()
    {
        if (input.BlockStart) animator.SetBool("IdleBlock", true);
        if (input.BlockEnd) animator.SetBool("IdleBlock", false);
    }

    void HandleAttack()
    {
        if (input.Attack && attackTimer > 0.25f && !movement.Rolling)
        {
            combo = (combo % 3) + 1;
            if (attackTimer > 1f) combo = 1;

            animator.SetTrigger("Attack" + combo);
            attackTimer = 0;
            PerformHitDetection();
            
        }
    }
    public void PerformHitDetection()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, stats.AttackRange, enemyLayer);
        
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent<IDamageable>(out var damage))
            {
                damage.TakeDamage(GetDamage());
            }
        }
        
    }
    public float GetDamage()
    {
        return stats.Attack;
    }
    
}
