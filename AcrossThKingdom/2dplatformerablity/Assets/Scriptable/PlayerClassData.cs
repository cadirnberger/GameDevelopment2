using UnityEngine;

[CreateAssetMenu(menuName = "Player/Class")]
public class PlayerClassData : ScriptableObject
{
    public string className;
    public GameObject classPrefab;
    public int baseHealth;
    public int baseAttack;
    public float baseAgility;
    public float baseAttackRange;
    public Color classColor = Color.red;
}
