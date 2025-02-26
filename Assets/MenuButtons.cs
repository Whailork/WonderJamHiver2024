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
        RunManager.alertShown = false;
        RunManager.currentRun = 0;
        RunManager.roundNumber = 1;
        RunManager.newRun();
        
        SceneManager.LoadScene("sceneShip");
        SoundPlayer.instance.SetMusic(nextSong,1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
    }

   

    public void EncaisserGains(GameObject alerte)
    {
        RunManager.alertShown = false;
        GameValues.instance.encaisserGains();
        RunManager.currentRun = 0;
        RunManager.roundNumber = 0;
        
        SceneManager.LoadScene("sceneLaboratory");
        SoundPlayer.instance.SetMusic(nextSong,1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
        Destroy(alerte);
    }

    public void RetourLaboratoire(GameObject alerte)
    {
        RunManager.alertShown = false;
        RunManager.currentRun = 0;
        RunManager.roundNumber = 0;

        SceneManager.LoadScene("sceneLaboratory");
        GameValues.instance.resetRunInventory();
        SoundPlayer.instance.SetMusic(nextSong, 1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
        Destroy(alerte);
    }

    public void RetourMenu(GameObject alerte)
    {
        
        RunManager.alertShown = false;
        RunManager.currentRun = 0;
        RunManager.roundNumber = 0;

        SceneManager.LoadScene("mainMenuScene");
        SoundPlayer.instance.SetMusic(nextSong, 1F);
        SoundPlayer.instance.PlaySFX(btnSound,2);
        if (alerte.name != "MainMenu")
        {
            Destroy(alerte);
        }
    }
    public void ContinuerExploration(GameObject alerte)
    {
        RunManager.alertShown = false;
        RunManager.newRun();
        SoundPlayer.instance.PlaySFX(btnSound,2);
        
        Destroy(alerte);
    }

    
}
