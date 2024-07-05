using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolita : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de da�o que inflige

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hacer da�o al jugador u otros efectos (puedes ajustar seg�n tu juego)
            VIDA vida = other.GetComponent<VIDA>();
            if (vida != null)
            {
                // Llamar al m�todo LoseLife en VIDA para perder una vida
                vida.LoseLife(false); // false indica que no ha ca�do de la plataforma
            }

            // Destruir el proyectil al impactar con el jugador
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            // Destruir el proyectil al impactar con el suelo u otro objeto con el tag "Ground"
            Destroy(gameObject);
        }
    }
}
