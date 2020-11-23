using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taskboard : MonoBehaviour
{
    // Start is called before the first frame update
    //public List<Enfermedad> enfermedades = new List<Enfermedad>();
    Enfermedad gripe;
    public List<string> sintomasSeleccionados;    
    public Slider Gripe;
    public Slider Covid;
    public Slider Fiebre;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MarcarSintomas();
    }


    void MarcarSintomas()
    {
        Gripe.value = EnfermedadManager.instance.porcentajeEnfermedad["Gripe"];
        Covid.value = EnfermedadManager.instance.porcentajeEnfermedad["COVID"];
        Fiebre.value = EnfermedadManager.instance.porcentajeEnfermedad["Fiebre"];
    }
   
}

