using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel; 
    public TMP_Text dialogueText; 
    private string[] dialogueLines; 
    private int currentLine = 0; 
    private bool isDialogueActive = false; 

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string[] lines)
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogError("No dialogue lines provided to ShowDialogue!");
            return;
        }

        dialogueLines = lines;
        currentLine = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
        Debug.Log($"Starting dialogue: {dialogueLines[currentLine]}");
    }

    public void NextDialogue()
    {
        if (!isDialogueActive) return;

        Debug.Log($"Current line before increment: {currentLine}");
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            Debug.Log($"Displaying dialogue: {dialogueLines[currentLine]}");
        }
        else
        {
            Debug.Log("No more dialogue lines. Ending dialogue.");
            EndDialogue();
        }
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        currentLine = 0;
        Debug.Log("Dialogue panel hidden.");
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed for next dialogue.");
            NextDialogue();
        }
    }
}
