using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSequenceManager : MonoBehaviour
{
    [SerializeField] private string[] correctSequence; 
    private List<string> playerSequence = new List<string>(); 
    private bool sequenceCompleted = false;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Game reset on scene load.");

    }
    public void ButtonClicked(string buttonName)
    {
        Debug.Log($"Button clicked: {buttonName}");
        if (sequenceCompleted)
            return;

        playerSequence.Add(buttonName);

        
        for (int i = 0; i < playerSequence.Count; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                Debug.Log("Incorrect sequence! Resetting...");
                playerSequence.Clear(); 
                return;
            }
        }

        
        if (playerSequence.Count == correctSequence.Length)
        {
            Debug.Log("Correct sequence entered!");
            sequenceCompleted = true;

            
            PlayerPrefs.SetInt("KeySpawned", 1); 
            PlayerPrefs.Save();

           
            Debug.Log("Key will now spawn in the target scene.");
        }
    }
}
