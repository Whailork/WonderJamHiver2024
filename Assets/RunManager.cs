using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemiesLeft { get; set; }
    public int currentRun = 0;
    public int baseEnemiNb;
   
    
    void Start()
    {
        newRun();
    }

    public void newRun()
    {
        currentRun++;
        enemiesLeft = baseEnemiNb + currentRun - 1;
        if (currentRun == 1)
        {
            GameValues.instance.createInventory(GameValues.instance.currentRunInventory);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
