﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicamento : MonoBehaviour
{
    public string Nombre;
    public List<Sintomas> Sintomas;
    public List<Alergia> Alergias;

    // Métodos de medicamento
    public bool TieneEfectosPositivos(Enfermedad enfermedad, out List<Sintomas> sintomasAfectados)
    {
        sintomasAfectados = new List<Sintomas>();
        foreach(Sintomas s in this.Sintomas)
        {
            if (enfermedad.SintomasVerdaderos.Contains(s))
            {
                sintomasAfectados.Add(s);
            }
        }
        
        return sintomasAfectados.Count > 0 ? true : false;
    }

    public bool TieneEfectosNegativos(Enfermedad enfermedad) // No se implementara sintomas falsos por ahora
    {
        return false;
    }

    public bool CausaEfectosNegativosAPaciente(Persona persona)
    {        
        foreach (Alergia a in Alergias)
        {
            if (persona.alergiasCliente.Contains(a))
            {
                return true;
            }
        }
        return false;
    }
}
