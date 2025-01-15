using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; // Reference to the TMP_Text for score
    [SerializeField] private TMP_Text bestScoreText; // Reference to the TMP_Text for best score
    private int score = 0;
    private int bestScore = 0;
    private bool isPlayerAlive = true;

    private void Start()
    {
        // Ensure the "ScoreTrigger" tag exists
        AddScoreTriggerTag();

        // Load the best score from PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        // Update the score and best score UI
        UpdateScoreText();
        UpdateBestScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerAlive && collision.gameObject.CompareTag("ScoreTrigger"))
        {
            // Increment the score
            score++;
            UpdateScoreText();

            // Update the best score if the current score exceeds it
            if (score > bestScore)
            {
                bestScore = score;
                UpdateBestScoreText();

                // Save the new best score to PlayerPrefs
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateBestScoreText()
    {
        if (bestScoreText != null)
        {
            bestScoreText.text = "Best: " + bestScore;
        }
    }

    public void PlayerDeath()
    {
        isPlayerAlive = false;

        // Update score text for game over
        if (scoreText != null)
        {
            scoreText.text = "Game Over! Final Score: " + score;
            scoreText.color = Color.red; // Optional: Change the text color for emphasis
        }
    }

    private void AddScoreTriggerTag()
    {
        // Check if the "ScoreTrigger" tag exists, and if not, add it
        if (!IsTagPresent("ScoreTrigger"))
        {
            Debug.LogWarning("Tag 'ScoreTrigger' does not exist. Please add it in the Unity Editor or set it programmatically.");
        }
    }

    private bool IsTagPresent(string tag)
    {
        // Check if the tag exists in Unity's internal tag system
        try
        {
            GameObject testObject = new GameObject();
            testObject.tag = tag;
            Destroy(testObject);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
