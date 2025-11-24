using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint;       // Where to spawn the player
    public Camera mainCamera;          // Main camera to follow the player
    public float cameraFollowSpeed = 5f; // Smooth camera follow speed
    

    private GameObject playerInstance;

    void Start()
    {
        if (SelectedClass.playerClass == null)
        {
            Debug.LogError("No class selected!");
            return;
        }

        // Spawn the selected class prefab
        GameObject prefab = SelectedClass.playerClass.classPrefab;
        playerInstance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned: " + prefab.name);
    }

    void LateUpdate()
    {
        if (playerInstance != null && mainCamera != null)
        {
            // Smoothly move the camera to follow the player
            Vector3 targetPos = playerInstance.transform.position;
            targetPos.z = mainCamera.transform.position.z; // Keep camera Z position
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, cameraFollowSpeed * Time.deltaTime);
        }
    }
}
