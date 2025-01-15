using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance

    public Text scoreText; // Reference for Score UI
    public Text highScoreText; // Reference for High Score UI
    public GameObject gameOverPanel; // Reference for Game Over UI

    public int score; // Current score of the player
    public int highScore; // High score
    public float characterSpeed = 5f; // Speed of the character
    private bool speedIncreased = false; // Flag to ensure speed increases once

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
         // Increment score over time
        score += Mathf.RoundToInt(Time.deltaTime * 10);
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
         if (score >= 20 && !speedIncreased)
        {
            characterSpeed *= 1.5f; // Increase speed globally
            speedIncreased = true;
            Debug.Log("Global speed increased to: " + characterSpeed);
        }
    }
    public void GameOver()
    {
        Debug.Log("Game Over!"); // Log Game Over

        // Stop the game
        Time.timeScale = 0;

        // Show Game Over UI (if set up)
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // Save the high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void RestartGame()
    {
        // Reset game state
        score = 0;
        characterSpeed = 5f; // Reset speed
        speedIncreased = false; // Reset speed increase flag
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Debug.Log("Game restarted! Speed and score reset.");
    }

    private void UpdateUI()
    {
        // Update score and high score in the UI
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }

        if (highScoreText != null)
        {
            highScoreText.text = $"High Score: {highScore}";
        }
    }
}
