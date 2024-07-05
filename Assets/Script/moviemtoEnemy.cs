using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviemtoEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public int steps = 3; // Número de pasos que el enemigo se moverá antes de cambiar de dirección

    private Vector3 startPosition; // Posición inicial del enemigo
    private Vector3 targetPosition; // Posición objetivo a alcanzar antes de cambiar de dirección
    private bool movingRight = true; // Indica si el enemigo se está moviendo a la derecha
    private int currentStep = 0; // Contador de pasos

    void Start()
    {
        // Guardar la posición inicial del enemigo
        startPosition = transform.position;

        // Calcular la posición objetivo inicial (3 pasos hacia adelante)
        targetPosition = startPosition + Vector3.right * steps;
    }

    void Update()
    {
        // Mover el enemigo hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verificar si el enemigo ha alcanzado la posición objetivo
        if (transform.position == targetPosition)
        {
            // Cambiar la dirección de movimiento
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Invertir la dirección de movimiento
        movingRight = !movingRight;

        // Girar el enemigo 180 grados en el eje Y para cambiar la dirección visual
        float rotationY = movingRight ? 0 : 180;
        transform.eulerAngles = new Vector3(0, rotationY, 0);

        // Actualizar la posición objetivo
        if (movingRight)
        {
            // Mover hacia adelante (3 pasos desde la posición actual)
            targetPosition = startPosition + Vector3.right * steps;
        }
        else
        {
            // Mover hacia atrás (3 pasos desde la posición actual)
            targetPosition = startPosition + Vector3.left * steps;
        }

        // Restablecer la posición de inicio para el próximo ciclo
        startPosition = transform.position;
    }
}
