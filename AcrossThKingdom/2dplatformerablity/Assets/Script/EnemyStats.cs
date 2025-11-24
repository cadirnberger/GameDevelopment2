using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private EnemiesData _enemiesData;

    public float Health { get; private set; }
    public float Attack { get; private set; }
    public float Speed { get; private set; }
    public float AttackRange { get; private set; }
    public float DetectionRange { get; private set; }


    public void Initialize(EnemiesData enemiesData)
    {
        if (enemiesData == null)
        {
            Debug.LogError("[EnemyStats] EnemiesData is null!");
            return;
        }

        _enemiesData = enemiesData;

        Health = enemiesData.health;
        Attack = enemiesData.attack;
        Speed = enemiesData.speed;
        AttackRange = enemiesData.attackRange;
        DetectionRange = enemiesData.detectionRange;

        Debug.Log($"[EnemyStats] Initialized {enemiesData.enemyName} - Health:{Health}, Attack:{Attack}, Speed:{Speed}, AttackRange:{AttackRange}, DetectionRange:{DetectionRange}");
    }

}
