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

    [SerializeField] private GameObject[] all_hints;

    private void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        PlayerPrefs.SetString("is_started_dialog", "true");
        Camera.main.GetComponent<JoysticMovement>().indialog = true;
        if (PlayerPrefs.GetInt("dialogues_number") == 8)
        {
            Camera.main.GetComponent<JoysticMovement>().UpdateBorder(200);
            Camera.main.orthographicSize = 10;
            Camera.main.GetComponent<JoysticMovement>().SetNewPosition(18, 183);
        }
            game_interface.SetActive(false);
        dialogueInterface.SetActive(true);
        Camera.main.GetComponent<CameraZoom>().enabled = false;
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
        bool temp_need = false;
        string temp = "";
        string end_temp = "";
        bool end=false;
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            if (letter == '<' || temp_need)
            {
                temp_need = true;
                temp += letter;
                if (letter == '>' && end)
                {
                    temp = "";
                    temp_need = false;
                }
                else if (letter == '>')
                {
                    temp_need = false;
                    if (temp == "<b>")
                    {
                        end_temp = "</b>";
                    }
                    else if (temp == "<b><i>")
                    {
                        end_temp = "</i></b>";
                    }
                }
                else if (letter == '/')
                {
                    end_temp = "";
                    end = true;
                }
            }
            else
            {
                dialogueText.text += temp+letter+end_temp;
                yield return null;
            }
        }
    }

    public void EndDialogue()
    {
        
        dialogueInterface.SetActive(false);
        game_interface.SetActive(true);
        Camera.main.GetComponent<JoysticMovement>().indialog = false;
        Camera.main.GetComponent<CameraZoom>().enabled = true;
        PlayerPrefs.SetInt("dialogues_number", PlayerPrefs.GetInt("dialogues_number")+1);
        if (PlayerPrefs.GetInt("dialogues_number")-1==0)
        {
            Destroy(GameObject.Find("WaitLoad"));
            Camera.main.GetComponent<JoysticMovement>().SetNewPosition(21, 72);
            game_interface.GetComponentInParent<StartGame>().NeededStartNewDialogue();
        }
        else if (PlayerPrefs.GetInt("dialogues_number")-1 == 1)
        {
            game_interface.GetComponentInParent<StartGame>().NeededStartNewDialogue();
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 2)
        {
            Camera.main.GetComponent<JoysticMovement>().SetNewPosition(29, 60);//18 73
            Camera.main.orthographicSize = 3;
            game_interface.GetComponentInParent<StartGame>().HideRiddles("findsibling");
            all_hints[0].SetActive(true);
            all_hints[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 3)
        {
            game_interface.GetComponentInParent<StartGame>().NeededStartNewDialogue();
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 4)
        {
            Camera.main.GetComponent<JoysticMovement>().SetNewPosition(18, 73);//28 65
            Camera.main.orthographicSize = 3;
            game_interface.GetComponentInParent<StartGame>().HideRiddles("followingpuzzle");
            all_hints[0].SetActive(true);
            all_hints[2].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 5)
        {
            game_interface.GetComponentInParent<StartGame>().NeededStartNewDialogue();
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 6)
        {
            Camera.main.GetComponent<JoysticMovement>().SetNewPosition(28, 65);//29 60
            Camera.main.orthographicSize = 3;
            game_interface.GetComponentInParent<StartGame>().HideRiddles("plates");
            all_hints[0].SetActive(true);
            all_hints[3].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 8)
        {
            game_interface.GetComponentInParent<StartGame>().NeededStartNewDialogue();
        }
        else if (PlayerPrefs.GetInt("dialogues_number") - 1 == 9)
        {
            Camera.main.GetComponent<JoysticMovement>().SetNewPosition(20, 180);
            Camera.main.orthographicSize = 5;
            game_interface.GetComponentInParent<StartGame>().HideRiddles("findobject");
            all_hints[0].SetActive(true);
            all_hints[4].SetActive(true);
        }
        PlayerPrefs.SetString("is_started_dialog", "false");


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
