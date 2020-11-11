using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicamento : MonoBehaviour
{
    public string Nombre;
    public List<Sintomas> Sintomas;
    public List<Alergia> Alergias;

    // Métodos de medicamento
    public bool TieneEfectosPositivos(Enfermedad enfermedad)
    {
        return false;
    }

    public bool TieneEfectosNegativos(Enfermedad enfermedad)
    {
        return false;
    }

    public bool CausaEfectosNegativosAPaciente(Persona persona)
    {
        return false;
    }
}
