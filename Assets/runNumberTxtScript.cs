using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class runNumberTxtScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool deathAlert;
    void Awake()
    {
        if (!deathAlert)
        {
            GetComponent<TextMeshProUGUI>().text = RunManager.roundNumber-1 + "";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = RunManager.roundNumber + "";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
