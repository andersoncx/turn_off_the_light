using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameReset : MonoBehaviour
{
    public void ResetGame()
    {
        // Clears all PlayerPrefs data
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Game state reset. All PlayerPrefs data cleared.");
    }
}

