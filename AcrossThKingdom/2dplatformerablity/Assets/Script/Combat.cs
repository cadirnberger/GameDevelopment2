using UnityEngine;

public class Combat : MonoBehaviour, IAttacker
{
    
    HK_Input input;
    Movement movement;
    HK_Animation animator;
    HeroKnight heroKnight;
    LayerMask enemyLayer;
    PlayerStats stats;
    SoundManager soundManager;
    public AudioClip attackSound;
    int combo = 0;
    float attackTimer = 0;

    void Awake()
    {
        input = GetComponent<HK_Input>();
        movement = GetComponent<Movement>();
        animator = GetComponent<HK_Animation>();
        stats = GetComponent<PlayerStats>();
        soundManager = GetComponent<SoundManager>();
        heroKnight = GetComponent<HeroKnight>();
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    void Update()
    {

        attackTimer += Time.deltaTime;
        if (heroKnight.isDead) return;

        HandleAttack();
    }

    

    void HandleAttack()
    {

    if (input.Attack && attackTimer > 0.25f && !movement.Rolling)
    {
        // Increase combo
        combo = (combo % 3) + 1;

        // Reset combo if too slow
        if (attackTimer > 1f)
            combo = 1;

        animator.HandleAttack(combo);
        soundManager.PlaySound(attackSound);
        PerformHitDetection();
        attackTimer = 0f;
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
