using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] public EnemiesData enemyData;
    public AudioClip hitSound;
    public AudioClip deathSound;
    EnemyAnimation anim;
    SoundManager soundManager;
    private float currentHealth;
    private bool isDead = false;


    private void Start()
    {
    stats.Initialize(enemyData);
    currentHealth = stats.Health;
    anim = GetComponent<EnemyAnimation>();
    soundManager = GetComponent<SoundManager>();
    

    }


    public void TakeDamage(float damage)
    {
    if (isDead) return;   // Prevent extra hurt animations after death

    currentHealth -= damage;
    anim.PlayHurt();
    soundManager.PlaySound(hitSound);



    if (currentHealth <= 0)
    {
    Die();
    }
}


    private void Die()
    {
    Destroy(gameObject,.5f);
    isDead = true;
    anim.PlayDeath();
    soundManager.PlaySound(deathSound);
    }
}
    

