using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // This method is called when the button is clicked
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1"); // Replace "Level 2" with your scene's name
    }
}
