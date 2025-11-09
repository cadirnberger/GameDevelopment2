using UnityEngine;
/// <summary>
/// Handles flying the GameObject towards the player and destroying it upon arrival.
/// </summary>
public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform player;
    Vector3 playerPosition;
    // Initializes the projectile as inactive
    void Awake() 
    {
        gameObject.SetActive(false);
    }
    // Sets the target player position at start
    void Start()
    {
        playerPosition = player.transform.position;
    }
    // Moves the object towards the player each frame
    void Update()
    {
        MoveToPlayer();
        DestroyWhenReached();
    }
    // Moves the object towards the player's position
    void MoveToPlayer()
    {
        transform.position = 
        Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime*speed);
    }
    // Destroys the object when it reaches the player's position
    void DestroyWhenReached()
    {
        if (transform.position == playerPosition)
        {
            Destroy(gameObject);
        }
    }
}
