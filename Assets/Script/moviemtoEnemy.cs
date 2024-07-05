using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviemtoEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public int steps = 3; // N�mero de pasos que el enemigo se mover� antes de cambiar de direcci�n

    private Vector3 startPosition; // Posici�n inicial del enemigo
    private Vector3 targetPosition; // Posici�n objetivo a alcanzar antes de cambiar de direcci�n
    private bool movingRight = true; // Indica si el enemigo se est� moviendo a la derecha
    private int currentStep = 0; // Contador de pasos

    void Start()
    {
        // Guardar la posici�n inicial del enemigo
        startPosition = transform.position;

        // Calcular la posici�n objetivo inicial (3 pasos hacia adelante)
        targetPosition = startPosition + Vector3.right * steps;
    }

    void Update()
    {
        // Mover el enemigo hacia la posici�n objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verificar si el enemigo ha alcanzado la posici�n objetivo
        if (transform.position == targetPosition)
        {
            // Cambiar la direcci�n de movimiento
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Invertir la direcci�n de movimiento
        movingRight = !movingRight;

        // Girar el enemigo 180 grados en el eje Y para cambiar la direcci�n visual
        float rotationY = movingRight ? 0 : 180;
        transform.eulerAngles = new Vector3(0, rotationY, 0);

        // Actualizar la posici�n objetivo
        if (movingRight)
        {
            // Mover hacia adelante (3 pasos desde la posici�n actual)
            targetPosition = startPosition + Vector3.right * steps;
        }
        else
        {
            // Mover hacia atr�s (3 pasos desde la posici�n actual)
            targetPosition = startPosition + Vector3.left * steps;
        }

        // Restablecer la posici�n de inicio para el pr�ximo ciclo
        startPosition = transform.position;
    }
}
