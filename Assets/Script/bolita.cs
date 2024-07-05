using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolita : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño que inflige

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hacer daño al jugador u otros efectos (puedes ajustar según tu juego)
            VIDA vida = other.GetComponent<VIDA>();
            if (vida != null)
            {
                // Llamar al método LoseLife en VIDA para perder una vida
                vida.LoseLife(false); // false indica que no ha caído de la plataforma
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
