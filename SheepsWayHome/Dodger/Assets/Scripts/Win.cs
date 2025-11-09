using UnityEngine;
/// <summary>
/// Handles the win condition when the player collides with the win object
/// and has collected the required number of flowers.
/// </summary>
public class Win : MonoBehaviour
{
    private const int RequiredFlowerCount = 4;
    public GameObject winUI;
    public AudioSource backgroundMusic;
    public AudioSource winSound;
    
    // Detects collision with the win object and checks flower count
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Win") && Flower.flowerCount == RequiredFlowerCount)
        {
            Time.timeScale = 0f;
            winUI.SetActive(true);
            backgroundMusic.Pause();
            // play the win sound after a 1 second delay
            winSound.PlayDelayed(.5f);


            
        }
    }
}
