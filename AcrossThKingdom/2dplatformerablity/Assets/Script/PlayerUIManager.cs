using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public GameObject healthBarUI;
    public GameObject deathUI;
    public GameObject winLevelUI;
    public GameObject winUI;

    public void ShowDeathUI()
    {
        healthBarUI.SetActive(false);
        deathUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWinLevelUI()
    {
        healthBarUI.SetActive(false);
        winLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ShowWinUI()
    {
        healthBarUI.SetActive(false);
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowHealthUI()
    {
        healthBarUI.SetActive(true);
        deathUI.SetActive(false);
        winLevelUI.SetActive(false);
        winUI.SetActive(false);
    }
}
