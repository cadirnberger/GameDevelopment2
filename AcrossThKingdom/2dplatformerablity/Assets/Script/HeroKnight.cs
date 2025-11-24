using UnityEngine;

public class HeroKnight : MonoBehaviour, IDamageable
{
    private PlayerStats playerStats;
    public SpriteRenderer spriteRenderer;
    HK_Animation animationController;
    private float currentHealth;
    private bool isDead = false;
    public PlayerUIManager uiManager;
    public HealthBar healthBar;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        spriteRenderer.color = SelectedClass.playerClass.classColor;
        currentHealth = playerStats.Health;
        animationController = GetComponent<HK_Animation>();
        healthBar.SetMaxHealth(currentHealth);
        uiManager.ShowHealthUI();
        
    }
    
    public void TakeDamage(float damage)
    {
    if (isDead) return;

    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    animationController.HandleHurt();

    if (currentHealth <= 0)
    {
        Die();
    }
    }

private void Die()
{
    isDead = true;
    uiManager.ShowDeathUI();
}

}
