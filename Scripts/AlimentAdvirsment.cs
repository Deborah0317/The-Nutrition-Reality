using UnityEngine;

public class AlimentAdvirsment : MonoBehaviour
{
    public GameObject dialogueBoxPrefab; // Il prefab da istanziare
    private GameObject dialogueBox;

    void Start()
    {
        if (dialogueBoxPrefab != null)
        {
            // Istanzia il prefab e lo assegna a dialogueBox
            dialogueBox = Instantiate(dialogueBoxPrefab, transform.position, Quaternion.identity);
            dialogueBox.SetActive(false);
            showDialogue();
        }
    }

    void showDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }
    }

    void hideDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }
}