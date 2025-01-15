using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton1 : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
        Debug.Log("Play");
    }
}
