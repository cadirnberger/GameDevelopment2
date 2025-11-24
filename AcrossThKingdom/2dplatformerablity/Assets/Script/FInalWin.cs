using UnityEngine;
using UnityEngine.UI;
public class FinalWin : MonoBehaviour
{
    public PlayerUIManager uiManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ShowWinUI();
        }
    }
}
