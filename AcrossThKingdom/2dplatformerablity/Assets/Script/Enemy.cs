using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private EnemiesData enemyData;
    EnemyAnimation anim;
    private float currentHealth;
    private bool isDead = false;


    private void Start()
    {
    stats.Initialize(enemyData);
    currentHealth = stats.Health;
    anim = GetComponent<EnemyAnimation>();
    

    }


    public void TakeDamage(float damage)
    {
    if (isDead) return;   // Prevent extra hurt animations after death

    currentHealth -= damage;
    anim.PlayHurt();

    if (currentHealth <= 0)
    {
    Die();
    }
}


    private void Die()
    {
    Destroy(gameObject,.5f);
    isDead = true;
    Debug.Log("[Enemy] Enemy has died.");
    anim.PlayDeath();
    }
}
    

