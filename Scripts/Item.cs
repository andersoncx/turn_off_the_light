using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Name of the item
    public Sprite itemIcon; // Icon for the item
    public string alternateItemName = "FilledBucket"; // Optional alternate item name to check in inventory

    private InventoryManager inventoryManager; // Reference to the InventoryManager

    void Start()
    {
        // Find the InventoryManager in the scene
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene!");
        }

        // Check if the item or its alternate form has already been picked up
        if (PlayerPrefs.GetInt(itemName + "_PickedUp", 0) == 1 || (inventoryManager != null && inventoryManager.HasItem(alternateItemName)))
        {
            // Item or alternate form is already picked up, destroy it
            Destroy(gameObject);
            Debug.Log($"{itemName} or {alternateItemName} has already been picked up and will not respawn.");
        }
    }

    public void PickUp()
    {
        if (inventoryManager != null)
        {
            // Add the item to the inventory
            inventoryManager.AddItem(itemName, itemIcon);
            Debug.Log($"Picked up: {itemName}");

            // Save the pickup state in PlayerPrefs
            PlayerPrefs.SetInt(itemName + "_PickedUp", 1);
            PlayerPrefs.Save();
            Debug.Log($"{itemName} pickup state saved.");

            // Destroy the item
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("InventoryManager is not assigned or found!");
        }
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
