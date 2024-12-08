using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonSequenceManager2 : MonoBehaviour
{
    [SerializeField] private string[] correctSequence; 
    [SerializeField] private KeySpawner keySpawner; // Reference to the KeySpawner
    private List<string> playerSequence = new List<string>(); 
    private bool sequenceCompleted = false;

    public void ButtonClicked(string buttonName)
    {
        Debug.Log($"Button clicked: {buttonName}");
        if (sequenceCompleted)
            return;

        playerSequence.Add(buttonName);

        // Check if the player's input matches the correct sequence so far
        for (int i = 0; i < playerSequence.Count; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                Debug.Log("Incorrect sequence! Resetting...");
                playerSequence.Clear(); 
                return;
            }
        }

        // If the sequence matches and is complete
        if (playerSequence.Count == correctSequence.Length)
        {
            Debug.Log("Correct sequence entered!");
            sequenceCompleted = true;

            // Save the state for the key
            PlayerPrefs.SetInt("KeySpawned", 1); 
            PlayerPrefs.Save();
            Debug.Log("Key will now spawn in the current scene.");

            // Trigger the key spawner to update the key's state
            if (keySpawner != null)
            {
                keySpawner.HandleKeySpawnedState();
            }
            else
            {
                Debug.LogError("KeySpawner reference is missing!");
            }
        }
    }
}

