using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float currentSpeed; // Declare the variable for obstacle speed 

    void Start()
    {
        // Initialize the speed from GameManager
        currentSpeed = GameManager.Instance.characterSpeed * 0.8f;
    }
    void Update()
    {
        // Dynamically adjust obstacle speed based on GameManager
        if (GameManager.Instance.score >= 20)
        {
            currentSpeed = GameManager.Instance.characterSpeed * 0.8f;
            Debug.Log("Obstacle speed increased to: " + currentSpeed);
        }

        // Move the obstacle
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        // Destroy the obstacle if it goes out of screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}