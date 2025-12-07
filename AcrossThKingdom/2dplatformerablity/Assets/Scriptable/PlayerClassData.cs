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
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;
    public AudioClip rollSound;
    public AudioClip landSound;
    public AudioClip climbSound;
    public Color classColor = Color.red;
}
