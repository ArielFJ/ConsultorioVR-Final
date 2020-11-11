using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Clipboard : MonoBehaviour
{
    
    public Persona persona;
    List<Alergia> alergias;

    public TextMeshProUGUI TextNombre;
    public TextMeshProUGUI TextEdad;
    public TextMeshProUGUI TextSexo;
    public TextMeshProUGUI TextPeso;
    public TextMeshProUGUI TextAltura;
    public TextMeshProUGUI TextTipoSangre;
    public TextMeshProUGUI TextAlergias;

    private void Start()
    {
        //Se pasan los datos de la Persona al Clipboard
        TextNombre.text = persona.Nombre;
        TextSexo.text = persona.Sexo.ToString();
        TextAltura.text = persona.Altura.ToString();
        TextPeso.text = persona.Peso.ToString();
        TextTipoSangre.text = persona.TipoSangre.ToString();
        TextEdad.text = persona.Edad.ToString();
        alergias = new List<Alergia>(persona.alergiasCliente);
        //TextAlergias.text = "Alergias: \n";
        foreach (Alergia alergia in alergias)
        {
            TextAlergias.text += $" {alergia}\n";
        }
        
    }
    private void Update()
    {
        
    }

}



