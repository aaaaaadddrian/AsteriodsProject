using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Scenes/Asteroids");
    }
}
