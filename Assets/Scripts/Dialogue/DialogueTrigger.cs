//using Managers;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset inkJSON;
    public TextAsset inkJSONReplay;

    private bool playerInRange;
    public bool played;
    public bool dialogueFromEvent = false;
    public bool trigger;


    private DialogueManager dm;

    private void Awake()
    {
        playerInRange = false;
        played = false;
    }

    private void Start(){
        if (trigger)
        {
            EnterDialogue();
        }
    }

    private void Update()
    {
        if(!dialogueFromEvent) {
            if (!DialogueManager.Instance.makingChoices && DialogueManager.Instance.dialogueIsPlaying && Input.GetButtonDown("Submit"))
                EnterDialogue();
        } else {
            dialogueFromEvent = false;
        }
    }
    public void EnterDialogue(){
        if (!played)
        {
            played = true;
            Debug.Log("ASDASD");
            DialogueManager.Instance.EnterDialogueMode(inkJSON);
        }
        else
            DialogueManager.Instance.EnterDialogueMode(inkJSONReplay);
    }

}
