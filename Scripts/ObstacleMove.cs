using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float currentSpeed;
    void Start()
    {
        // Initialize the speed from GameManager
        currentSpeed = GameManager.Instance.characterSpeed * 0.8f;
    }
    
    void Update()
    {
        // Use global speed from GameManager
        float speed = GameManager.Instance.characterSpeed * 0.8f; // Adjust speed multiplier as needed
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroy the obstacle if it goes out of screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}

