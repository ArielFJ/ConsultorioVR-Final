using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taskboard : MonoBehaviour
{
    // Start is called before the first frame update
    //public List<Enfermedad> enfermedades = new List<Enfermedad>();
    Enfermedad gripe;
    public List<string> sintomasSeleccionados;
    public int percentage;

    void Start()
    {
        gripe = new Enfermedad();
        sintomasSeleccionados = new List<string>();
        percentage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePercentage();
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
        for (int i = 0; i < gripe.SintomasVerdaderos.Count; i++)
        {
            for (int j = 0; j < sintomasSeleccionados.Count; j++)
            {
                if (gripe.SintomasVerdaderos[i].ToString() == sintomasSeleccionados[j])
                {
                    percentage = ((percentage + 1) / gripe.SintomasVerdaderos.Count) * 100;
                }
            }
        }

    }
}

