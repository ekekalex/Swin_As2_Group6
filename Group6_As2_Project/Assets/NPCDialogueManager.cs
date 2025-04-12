using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCDialogueManager : MonoBehaviour
{
    public GameObject chatUI;
    public TextMeshProUGUI dialogueText;
    public Button responseButton1;
    public Button responseButton2;
    public Button responseButton3;

    void Start()
    {
        chatUI.SetActive(false);

        // Clear old listeners just in case
        responseButton1.onClick.RemoveAllListeners();
        responseButton2.onClick.RemoveAllListeners();
        responseButton3.onClick.RemoveAllListeners();

        // Add new listeners
        responseButton1.onClick.AddListener(() => OnPlayerResponse(1));
        responseButton2.onClick.AddListener(() => OnPlayerResponse(2));
        responseButton3.onClick.AddListener(() => OnPlayerResponse(3));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chatUI.SetActive(true);
            dialogueText.text = "Hey there! Want to help me?";
            ShowButtons(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chatUI.SetActive(false);
        }
    }

    void OnPlayerResponse(int responseIndex)
    {
        string npcReply = "";

        switch (responseIndex)
        {
            case 1:
                npcReply = "Thanks! I appreciate the help.";
                break;
            case 2:
                npcReply = "Oh, that’s too bad.";
                break;
            case 3:
                npcReply = "Sure! Here’s more info...";
                break;
        }

        dialogueText.text = npcReply;
        ShowButtons(false);
    }

    void ShowButtons(bool show)
    {
        responseButton1.gameObject.SetActive(show);
        responseButton2.gameObject.SetActive(show);
        responseButton3.gameObject.SetActive(show);
    }
}
