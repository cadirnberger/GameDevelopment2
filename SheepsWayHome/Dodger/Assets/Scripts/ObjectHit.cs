using UnityEngine;
/// <summary>
/// Handles changing object state when hit by the player.
/// </summary>
public class ObjectHit : MonoBehaviour
{
    // Change object color and tag on collision with player
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.black;
            gameObject.tag = "Hit";
        }
    }
}
