using UnityEngine;
/// <summary>
/// Handles continuous rotation of the GameObject.
/// </summary>
public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 0f;
    [SerializeField] float yAngle = 0f;
    [SerializeField] float zAngle = 0f;
    // Rotates the object every frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
