using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MedicamentoManager : MonoBehaviour
{

    public List<Medicamento> medicamentos;
    public Persona paciente;

    [SerializeField] private List<Medicamento> medicamentosSeleccionados;

    // Start is called before the first frame update
    void Start()
    {
        medicamentosSeleccionados = new List<Medicamento>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Este método devuelve 2 booleanos.
     * El primero indica si el paciente puede tomar la medicina.
     * El segundo indica si la medicina resuelve todos los síntomas del paciente.
     * Para tomar el primer o segundo valor, utiliza Item1 o Item2
     * Ex: valorDeRetorno.Item1 -> equivale al primer bool
     */
    public (bool, bool) CanPatientTakeMedicine(Medicamento medicamento)
    {
        if (medicamento.CausaEfectosNegativosAPaciente(paciente))
            return (false, false); // El paciente no puede tomar esta medicina

        List<Sintomas> sintomasResueltos;
        if(medicamento.TieneEfectosPositivos(paciente.Enfermedad, out sintomasResueltos))
        {
            if (HasSameSintomas(sintomasResueltos, paciente.Enfermedad.SintomasVerdaderos))
            {
                return (true, true); // El paciente puede tomar la medicina y resolverá todos sus síntomas
            }
            //else
            //    return (true, false); // El paciente puede tomar la medicina, pero no resolverá todos sus síntomas
        }

        return (true, false); // El paciente puede tomar la medicina, pero no le hará efecto
    }

    /**
     * Retorna true si los sintomasMedicamento contienen todos los sintomasEnfermedad.
     * De lo contrario retorna false.
     */
    private bool HasSameSintomas(List<Sintomas> sintomasMedicamento, List<Sintomas> sintomasEnfermedad)
    {
        foreach(Sintomas s in sintomasEnfermedad)
        {
            if (!sintomasMedicamento.Contains(s))
                return false;
        }
        return true;
    }

    public void ToggleMedicamento(string nombreMedicamento)
    {
        Medicamento medicamentoSeleccionado = medicamentos.FirstOrDefault(m => m.Nombre == nombreMedicamento);
        if (medicamentoSeleccionado != null)
        {
            if (!medicamentosSeleccionados.Contains(medicamentoSeleccionado))
            {
                medicamentosSeleccionados.Add(medicamentoSeleccionado);
            } else
            {
                medicamentosSeleccionados.Remove(medicamentoSeleccionado);
            }

        }
        Debug.Log("Medicamentos seleccionados");
        medicamentosSeleccionados.ForEach(m =>
        {
            Debug.Log($"{m.Nombre}");
        });
    }
}
