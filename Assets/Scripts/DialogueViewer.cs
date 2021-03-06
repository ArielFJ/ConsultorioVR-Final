﻿using System.Collections;
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
    [SerializeField] Transform parentOfResponses;
    [SerializeField] Button prefab_btnResponse;
    [SerializeField] TMPro.TextMeshProUGUI Conversacion;
    [SerializeField] DialogueController DialogueController;
    public List<GameObject> sintomasEncontrados;
    private List<string> nombresSintomasEncontrados;
    DialogueController controller;

    public static DialogueViewer instance;

	private void Awake()
	{
        instance = this;
	}

	public static Action<string> OnSintomaEncontrado;

    //List<GameObject> go = new List<GameObject>();

    [DllImport("__Internal")]
    private static extern void openPage(string url);

    private void Start()
    {        

        /*controller = DialogueController;
        controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
        //Tos.GetComponent<RawImage>();
        //Fiebre.GetComponent<RawImage>();
        //Start the Dialogue
        controller.GetCurrentNode();*/

    }

    public void init(DialogueController c)
	{
        controller = c;
        controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
        //Tos.GetComponent<RawImage>();
        //Fiebre.GetComponent<RawImage>();
        //Start the Dialogue
        controller.GetCurrentNode();
    }

    private void Update()
    {        
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
        
        foreach (GameObject go in sintomasEncontrados)
        {
            string nombreSintoma = go.name.Replace("Si", "");
            //Debug.Log(nombreSintoma);
            if (newNode.tags.Contains(nombreSintoma) && !nombresSintomasEncontrados.Contains(nombreSintoma))
            {
                Debug.Log(nombreSintoma);
                go.SetActive(true);
                OnSintomaEncontrado?.Invoke(nombreSintoma);

                // Evita que un mismo síntoma se añada más de una vez al reiniciar diálogo
                nombresSintomasEncontrados.Add(nombreSintoma); 
            }
        }

        if (newNode.tags.Contains("END"))
        {
            Debug.Log("Termino Dialogo.");
        }
        //go = new List<GameObject>();
    }
}