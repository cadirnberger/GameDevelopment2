using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerClassData _classData;

    public float Health { get; private set; }
    public float Attack { get; private set; }
    public float Agility { get; private set; }
    public float AttackRange { get; private set; }

    void Start()
    {
        if (SelectedClass.playerClass != null)
        {
            Initialize(SelectedClass.playerClass);
        }
        else
        {
            Debug.LogError("[PlayerStats] No class selected! Did you load the game scene directly?");
        }
    }

    public void Initialize(PlayerClassData classData)
    {
        if (classData == null)
        {
            Debug.LogError("[PlayerStats] ClassData is null!");
            return;
        }

        _classData = classData;

        Health = classData.baseHealth+ SelectedClass.bonusHealth;
        Attack = classData.baseAttack+ SelectedClass.bonusAttack;
        Agility = classData.baseAgility+ SelectedClass.bonusAgility;
        AttackRange = classData.baseAttackRange;

        Debug.Log($"[PlayerStats] Initialized {classData.className} - Health:{Health}, Attack:{Attack}, Agility:{Agility}");
    }


}
