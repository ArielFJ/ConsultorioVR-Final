using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogueObject;
using UnityEngine.Events;
using System;
using System.Runtime.InteropServices;
using TMPro;

public class DialogueViewer : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    [SerializeField] Transform parentOfResponses;
    [SerializeField] Button prefab_btnResponse;
    [SerializeField] TMPro.TextMeshProUGUI Conversacion;
    [SerializeField] DialogueController DialogueController;
    public GameObject Tos;
    public GameObject Fiebre;
    public GameObject Gripe;
    public GameObject Covid;
    DialogueController controller;
    Persona persona;

    [DllImport("__Internal")]  
    private static extern void openPage(string url);

    private void Start()
    {
        controller = DialogueController;
        controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
        Tos.GetComponent<RawImage>();
        Fiebre.GetComponent<RawImage>();
        //Start the Dialogue
        controller.GetCurrentNode();
        Tos.SetActive(true);
        persona = FindObjectOfType<Persona>();
        if (persona) { nameText.text = persona.Nombre; }

    }

    public static void KillAllChildren(UnityEngine.Transform parent)
    {
        
        UnityEngine.Assertions.Assert.IsNotNull(parent);
        for (int childIndex = parent.childCount - 1; childIndex >= 0; childIndex--)
        {
            UnityEngine.Object.Destroy(parent.GetChild(childIndex).gameObject);
        }
    }

    private void OnNodeSelected(int indexChosen)
    {
        Debug.Log("Chose: " + indexChosen);
        controller.ChooseResponse(indexChosen);
    }

    private void OnNodeEntered(Node newNode)
    {
        Conversacion.text = newNode.text;
        KillAllChildren(parentOfResponses);
            for (int i = newNode.responses.Count - 1; i >= 0; i--)
            {
                int currentChoiceIndex = i;
                var response = newNode.responses[i];
                var responceButton = Instantiate(prefab_btnResponse, parentOfResponses);
                responceButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (response.displayText);
                responceButton.onClick.AddListener(delegate { OnNodeSelected(currentChoiceIndex); });
            }

        if (newNode.tags.Contains("Fiebre"))
        {
            Fiebre.SetActive(true);
        }
        else if (newNode.tags.Contains("Gripe"))
        {
            Gripe.SetActive(true);
        }
        else if (newNode.tags.Contains("Covid"))
        {
            Covid.SetActive(true);
        }
        if (newNode.tags.Contains("END"))
        {
            Debug.Log("Termino Dialogo.");
        }
    }
}