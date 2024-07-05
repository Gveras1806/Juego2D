using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMARA : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public Vector3 offset;   // Offset opcional para ajustar la posición de la cámara respecto al jugador

    void Update()
    {
        if (target != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 newPosition = transform.position;

            // Centrar la cámara en el eje X y Y del jugador, aplicando el offset
            newPosition.x = target.position.x + offset.x;
            newPosition.y = target.position.y + offset.y;

            // Aplicar la nueva posición a la cámara
            transform.position = newPosition;
        }
    }
}
