using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathtubInteraction : MonoBehaviour
{
    [SerializeField] private string bucketItemName = "Bucket"; // Name of the empty bucket in the inventory
    [SerializeField] private string filledBucketItemName = "FilledBucket"; // Name of the filled bucket
    [SerializeField] private Sprite filledBucketIcon; // Icon for the filled bucket

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

    public void InteractWithBathtub()
    {
        // Check if the inventory manager was found
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is not available!");
            return;
        }

        // Check if the player has the empty bucket
        if (inventoryManager.HasItem(bucketItemName))
        {
            // Remove the empty bucket
            inventoryManager.RemoveItem(bucketItemName);
            Debug.Log("Empty bucket removed from inventory.");

            // Add the filled bucket
            inventoryManager.AddItem(filledBucketItemName, filledBucketIcon);
            Debug.Log("Filled bucket added to inventory.");
        }
        else
        {
            Debug.Log("Player does not have a bucket in their inventory.");
        }
    }
}


