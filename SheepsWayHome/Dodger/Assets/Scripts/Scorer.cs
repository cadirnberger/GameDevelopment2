using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Handles scoring when the player collides with objects.
/// </summary>
public class Scorer : MonoBehaviour
{
    int hits = 0;
    public UIDocument uiDocument;
    private Label hitLabel;
    [SerializeField] private ParticleSystem hitParticles;
    [SerializeField] private AudioSource hitSound;
    void Start()
    {
        hitLabel = uiDocument.rootVisualElement.Q<Label>("Score");
        hitLabel.text = "Objects Hit: 0";
        hitParticles.Stop();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit" && other.gameObject.tag != "Win" && other.gameObject.tag != "Flower")
        {
            hits++;
            hitLabel.text = "Objects Hit: " + hits;
            hitParticles.Play();
            hitSound.Play();

        }
    }
}
