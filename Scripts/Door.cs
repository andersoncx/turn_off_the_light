using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string requiredKey; 
    [SerializeField] private string sceneToLoad; 
    [SerializeField] private DialogueManager dialogueManager; 
    private bool isUnlocked = false; 

    void Start()
    {
        
        isUnlocked = PlayerPrefs.GetInt(gameObject.name + "_Unlocked", 0) == 1;
    }

    public void TryOpenDoor()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();

        if (isUnlocked)
        {
           
            Debug.Log("Door is already unlocked! Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (inventory != null && inventory.HasItem(requiredKey))
        {
            Debug.Log("Door unlocked! Loading scene: " + sceneToLoad);
            isUnlocked = true; 
            inventory.RemoveItem(requiredKey); 
            SaveDoorState(); 
            SceneManager.LoadScene(sceneToLoad); 
        }
        else
        {
            
            Debug.Log("The door is locked or the wrong key was used!");
            ShowLockedDoorDialogue();
        }
    }

    private void ShowLockedDoorDialogue()
    {
        if (dialogueManager != null)
        {
            dialogueManager.ShowDialogue(new string[] {
                "It's locked."
            });
        }
        else
        {
            Debug.LogWarning("DialogueManager is not assigned!");
        }
    }

    private void SaveDoorState()
    {
        PlayerPrefs.SetInt(gameObject.name + "_Unlocked", 1); 
        PlayerPrefs.Save(); 
    }
}
