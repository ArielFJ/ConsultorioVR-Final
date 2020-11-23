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
    private float percentage = 0f;
    public Slider Gripe;
    public Slider Covid;
    public Slider Fiebre;
    public RawImage tos;
    public RawImage fiebre;

    void Start()
    {
        gripe = new Enfermedad();
        sintomasSeleccionados = new List<string>();



    }

    // Update is called once per frame
    void Update()
    {
        /*MarcarCovid();
        MarcarGripe();
        MarcarFiebre();*/
        MarcarSintomas();
    }

    private void CalculatePercentage()
    {
        //foreach(Enfermedad enfermedad in enfermedades)
        //{
        //    for(int i = 0; i < enfermedad.SintomasVerdaderos.Count; i++)
        //    {

        //        for(int j = 0; j < sintomasSeleccionados.Count; j++)
        //        {
        //            if(enfermedad.SintomasVerdaderos[i].ToString() == sintomasSeleccionados[j])
        //            {
        //               return (percentage = (percentage + 1) / enfermedad.SintomasVerdaderos.Count) * 100;
        //            }
        //        }

        //    }
        //}

        //Recorre los sintomas verdaderos y los sintomas seleccionados por el jugador, los compara, y por cada vez que haya una coincidencia, se suma uno a la variable porcentaje
        //se divide entre el total de sintomas verdaderos y luego se multiplica por 100 para retornarlo como un entero.


    }

    void MarcarSintomas()
    {
        Gripe.value = EnfermedadManager.instance.porcentajeEnfermedad["Gripe"];
        Covid.value = EnfermedadManager.instance.porcentajeEnfermedad["COVID"];
        Fiebre.value = EnfermedadManager.instance.porcentajeEnfermedad["Fiebre"];
    }

    /*void MarcarGripe()
    {
        if (tos.gameObject.activeSelf)
        {
            percentage = 50;
            Gripe.value = percentage;
        }
        else if (tos.gameObject.activeSelf)
        {
            percentage = 50;
            Gripe.value = percentage;
        }
        
        if (tos.gameObject.activeSelf && fiebre.gameObject.activeSelf)
        {
            percentage = 100;
            Gripe.value = percentage;
        }
    }
    void MarcarCovid()
    {
        if (tos.gameObject.activeSelf)
        {
            percentage = 50;
            Covid.value = percentage;
        }
    }
    void MarcarFiebre()
    {
        if (fiebre.gameObject.activeSelf)
        {
            percentage = 50;
            Fiebre.value = percentage;
        }
    }*/
}

