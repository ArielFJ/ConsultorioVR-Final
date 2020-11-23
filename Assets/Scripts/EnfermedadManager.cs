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
        porcentajeEnfermedad = new Dictionary<string, int>();

        foreach (Enfermedad e in enfermedades)
        {
            porcentajeEnfermedad.Add(e.nombre, 0);
        }

    }

    public void CalcularPorcentaje(string nombreSintoma)
    {
        Debug.Log("Estoy aquí por: " + nombreSintoma); 
        foreach (Enfermedad e in enfermedades)
        {
            foreach (Sintomas s in e.SintomasVerdaderos)
            {
                if (s.ToString().Equals(nombreSintoma))
                {
                    porcentajeEnfermedad[e.nombre] += 100 / e.SintomasVerdaderos.Count;
                    Debug.Log($"{s} en {e.nombre}: {porcentajeEnfermedad[e.nombre]}");
                }
            }
        }
    }

}
