using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int enemiesLeft { get; set; }
    public static int enemiesCleared = 0;
    public static int currentRun = 0;
    public static int baseEnemiNb = 5;
    public static int enemiInRun = 0;
    public GameObject newRunAlert;
    public GameObject newDeadAlert;
    public static int roundNumber = 1;
    public static int enemiesTogether = 0;
    public static int enemiesLive = 0;
    private bool alertShown = false;
    public GameObject canvas;
    public static bool endGeneration = false;

    //public GameObject starship;
   
    
    void Start()
    {
      //  GameObject alerte = Instantiate(newRunAlert, new Vector3(0, 0, 0), Quaternion.identity,canvas.transform);
        newRun();
    }

    public static void newRun()
    {
        currentRun++;
        if (currentRun == 1)
        {
            GameValues.instance.createInventory(GameValues.instance.currentRunInventory);
        }

        switch (roundNumber)
        {
            case 1:
                enemiInRun = 4;
                enemiesLeft = enemiInRun;
                enemiesCleared = 0;
                enemiesTogether = 2;
                enemiesLive = 0;
                break;
            case 2:
                enemiInRun = 7;
                enemiesLeft = enemiInRun;
                enemiesCleared = 0;
                enemiesTogether = 3;
                enemiesLive = 0;
                break;
            case 3:
                enemiInRun = 10;
                enemiesLeft = enemiInRun;
                enemiesCleared = 0;
                enemiesTogether = 5;
                enemiesLive = 0;
                break;
            case 4:
                enemiInRun = 12;
                enemiesLeft = enemiInRun;
                enemiesCleared = 0;
                enemiesTogether = 7;
                enemiesLive = 0;
                break;
        }
        /*
        currentRun++;
        enemiInRun = baseEnemiNb + currentRun - 1;
        enemiesLeft = enemiInRun;
        enemiesCleared = 0;
        if (currentRun == 1)
        {
            GameValues.instance.createInventory(GameValues.instance.currentRunInventory);
        }*/

    }
    // Update is called once per frame
    void Update()
    {
        if (enemiesCleared == enemiInRun && !alertShown)
        {
            askForNewRun();
        }

        /*if (starship.shipMouvement.vie == 0)
        {
            askAfterDead();
        }*/
    }

    public void askForNewRun()
    {
        roundNumber++;
        alertShown = true;
        GameObject alerte = Instantiate(newRunAlert, new Vector3(0, 0, 0), Quaternion.identity,canvas.transform);
    }

    public void askAfterDead()
    {
        roundNumber = 1;
        alertShown = true;
        Debug.Log("miam");
        GameObject alerte = Instantiate(newDeadAlert, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);
        alerte.SetActive(true);
    }
}
