using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesData", menuName = "Enemy/Type")]
public class EnemiesData : ScriptableObject
{
    public string enemyName;
    public float health;
    public float attack;
    public float speed;
    public float attackRange;
    public float detectionRange;
    
}
