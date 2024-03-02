using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TMPro;

public class scriptMenuLab : MonoBehaviour
{
    int choice = 0;
    int numberMaxAnimals = 1;
    public TMP_Text tagAnimal;
    //public TextMeshProUGUI tagAnimal;
    //public TMPro.TextMeshProUGUI tagAnimal;
    //public Textmeshpro tagAnimal;
    string strTagAnimal;
    // Start is called before the first frame update
    void Start()
    {
        //tagAnimal = GameObject.Find("TagAnimal/Canvas");
        //tagAnimal.GetComponent<TagAnimal>();
        //tagAnimal.text = "oui";
        choose(choice);
    }

    // Update is called once per frame
    void Update()
    {
       // tagAnimal.text = strTagAnimal;
    }

    public void Hello()
    {
        Debug.Log("wassup");
    }

    public void counterUp()
    {
        if (choice != numberMaxAnimals)
        {
            choice += 1;
        }
        else
        {
            choice = 0;
        }
        choose(choice);
    }

    public void counterDown()
    {
        if (choice != 0)
        {
            choice -= 1;
        }
        else
        {
            choice = numberMaxAnimals;
        }
        choose(choice);
    }

    public void choose(int choice)
    {
        switch (choice)
        {
            case 0:
                tagAnimal.SetText("Flamand");
                // tagAnimal.text = "Flamand";
                //strTagAnimal = "Flamand";
                break;

            case 1:
                //tagAnimal.text = "ours";
                tagAnimal.SetText("ours");
                //strTagAnimal = "ours";
                break;
        }
    }

}
