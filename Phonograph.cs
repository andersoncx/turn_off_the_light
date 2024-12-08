using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph : MonoBehaviour
{
    public string requiredItem = "PhonographHandle"; 
    public AudioSource audioSource; 
    public DialogueManager dialogueManager; 
    private InventoryManager inventoryManager; 

    void Start()
    {
        
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager found in the scene.");
        }

       
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }

        
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager is not assigned!");
        }
    }

    public void InteractWithPhonograph()
    {
        if (inventoryManager != null && inventoryManager.HasItem(requiredItem))
        {
            
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("Phonograph is playing!");
            }
        }
        else
        {
           
            if (dialogueManager != null)
            {
                dialogueManager.ShowDialogue(new string[] { "Hm, it's missing a handle." });
            }
            else
            {
                Debug.LogWarning("DialogueManager is not assigned!");
            }
        }
    }
}
