using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Handles flower collection, updates UI, and plays effects upon collection.
/// </summary>
public class Flower : MonoBehaviour
{
    public static int flowerCount = 0;
    public UIDocument uiDocument;
    private Label flowerLabel;
    [SerializeField] private ParticleSystem partialsSystem;
    [SerializeField] private AudioSource collectSound;
    // Initialize flower count and UI label
    void Start()
    {
        flowerLabel = uiDocument.rootVisualElement.Q<Label>("Flowers");
        flowerLabel.text = "Flowers Collected: 0/4";
        partialsSystem.Stop();
    }
    // Handle flower collection on trigger enter
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            flowerCount++;
            flowerLabel.text = "Flowers Collected: " + flowerCount + "/4";
            partialsSystem.Play();
            collectSound.Play();
            Destroy(other.gameObject);
        }
    }
}
