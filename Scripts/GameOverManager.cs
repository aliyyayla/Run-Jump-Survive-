using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Reference to the Game Over Canvas

    void Start()
    {
        // Ensure the Game Over Canvas is initially inactive
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    public void TriggerGameOver()
    {
        // Activate the Game Over Canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }

        // Freeze the game
        Time.timeScale = 0; // Stop the game
        Debug.Log("Game Over triggered!");
    }
}
