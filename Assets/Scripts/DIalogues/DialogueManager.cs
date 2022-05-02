using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueInterface;
    public GameObject game_interface;

    private Queue<string> sentences;
    private string[] names=new string[50];
    private int[] change_names=new int[50];

    private void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        game_interface.SetActive(false);
        dialogueInterface.SetActive(true);
        nameText.text = dialogue.names[0];
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        for(int i=0;i<names.Length;i++)
        {
            names[i] = "";
        }
        for (int i =0;i<dialogue.names.Length;i++)
        {
            names[i] = dialogue.names[i];
        }
        for (int i = 0; i < change_names.Length; i++)
        {
            change_names[i] = -1;
        }
        for (int i = 0; i < dialogue.change_names.Length; i++)
        {
            change_names[i] = dialogue.change_names[i];
        }
        PlayerPrefs.SetInt("curr_sentence", 1);
        PlayerPrefs.SetInt("next_name", 1);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        
        dialogueInterface.SetActive(false);
        game_interface.SetActive(true);
        PlayerPrefs.SetInt("dialogues_number", PlayerPrefs.GetInt("dialogues_number")+1);
    }

    public void Update()
    {
        if (dialogueInterface.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                PlayerPrefs.SetInt("curr_sentence", PlayerPrefs.GetInt("curr_sentence") + 1);
                if (PlayerPrefs.GetInt("curr_sentence") == change_names[PlayerPrefs.GetInt("next_name")])
                {
                    nameText.text = names[PlayerPrefs.GetInt("next_name")];
                    PlayerPrefs.SetInt("next_name", PlayerPrefs.GetInt("next_name") + 1);
                }
                DisplayNextSentence();
            }
        }
    }
}
