using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; 
    public List<Sprite> itemIcons; 
    public List<string> inventory; 
    public Button[] slots; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<InventoryManager>().Length > 1)
        {
            Destroy(gameObject);
        }

      
        inventoryPanel = transform.Find("Canvas/InventoryPanel").gameObject;
        if (inventoryPanel == null)
        {
            Debug.LogError("Inventory Panel not found as a child of InventoryManager.");
        }
    }

    void Start()
    {
        inventoryPanel.SetActive(false); 
        ClearInventory(); 
    }

    public void AddItem(string itemName, Sprite itemIcon)
    {
        inventory.Add(itemName);
        UpdateInventory(itemName, itemIcon);
    }

    public bool HasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }

    void UpdateInventory(string itemName, Sprite itemIcon)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Image slotImage = slots[i].transform.GetChild(0).GetComponent<Image>();
            if (slotImage.sprite == null)
            {
                slotImage.sprite = itemIcon; 
                return; 
            }
        }

        Debug.LogWarning("No empty slot found for item: " + itemName);
    }

    public void RemoveItem(string itemName)
    {
        int index = inventory.IndexOf(itemName);
        if (index != -1)
        {
            inventory.RemoveAt(index);
            ClearSlot(index);
        }
    }

    public void UseItem(int slotIndex)
    {
        if (inventory[slotIndex] != null)
        {
            Debug.Log("Used " + inventory[slotIndex]);
            RemoveItem(inventory[slotIndex]); 
        }
    }

    void ClearSlot(int index)
    {
        slots[index].transform.GetChild(0).GetComponent<Image>().sprite = null;
    }

    public void ClearInventory()
    {
        foreach (Button slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                Image slotImage = slot.transform.GetChild(0).GetComponent<Image>();
                if (slotImage != null)
                {
                    slotImage.sprite = null; 
            }
        }

        inventory.Clear(); 
    }

    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}

