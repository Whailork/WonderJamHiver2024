using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public AudioClip nextSong;
    public AudioClip btnSound;
    public void Play()
    {
        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong,1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }

    public void QuitGame()
    {
        Application.Quit();
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }

    public void explorer()
    {
        SceneManager.LoadScene("sceneShip");
        SoundPlayer.instance.SetMusic(nextSong,1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }

   

    public void EncaisserGains()
    {
        GameValues.instance.encaisserGains();
        RunManager.currentRun = 0;
        
        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong,1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }

    public void RetourLaboratoire()
    {
        RunManager.currentRun = 0;

        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong, 1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }

    public void RetourMenu()
    {
        RunManager.currentRun = 0;

        SceneManager.LoadScene("mainMenuScene");
        SoundPlayer.instance.SetMusic(nextSong, 1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }
    public void ContinuerExploration(GameObject alerte)
    {
        RunManager.newRun();
        SoundPlayer.instance.PlaySFX(btnSound,2);
        Destroy(alerte);
    }

    
}
