using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VIDA : MonoBehaviour
{
    public int maxLives = 3;
    private static int currentLives;

    // Altura mínima para considerar que el jugador ha caído de la plataforma
    public float fallThreshold = -10f;

    // Posición segura de reinicio en la plataforma
    public Vector3 respawnPosition;
    // Referencia al componente Text para mostrar las vidas
    public Text livesText;

    void Start()
    {
        // Si currentLives aún no se ha inicializado, se establece a maxLives
        if (currentLives == 0)
        {
            currentLives = maxLives;
        }
        UpdateLivesText();
    }

    void Update()
    {
        // Check if the player has fallen off the platform
        if (transform.position.y < fallThreshold)
        {
            LoseLife(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife(false);
        }
        else if (collision.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

  public  void LoseLife(bool fellOffPlatform)
    {
        currentLives--;
        UpdateLivesText();

        if (currentLives <= 0)
        {
            currentLives = maxLives;
            SceneManager.LoadScene(0);
        }
        else if (fellOffPlatform)
        {
            // Respawn the player at the designated respawn position
            transform.position = respawnPosition;
        }
    }

    void UpdateLivesText()
    {
        livesText.text = "Vidas: " + currentLives;
    }
}
