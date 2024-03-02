using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int enemiesLeft { get; set; }
    public static int enemiesCleared = 0;
    public int currentRun = 0;
    public int baseEnemiNb;
    public int enemiInRun = 0;
    public GameObject newRunAlert;
    private bool alertShown = false;
   
    
    void Start()
    {
        newRun();
    }

    public void newRun()
    {
        currentRun++;
        enemiInRun = baseEnemiNb + currentRun - 1;
        enemiesLeft = enemiInRun;
        enemiesCleared = 0;
        if (currentRun == 1)
        {
            GameValues.instance.createInventory(GameValues.instance.currentRunInventory);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (enemiesCleared == enemiInRun && !alertShown)
        {
            askForNewRun();
        }
    }

    public void askForNewRun()
    {
        alertShown = true;
        GameObject alerte = Instantiate(newRunAlert, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
