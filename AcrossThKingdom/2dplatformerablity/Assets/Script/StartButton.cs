using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IButton
{
    public Button startButton;
    void Start()
    {
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(Button);
    }
    public void Button()
    {
        SceneManager.LoadScene("CharaterSelection");
    }

}

