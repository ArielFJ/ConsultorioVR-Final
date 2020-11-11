using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public NPC npc;

    bool isTalking = false;

    float distance;
    float currentResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

   
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogue;
    public TextMeshProUGUI playerResponse;
    public string historialConversacion;
    

    
    void Start()
    {
        dialogueUI.SetActive(false);


    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 10f)
        {
            if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                currentResponseTracker++;
                if(currentResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    currentResponseTracker = npc.playerDialogue.Length - 1;
                }
            }
            else if(Input.GetAxis("Mouse ScrollWhleel") > 0f)
            {
                currentResponseTracker--;
                if(currentResponseTracker < 0)
                {
                    currentResponseTracker = 0;
                }
            }
            if(/*Input.GetKeyDown(KeyCode.E) && */isTalking == false)
            {
                StartConversation();
            }
            else if (/*Input.GetKeyDown(KeyCode.E) && */isTalking == true)
            {
                EndDialogue();
            }

            if(currentResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                historialConversacion = playerResponse.text;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogue.text = npc.dialogue[1];
                    historialConversacion += "\n" + npcDialogue.text;
                   
                }
            }
            else if(currentResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                historialConversacion = playerResponse.text;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogue.text = npc.dialogue[2];
                    historialConversacion += "\n" + npcDialogue.text;
                }
            }
            else if (currentResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                historialConversacion = playerResponse.text;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogue.text = npc.dialogue[3];
                    historialConversacion += "\n" + npcDialogue.text;
                }
            }
            else if (currentResponseTracker == 3 && npc.playerDialogue.Length >= 3)
            {
                playerResponse.text = npc.playerDialogue[3];
                historialConversacion = playerResponse.text;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogue.text = npc.dialogue[4];
                    historialConversacion += "\n" + npcDialogue.text;
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        currentResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogue.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

}
