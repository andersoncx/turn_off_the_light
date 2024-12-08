using UnityEngine;

public class CellarStart : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    void Start()
    {
        // Check if the dialogue for this scene has been played
        if (PlayerPrefs.GetInt("CellarDialogueShown", 0) == 0) // 0 = not shown, 1 = shown
        {
            // Initial dialogue lines
            string[] initialDialogue = {
                "You: Wha- ...Where am I?",
                "You: Who are you?",
                "Ghost: It matters not who I am",
                "You: Okay but why am I here?",
                "Ghost: It matters not why you are here",
                "You: Sooo can I leave?",
                "Ghost: You can not leave till the lights are out",
                "You: What does that mean?",
                "Ghost: You can not leave till the lights are out",
                "You: Guess I better look around then..."
            };

            dialogueManager.ShowDialogue(initialDialogue); // Show the initial dialogue

            // Mark the dialogue as shown
            PlayerPrefs.SetInt("CellarDialogueShown", 1);
            PlayerPrefs.Save();
        }
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.R)) // Press 'R' to reset PlayerPrefs for CellarDialogueShown
    {
        ResetDialogueState();
    }
}

    public void ResetDialogueState()
{
    PlayerPrefs.DeleteKey("CellarDialogueShown");
    Debug.Log("Cellar dialogue state reset. It will play again.");
}

}
