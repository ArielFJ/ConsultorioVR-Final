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
    [SerializeField] Transform parentOfResponses;
    [SerializeField] Button prefab_btnResponse;
    [SerializeField] TMPro.TextMeshProUGUI Conversacion;
    [SerializeField] DialogueController DialogueController;
    public List<GameObject> sintomasEncontrados;
    DialogueController controller;

    public Action<string> OnSintomaEncontrado;

    List<GameObject> go = new List<GameObject>();

    [DllImport("__Internal")]
    private static extern void openPage(string url);

    private void Start()
    {
        OnSintomaEncontrado += EnfermedadManager.instance.CalcularPorcentaje;


        controller = DialogueController;
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
            if (newNode.tags.Contains(nombreSintoma))
            {
                Debug.Log(nombreSintoma);
                go.SetActive(true);
                OnSintomaEncontrado?.Invoke(nombreSintoma);
            }
        }

        if (newNode.tags.Contains("END"))
        {
            Debug.Log("Termino Dialogo.");
        }
        go = new List<GameObject>();
    }
}