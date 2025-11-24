using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IButton
{
    public Button restartButton;
    void Start()
    {
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(Button);
    }
    public void Button()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
