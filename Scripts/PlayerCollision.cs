using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas; // Assign the Game Over Canvas in the Inspector

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
        // Check if the player collides with an object tagged as "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HandleGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Alternative for trigger-based obstacles
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HandleGameOver();
        }
    }

    private void HandleGameOver()
    {
        // Activate the Game Over canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // Remove the player from the scene
        Destroy(gameObject);

        // Pause the game
        Time.timeScale = 0;

        Debug.Log("Game Over triggered! Player removed, game paused, and Game Over canvas activated.");
    }

    // Restart the game (can be called via the UI button)
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
