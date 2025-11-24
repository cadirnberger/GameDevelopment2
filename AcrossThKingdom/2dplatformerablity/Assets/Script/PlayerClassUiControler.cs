using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerClassUiControler : MonoBehaviour, IButton
{
    [SerializeField] private PlayerClassData playerClass;
    public Button setClassButton;
    public TMP_Text statsText;

    void Start()
    {
        SetStats();
        setClassButton.onClick.RemoveAllListeners();
        setClassButton.onClick.AddListener(Button);
    }

    void SetStats()
    {
        statsText.text = $"Class: {playerClass.className}\n" +
                         $"Health: {playerClass.baseHealth}\n" +
                         $"Attack: {playerClass.baseAttack}\n" +
                         $"Agility: {playerClass.baseAgility}\n";
    }


    public void Button()
    {
        SelectedClass.playerClass = playerClass;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
}
