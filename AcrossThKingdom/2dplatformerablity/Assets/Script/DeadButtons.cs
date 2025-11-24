using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadButton : MonoBehaviour, IButton
{
    public Button quitButton;

    void Start()
    {
        if (quitButton != null)
        {
            quitButton.onClick.RemoveAllListeners();
            quitButton.onClick.AddListener(Button);
        }
    }
    public void Button()
    {
        SceneManager.LoadScene("Start Scene");
    } 
}
