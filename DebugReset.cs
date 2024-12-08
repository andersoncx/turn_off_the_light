using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DebugReset : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll(); // Clear all PlayerPrefs data
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs reset. All values cleared.");
        
        PlayerPrefs.DeleteKey("CellarDialogueShown");
        Debug.Log("Cellar dialogue state reset. It will play again.");
    }
}
