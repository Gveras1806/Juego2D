using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMARA : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public Vector3 offset;   // Offset opcional para ajustar la posici�n de la c�mara respecto al jugador

    void Update()
    {
        if (target != null)
        {
            // Obtener la posici�n actual de la c�mara
            Vector3 newPosition = transform.position;

            // Centrar la c�mara en el eje X y Y del jugador, aplicando el offset
            newPosition.x = target.position.x + offset.x;
            newPosition.y = target.position.y + offset.y;

            // Aplicar la nueva posici�n a la c�mara
            transform.position = newPosition;
        }
    }
}
