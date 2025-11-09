using UnityEngine;
/// <summary>
/// Handles player movement including forward/backward motion and rotation.
/// </summary>
public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    // Initialize flower count at start
    void Start() 
    {
        Flower.flowerCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Rotate();
    }
    // Handle player movement based on vertical input
    void MovePlayer()
    {
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(0, 0, zValue);
    }
    // Handle player rotation based on horizontal input
    void Rotate()
    {
        float rotationSpeed = 90f;
        float yRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, yRotation, 0);
    }


}
