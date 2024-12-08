using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private GameObject keyObject; // Reference to the key GameObject
    [SerializeField] private GameObject lockboxObject; // Reference to the lockbox GameObject (optional)
    [SerializeField] private GameObject lockboxButton; // Reference to the lockbox button GameObject (optional)

    private bool isKeySpawned = false; // Tracks if the key is spawned

    void Start()
    {
        Debug.Log($"KeySpawned PlayerPrefs value: {PlayerPrefs.GetInt("KeySpawned", 0)}");
        Debug.Log($"KeyPickedUp PlayerPrefs value: {PlayerPrefs.GetInt("KeyPickedUp", 0)}");

        // Check if the key has already been picked up
        if (PlayerPrefs.GetInt("KeyPickedUp", 0) == 1)
        {
            if (keyObject != null)
            {
                keyObject.SetActive(false); // Hide the key if it has been picked up
                Debug.Log("Key already picked up. It will not spawn again.");
            }
            return; // Skip further logic
        }

        // Check if the lockbox puzzle has been solved
        if (PlayerPrefs.GetInt("KeySpawned", 0) == 1)
        {
            HandleKeySpawnedState();
        }
        else
        {
            // Hide the key by default
            if (keyObject != null)
            {
                keyObject.SetActive(false); 
                Debug.Log("Key is hidden by default.");
            }
        }
    }

    public void HandleKeySpawnedState()
    {
        if (isKeySpawned) return; // Prevent spawning multiple keys

        // Activate the key
        if (keyObject != null)
        {
            keyObject.SetActive(true);
            Debug.Log("Key activated in this scene.");
            isKeySpawned = true; // Mark the key as spawned
        }

        // Deactivate the lockbox (if present)
        if (lockboxObject != null)
        {
            lockboxObject.SetActive(false);
            Debug.Log("Lockbox deactivated in this scene.");
        }

        // Deactivate the lockbox button (if present)
        if (lockboxButton != null)
        {
            lockboxButton.SetActive(false);
            Debug.Log("Lockbox button deactivated in this scene.");
        }
    }
}
