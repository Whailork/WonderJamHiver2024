using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ressourceIconScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text nbRessource;
    public string ressourceName;
    public bool currentRun;
    void Start()
    {
        /*
        if (currentRun)
        {
            nbRessource.text = GameValues.instance.getItem(ressourceName, GameValues.instance.currentRunInventory) + "";
        }
        else
        {
            nbRessource.text = GameValues.instance.getItem(ressourceName, GameValues.instance.inventory) + "";
        }*/
       
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRun)
        {
            nbRessource.text = GameValues.instance.getItem(ressourceName, GameValues.instance.currentRunInventory) + "";
        }
        else
        {
            nbRessource.text = GameValues.instance.getItem(ressourceName, GameValues.instance.inventory) + "";
        }
    }
}
