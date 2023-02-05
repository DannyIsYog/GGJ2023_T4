using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
//using Managers;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialogueTextBox;
    [SerializeField] private GameObject nameBox;
    [SerializeField] private Image nameImage;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    
    [Header("Choice UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;


    private Story currentStory;
    public bool dialogueIsPlaying {get; private set;}
    public bool delayFrame {get; private set; } = false;
    public bool makingChoices {get; private set;}

    public static DialogueManager Instance;

    private void Awake(){
        if (Instance != null){
            Debug.Log("More than one Dialogue Manager in scene");
            Destroy(this);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        
        dialogueTextBox.SetActive(false);
        dialogueIsPlaying = false;
    }
    

    private void Start(){
  
        choicesText = new TextMeshProUGUI[choices.Length];
        var index = 0;
        foreach(var choice in choices){
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if(!dialogueIsPlaying)
        {
            currentStory = new Story(inkJSON.text);
            dialogueIsPlaying = true;
        }
        
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialogueTextBox.SetActive(false);
    }

    private void ContinueStory(){
        
        if(currentStory.canContinue)
        {
            var sentence = currentStory.Continue();

            var tags = currentStory.currentTags;

            if (tags.Any())
            {

                var split = tags[0].Split(',');
                nameBox.SetActive(true);
                nameBox.GetComponentInChildren<TextMeshProUGUI>().text = tags[0];
                nameImage.sprite = Resources.Load<Sprite>("Portraits/" + tags[0]);
                if(nameImage.sprite == null)
                    nameImage.gameObject.SetActive(false);
            } else {
                nameBox.SetActive(false);
                nameImage.gameObject.SetActive(false);
            }

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        else
            StartCoroutine(ExitDialogueMode());
    }

    private void DisplayChoices(){
        var currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length){
            Debug.LogError("More choices were given than the UI can support. Number if choices given: " + currentChoices.Count);
            return;
        }

        var index = 0;
        foreach(var choice in currentChoices){
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(var i = index; i < choices.Length; i++)
            choices[i].gameObject.SetActive(false);

        StartCoroutine(ChangeSelected(choices[0].gameObject));
    }

    private IEnumerator ChangeSelected(GameObject go){
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(go);
    }

    public void MakeChoice(int choiceIndex){
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
        makingChoices = true;
        delayFrame = true;
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueTextBox.SetActive(true);

        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

        yield return new WaitForSeconds(1);
    }

    void Update() {
        if(delayFrame) {
            delayFrame = false;
        } else {
            if(makingChoices) {
                makingChoices = false;
                Debug.Log("From manager");
            }
        }
    }
}
