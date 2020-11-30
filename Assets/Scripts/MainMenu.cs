using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, dialogueController, canvasDialogue, dialogueRandomnizer, utiles;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateMenus();
        }
    }

    public void ActivateMenus()
	{
        mainMenu.SetActive(false);
        utiles.SetActive(true);
        dialogueRandomnizer.SetActive(true);
        canvasDialogue.SetActive(true);
        dialogueController.SetActive(true);
        DialogueViewer.instance.init(dialogueController.GetComponent<DialogueController>());
        //mainMenu.SetActive(false);
	}


}
