using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Adjust background speed dynamically
        float backgroundSpeed = GameManager.Instance.characterSpeed * 0.5f; // Adjust multiplier as needed
        // Constant leftward movement
        startpos -= backgroundSpeed * Time.deltaTime;
        
        transform.position = new Vector3(startpos, transform.position.y, transform.position.z);

        // Loop background
        if (startpos < -length)
            {
                startpos += length;
            }
    }
}