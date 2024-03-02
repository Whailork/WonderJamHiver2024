using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("sceneLaboratory");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void explorer()
    {
        SceneManager.LoadScene("sceneShip");
    }

    public void EncaisserGains()
    {
        GameValues.instance.encaisserGains();
        RunManager.currentRun = 0;
        
        SceneManager.LoadScene("sceneLaboratory");
    }

    public void ContinuerExploration()
    {
        RunManager.newRun();
    }

    
}
