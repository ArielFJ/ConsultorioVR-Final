using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnfermedadManager : MonoBehaviour
{
    public static EnfermedadManager instance;

    public List<Enfermedad> enfermedades;
    
    public Dictionary<string, int> porcentajeEnfermedad;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Se recorre la lista de enfermedadades verdaderas y falsas, se compara si los sintomas dentro del Enum Sintomas ya existen dentro de la lista de Enfermedades verdaderas y falsas,
        //en caso de que no exista en ambas, se agrega a la lista de enfermadades falsas de manera aleatoria.

        /* for (int i = 0; i < enfermedad.Count; i++)
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
         }*/

        porcentajeEnfermedad = new Dictionary<string, int>();

        foreach (Enfermedad e in enfermedades)
        {
            porcentajeEnfermedad.Add(e.nombre, 0);
        }

    }
    
    public void CalcularPorcentaje(string nombreSintoma)
    {
        foreach(Enfermedad e in enfermedades)
        {
            foreach(Sintomas s in e.SintomasVerdaderos)
            {
                if (s.ToString().Equals(nombreSintoma))
                {
                    porcentajeEnfermedad[e.nombre] += 100 / e.SintomasVerdaderos.Count;
                }
            }
        }
    }

}
