using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public AudioClip nextSong;
    public void Play()
    {
        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong,1F);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void explorer()
    {
        SceneManager.LoadScene("sceneShip");
        SoundPlayer.instance.SetMusic(nextSong,1F);
    }

    public void EncaisserGains()
    {
        GameValues.instance.encaisserGains();
        RunManager.currentRun = 0;
        
        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong,1F);
    }

    public void RetourLaboratoire()
    {
        RunManager.currentRun = 0;

        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong, 1F);
    }

    public void RetourMenu()
    {
        RunManager.currentRun = 0;

        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong, 1F);
    }
    public void ContinuerExploration()
    {
        RunManager.newRun();
    }

    
}
