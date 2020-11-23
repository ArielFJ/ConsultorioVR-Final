using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnfermedadManager : MonoBehaviour
{

    public List<Enfermedad> enfermedad;



    // Start is called before the first frame update
    void Start()
    {
        //Se recorre la lista de enfermedadades verdaderas y falsas, se compara si los sintomas dentro del Enum Sintomas ya existen dentro de la lista de Enfermedades verdaderas y falsas,
        //en caso de que no exista en ambas, se agrega a la lista de enfermadades falsas de manera aleatoria.
        for (int i = 0; i < enfermedad.Count; i++)
        {
            for(int j = 0; j < enfermedad[i].SintomasVerdaderos.Count; j++)
            {
                Sintomas sintomaAleatorio = (Sintomas)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Sintomas)).Length);

                if (!enfermedad[i].SintomasVerdaderos.Contains(sintomaAleatorio) && !enfermedad[i].SintomasFalsos.Contains(sintomaAleatorio))
                {
                    enfermedad[i].SintomasFalsos.Add(sintomaAleatorio);
                }
                else
                {
                    j--;
                }

            }
        }
    }

}
