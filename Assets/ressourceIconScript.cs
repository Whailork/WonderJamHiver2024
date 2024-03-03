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
    void Start()
    {
        nbRessource.text = GameValues.instance.getItem(ressourceName, GameValues.instance.currentRunInventory) + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
