using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FaseConsulta : MonoBehaviour
{


    private List<Sintomas> ListaSintomas;
    private List<Sintomas> AlmacenPalabras;
    private string[] LineaDialogo;
    private Sintomas[] DialogoConvertidoASintoma;
    
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogue;
    public TextMeshProUGUI playerResponse;
    float currentResponseTracker = 0;
    public GameObject CheckTrue;
    public GameObject CheckFalse;
    public GameObject SintomaDetectado;
    public GameObject[] ContenedorUISintomas;
    public NPC npc;

    public void Awake()
    {
        ListaSintomas = new List<Sintomas>();
        AlmacenPalabras = new List<Sintomas>();


    }


    void Start()
    {
        ContenedorUISintomas = GameObject.FindGameObjectsWithTag("Sintoma");
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    public void CheckDialogue()
    {
        if (currentResponseTracker == 0 && npc.playerDialogue.Length >= 0)
        {
            playerResponse.text = npc.playerDialogue[0];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogue.text = npc.dialogue[1];
                CheckTaskboard(npc.dialogue[1]);
            
            }
        }
        else if (currentResponseTracker == 1 && npc.playerDialogue.Length >= 1)
        {
            playerResponse.text = npc.playerDialogue[1];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogue.text = npc.dialogue[2];
                CheckTaskboard(npc.dialogue[2]);
            }
        }
        else if (currentResponseTracker == 2 && npc.playerDialogue.Length >= 2)
        {
            playerResponse.text = npc.playerDialogue[2];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogue.text = npc.dialogue[3];
                CheckTaskboard(npc.dialogue[3]);

            }
        }
        else if (currentResponseTracker == 3 && npc.playerDialogue.Length >= 3)
        {
            playerResponse.text = npc.playerDialogue[3];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogue.text = npc.dialogue[4];
                CheckTaskboard(npc.dialogue[4]);
            }
        }
        else if (currentResponseTracker == 4 && npc.playerDialogue.Length >= 4)
        {
            playerResponse.text = npc.playerDialogue[4];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogue.text = npc.dialogue[5];
                CheckTaskboard(npc.dialogue[5]);
            }
        }
    }

    public void CheckTaskboard(string respuestaPaciente)
    {
        LineaDialogo = respuestaPaciente.ToString().Split(' ');
        DialogoConvertidoASintoma = LineaDialogo.Select(a => (Sintomas)Enum.Parse(typeof(Sintomas), a, true))
                        .Cast<Sintomas>()
                        .ToArray();


        foreach (Sintomas palabra in DialogoConvertidoASintoma)
        {
            if (ListaSintomas.Contains(palabra))
            {
                AlmacenPalabras.Add(palabra);
                for (var i = 0; i < ContenedorUISintomas.Count(); i++)
                {
                    for (var j = 0; j < ContenedorUISintomas.Count(); j++)
                    {
                        if (ContenedorUISintomas[i].name.Equals(AlmacenPalabras[j]))
                        {
                            ContenedorUISintomas[i].SetActive(true);
                        }
                    }

                }
            }
        }
    }
}
