using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil a lanzar
    public float projectileSpeed = 5f; // Velocidad del proyectil
    public float cooldownTime = 2f; // Tiempo entre lanzamientos

    private float lastShotTime; // Tiempo del último lanzamiento

    void Update()
    {
        if (Time.time > lastShotTime + cooldownTime)
        {
            ShootProjectile();
            lastShotTime = Time.time;
        }
    }

    void ShootProjectile()
    {
        // Instanciar el proyectil
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Obtener el jugador usando la etiqueta "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Calcular dirección hacia el jugador
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Debug.Log("Direction to player: " + direction);

            // Aplicar velocidad al proyectil en la dirección hacia el jugador
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
            Debug.Log("Projectile velocity: " + rb.velocity);
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
}
