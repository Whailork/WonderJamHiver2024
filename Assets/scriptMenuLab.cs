using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TMPro;
using UnityEngine.UI;

public class scriptMenuLab : MonoBehaviour
{
    int choice = 0;
    //int numberMaxAnimals = GameValues.instance.recettesAnimaux.Count;
  int numberMaxAnimals = 25;
  private bool canCraft;
    public TMP_Text tagAnimal;
    //public TextMeshProUGUI tagAnimal;
    //public TMPro.TextMeshProUGUI tagAnimal;
    //public Textmeshpro tagAnimal;
    string strTagAnimal;
    private Ressource requiredColor;
    private Ressource requiredShape;
    private Ressource requiredMotif;
    public GameObject image;
    public Sprite[] imagesAnimaux;
    
    public GameObject colorAdd;
    public GameObject shapeAdd;
    public GameObject motifAdd;
    public GameObject spliceBtn;
    
    public GameObject colorPlaceOlder;
    public GameObject shapePlaceOlder;
    public GameObject motifPlaceOlder;
    public GameObject nbTexteCouleur;
    public GameObject nbTexteMotif;
    public GameObject nbTexteForme;

    private bool colorPlaced = false;
    private bool shapePlaced = false;
    private bool motifPlaced = false;
    public Sprite[] arraySprite;

    public Sprite[] arrayMotif;

