using UnityEngine;

public class GhostInteraction : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager; // Reference to the DialogueManager

    private string[] ghostDialogue = {
        "You: Wha- ...Where am I?",
        "You: Who are you?",
        "Ghost: It matters not who I am.",
        "You: Okay but why am I here?",
        "Ghost: It matters not why you are here.",
        "You: Sooo can I leave?",
        "Ghost: You cannot leave till the lights are out.",
        "You: What does that mean?",
        "Ghost: You cannot leave till the lights are out.",
        "You: Guess I better look around then..."
    };

    public void OnGhostClicked()
    {
        if (dialogueManager != null && !dialogueManager.IsDialogueActive())
        {
            Debug.Log("Ghost clicked. Starting dialogue.");
            dialogueManager.ShowDialogue(ghostDialogue);
        }
        else
        {
            Debug.LogWarning("Dialogue is already active or DialogueManager is not assigned!");
        }
    }
}
