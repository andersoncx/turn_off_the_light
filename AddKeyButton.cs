using UnityEngine;

public class AddKeyButton : MonoBehaviour
{
    [SerializeField] private string keyName = "KidsKey"; 
    [SerializeField] private Sprite keyIcon; 
    [SerializeField] private DialogueManager dialogueManager;

    private InventoryManager inventoryManager;

    void Start()
    {
       
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene.");
        }

                if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
        }

        if (dialogueManager == null)
        {
            Debug.LogError("No DialogueManager found in the scene!");
        }
    }

    

    
    public void AddKeyToInventory()
    {
        if (inventoryManager != null)
        {
            inventoryManager.AddItem(keyName, keyIcon);
            Debug.Log($"Added {keyName} to inventory.");
        }
        else
        {
            Debug.LogError("InventoryManager is not assigned or found!");
        }

          if (dialogueManager != null)
            {
                dialogueManager.ShowDialogue(new string[] { "Got it!" });
                Debug.Log("DialogueManager notified with message: Got it!");
            }
            else
            {
                Debug.LogError("DialogueManager is not assigned or found.");
            }
    }
}

