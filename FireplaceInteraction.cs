using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceInteraction : MonoBehaviour
{
    [SerializeField] private string filledBucketItemName = "FilledBucket"; // Name of the filled bucket in the inventory
    [SerializeField] private GameObject fireplaceObject; // Reference to the fireplace object
    [SerializeField] private GameObject fireplaceButton; // Reference to the fireplace button
    private InventoryManager inventoryManager; // Reference to the InventoryManager

    void Start()
    {
        // Dynamically find the InventoryManager in the scene
        inventoryManager = FindObjectOfType<InventoryManager>();

        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene!");
        }
    }

    public void OnFireplaceButtonClicked()
    {
        // Check if the inventory manager is available
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is not available!");
            return;
        }

        // Check if the player has the filled bucket
        if (inventoryManager.HasItem(filledBucketItemName))
        {
            // Remove the filled bucket from the inventory
            inventoryManager.RemoveItem(filledBucketItemName);
            Debug.Log("Filled bucket removed from inventory.");

            // Destroy the fireplace object
            if (fireplaceObject != null)
            {
                Destroy(fireplaceObject);
                Debug.Log("Fireplace has been extinguished and destroyed.");
            }
            else
            {
                Debug.LogWarning("Fireplace object is not assigned.");
            }

            // Destroy the fireplace button
            if (fireplaceButton != null)
            {
                Destroy(fireplaceButton);
                Debug.Log("Fireplace button has been removed.");
            }
            else
            {
                Debug.LogWarning("Fireplace button is not assigned.");
            }
        }
        else
        {
            Debug.Log("Player does not have the filled bucket in their inventory.");
        }
    }
}
