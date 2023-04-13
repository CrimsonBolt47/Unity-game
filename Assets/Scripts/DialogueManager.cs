using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] public GameObject choicePanel;
    [SerializeField] public Button choice;
    List<Choice> currentChoices;
    bool madechoice;

    public bool GetMadeChoice()
    {
        return madechoice;
    }
    public bool GetDialogueisPlaying()
    {
        return dialogueIsPlaying;
    }

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one");

        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }
    private void Update()
    {
        
        if (!dialogueIsPlaying)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }

    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();

    }
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            Debug.Log(dialogueText.text);
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private void DisplayChoices()
    {
        madechoice = false;
        currentChoices = currentStory.currentChoices;
        int index = 0;
        if(currentChoices.Count!=0)
        {
            dialoguePanel.SetActive(false);
            foreach (Choice c in currentChoices)
            {
                var Choose = Instantiate(choice, choicePanel.transform) as Button;
                var choicetext = Choose.GetComponentInChildren<TextMeshProUGUI>();
                choicetext.text = c.text;
                index++;
            }
            currentChoices = null;
        }
       
    }
    public void MakeChoice(int choiceindex)
    {
        dialoguePanel.SetActive(true);
        currentStory.ChooseChoiceIndex(choiceindex);
        Debug.Log("choice decided" + choiceindex);
        ContinueStory();
        madechoice = true;
    }


}
