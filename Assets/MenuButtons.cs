using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("sceneShip");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
