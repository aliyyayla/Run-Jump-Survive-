using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; // Reference to the Game Over Canvas

    private void Start()
    {
        // Ensure the game starts with normal time scale
        Time.timeScale = 1f;

        // Hide the Game Over canvas initially
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Handle player death
            Die();
        }
    }

    private void Die()
    {
        // Show Game Over screen
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // Pause the game
        Time.timeScale = 0f;

        Debug.Log("Player has died!");
    }

    // Restart the game by reloading the scene (can be called via a UI button)
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Game restarted.");
    }
}
