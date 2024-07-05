using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparece : MonoBehaviour
{
    public GameObject objeto; // El objeto que quieres que aparezca y desaparezca
    public float intervalo = 1.0f; // Intervalo de tiempo en segundos para cambiar la visibilidad

    private bool visible = true; // Estado actual de visibilidad

    void Start()
    {
        // Verificar si el objeto est� asignado
        if (objeto == null)
        {
            Debug.LogError("No se ha asignado ning�n objeto en el Inspector.");
            return;
        }

        // Iniciar la rutina para alternar la visibilidad
        StartCoroutine(AlternarVisibilidad());
    }

    private IEnumerator AlternarVisibilidad()
    {
        while (true) // Ciclo infinito
        {
            // Esperar el intervalo especificado
            yield return new WaitForSeconds(intervalo);

            // Alternar la visibilidad del objeto
            visible = !visible;
            objeto.SetActive(visible); // Activar o desactivar el objeto

            // Log para depuraci�n
            Debug.Log($"Objeto activo: {visible}");
        }
    }
}
