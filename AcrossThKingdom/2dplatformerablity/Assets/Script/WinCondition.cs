using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour, IButton
{
    public PlayerUIManager uiManager;
    public Button nextLevelButton;
    PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ShowWinLevelUI();
            nextLevelButton.onClick.RemoveAllListeners();
            nextLevelButton.onClick.AddListener(Button);
            playerStats = other.GetComponent<PlayerStats>();
            SelectedClass.bonusHealth += 10;
            SelectedClass.bonusAttack += 5;
            SelectedClass.bonusAgility += .02f;
        }
    }
    public void Button()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

    }
}
