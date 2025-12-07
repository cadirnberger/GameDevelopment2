using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour, IDamageable
{
    private PlayerStats playerStats;
    private PlayerClassData classData;
    SoundManager soundManager;
    public SpriteRenderer spriteRenderer;
    HK_Animation animationController;
    private float currentHealth;
    public bool isDead = false;
    public PlayerUIManager uiManager;
    public HealthBar healthBar;
    public AudioClip hitSound;
    public AudioClip deathSound;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        classData = SelectedClass.playerClass;
        spriteRenderer.color = classData.classColor;
        currentHealth = playerStats.Health;
        animationController = GetComponent<HK_Animation>();
        healthBar.SetMaxHealth(currentHealth);
        uiManager.ShowHealthUI();
        soundManager = GetComponent<SoundManager>();
        
    }
    
    public void TakeDamage(float damage)
    {
    if (isDead) return;

    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    animationController.HandleHurt();
    soundManager.PlaySound(hitSound);



    if (currentHealth <= 0)
    {
        Die();
    }
    }

void Die()
{
    if (isDead) return;

    isDead = true;
    animationController.HandleDeath();
    StartCoroutine(DelayedDeathUI());
    soundManager.PlaySound(deathSound);

}

IEnumerator DelayedDeathUI()
{
    yield return new WaitForSeconds(1f);
    uiManager.ShowDeathUI();
}

}
