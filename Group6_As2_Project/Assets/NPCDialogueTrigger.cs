using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public GameObject chatBubble; // Assign in inspector

    void Start()
    {
        if (chatBubble != null)
            chatBubble.SetActive(false); // Start hidden
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (chatBubble != null)
                chatBubble.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (chatBubble != null)
                chatBubble.SetActive(false);
        }
    }
}
