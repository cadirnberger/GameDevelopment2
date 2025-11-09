using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Intructions : MonoBehaviour
{
    /// <summary>
    /// Manages the display and closing of the instructions UI at game start.
    /// </summary>
    public GameObject instructionsUI;
    // Show instructions and pause game at start
    void Start()
    {
        if (instructionsUI != null)
            instructionsUI.SetActive(true);
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        CloseInstructions();
    }
    // Close instructions UI on space key press and resume game
    public void CloseInstructions()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (instructionsUI != null)
                instructionsUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