    public Sprite[] arrayCouleurs;
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
        if (choice != numberMaxAnimals-1)
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
            choice = numberMaxAnimals-1;
        }
        choose(choice);
        
    }

    public void choose(int choice)
    {
        
        tagAnimal.SetText(GameValues.instance.recettesAnimaux[choice].animal);
        requiredColor = GameValues.instance.recettesAnimaux[choice].requiredColor;
        requiredShape = GameValues.instance.recettesAnimaux[choice].requiredShape;
        requiredMotif = GameValues.instance.recettesAnimaux[choice].requiredMotif;
        
        if (choice < imagesAnimaux.Length)
        {
            image.GetComponent<Image>().sprite = imagesAnimaux[choice];
        }

        switch (requiredColor.name)
        {
            case "Red":
                colorPlaceOlder.GetComponent<Image>().sprite = arrayCouleurs[0];
                break;
            case "Orange":
                colorPlaceOlder.GetComponent<Image>().sprite = arrayCouleurs[1];
                break;
            case "Yellow":
                colorPlaceOlder.GetComponent<Image>().sprite = arrayCouleurs[2];
                break;
            case "Green":
                colorPlaceOlder.GetComponent<Image>().sprite = arrayCouleurs[3];
                break;
            case "Blue":
                colorPlaceOlder.GetComponent<Image>().sprite = arrayCouleurs[4];
                break;
            case "Purple":
                colorPlaceOlder.GetComponent<Image>().sprite = arrayCouleurs[5];
                break;
                
        }
        
        switch (requiredShape.name)
        {
            case "Triangle":
                shapePlaceOlder.GetComponent<Image>().sprite = arraySprite[0];
                break;
            case "Pentagone":
                shapePlaceOlder.GetComponent<Image>().sprite = arraySprite[1];
                break;
            case "Carre":
                shapePlaceOlder.GetComponent<Image>().sprite = arraySprite[2];
                break;
            case "Losange":
                shapePlaceOlder.GetComponent<Image>().sprite = arraySprite[3];
                break;
            case "Hexagone":
                shapePlaceOlder.GetComponent<Image>().sprite = arraySprite[4];
                break;
            case "Cercle":
                shapePlaceOlder.GetComponent<Image>().sprite = arraySprite[5];
                break;
        }

        switch (requiredMotif.name)
        {
            case "Ligne":
                motifPlaceOlder.GetComponent<Image>().sprite = arrayMotif[0];
                break;
            case "Vague":
                motifPlaceOlder.GetComponent<Image>().sprite = arrayMotif[1];
                break;
            case "Carreau":
                motifPlaceOlder.GetComponent<Image>().sprite = arrayMotif[2];
                break;
            case "Pois":
                motifPlaceOlder.GetComponent<Image>().sprite = arrayMotif[3];
                break;
        }

        changeNumbers(choice);
        checkForRessources();
    }

    private void changeNumbers(int choice)
    {
        List<Combinaison> animalRecette = GameValues.instance.recettesAnimaux;
        nbTexteCouleur.GetComponent<TextMeshProUGUI>().text = animalRecette[choice].requiredColor.number.ToString();
        nbTexteMotif.GetComponent<TextMeshProUGUI>().text = animalRecette[choice].requiredMotif.number.ToString();
        nbTexteForme.GetComponent<TextMeshProUGUI>().text = animalRecette[choice].requiredShape.number.ToString();

        nbTexteCouleur.GetComponent<TextMeshProUGUI>().faceColor = Color.red;
        nbTexteCouleur.GetComponent<TextMeshProUGUI>().outlineColor = Color.white;
        TextMeshPro m_TextMeshPro = GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();
    }

    private void checkForRessources()
    {
        bool notEnough = false;
        if (GameValues.instance.getItem(requiredColor.name, GameValues.instance.inventory) <
            requiredColor.number)
        {
            notEnough = true;
            colorAdd.GetComponent<Image>().color = Color.red;
            colorAdd.GetComponent<Button>().enabled = false;
        }
        else
        {
            colorAdd.GetComponent<Image>().color = Color.green;
            colorAdd.GetComponent<Button>().enabled = true;
        }
        
        if (GameValues.instance.getItem(requiredShape.name, GameValues.instance.inventory) <
            requiredColor.number)
        {
            notEnough = true;
            shapeAdd.GetComponent<Image>().color = Color.red;
            shapeAdd.GetComponent<Button>().enabled = false;
        }
        else
        {
            shapeAdd.GetComponent<Image>().color = Color.green;
            shapeAdd.GetComponent<Button>().enabled = true;
        }
        
        if (GameValues.instance.getItem(requiredMotif.name, GameValues.instance.inventory) <
            requiredColor.number)
        {
            notEnough = true;
            motifAdd.GetComponent<Image>().color = Color.red;
            motifAdd.GetComponent<Button>().enabled = false;
        }
        else
        {
            motifAdd.GetComponent<Image>().color = Color.green;
            
            motifAdd.GetComponent<Button>().enabled = true;
        }

        if (!notEnough)
        {
            canCraft = true;
            spliceBtn.GetComponent<Button>().enabled = true;
            spliceBtn.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            spliceBtn.GetComponent<Button>().enabled = false;
            spliceBtn.GetComponent<Image>().color = Color.red;
        }
    }

    public void colorAddClicked()
    {
        
        colorAdd.GetComponent<Image>().color = Color.gray;
        colorAdd.GetComponent<Button>().enabled = false;
        colorPlaced = true;
        checkForSplice();
    }
    public void shapeAddClicked()
    {
       
        shapeAdd.GetComponent<Image>().color = Color.gray;
        shapeAdd.GetComponent<Button>().enabled = false;
        shapePlaced = true;
        checkForSplice();
    }
    public void motifAddClicked()
    {
       
        motifAdd.GetComponent<Image>().color = Color.gray;
        motifAdd.GetComponent<Button>().enabled = false;
        motifPlaced = true;
        checkForSplice();
    }

    private void checkForSplice()
    {
        if (!canCraft)
        {
            spliceBtn.GetComponent<Button>().enabled = false;
            spliceBtn.GetComponent<Image>().color = Color.red;
        }
        else
        {
            if (canCraft && motifPlaced && shapePlaced && colorPlaced)
            {
                spliceBtn.GetComponent<Button>().enabled = true;
                spliceBtn.GetComponent<Image>().color = Color.green;
            }
            else
            {
                spliceBtn.GetComponent<Button>().enabled = false;
                spliceBtn.GetComponent<Image>().color = Color.grey;
            }  
        }
        
    }

    public void spliceBtnClicked()
    {
        GameValues.instance.removeItem(requiredMotif.name,requiredMotif.number,GameValues.instance.inventory);
        GameValues.instance.removeItem(requiredShape.name,requiredShape.number,GameValues.instance.inventory);
        GameValues.instance.removeItem(requiredColor.name,requiredColor.number,GameValues.instance.inventory);
        canCraft = false;
        colorPlaced = false;
        shapePlaced = false;
        motifPlaced = false;
        checkForRessources();
        checkForSplice();
        GameValues.instance.updateScore(1);
    }
    

}

