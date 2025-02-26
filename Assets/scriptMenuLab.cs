using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Mime;
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
    public AudioClip clickBtnFx;
    public AudioClip spliceFx;
    public AudioClip addBtnFx;
    
    public GameObject colorAdd;
    public GameObject shapeAdd;
    public GameObject motifAdd;
    public GameObject spliceBtn;
    
    public GameObject colorPlaceOlder;
    public GameObject shapePlaceOlder;
    public GameObject motifPlaceOlder;
    
    // nb d'items required de chaque
    public GameObject nbTexteCouleur;
    public GameObject nbTexteMotif;
    public GameObject nbTexteForme;
    
    public GameObject scoreText;
    public GameObject backGroundScoreText;


    public GameObject CreatedCheck;
    
    private bool colorPlaced = false;
    private bool shapePlaced = false;
    private bool motifPlaced = false;
   
    public Sprite[] arraySprite;

    public Sprite[] arrayMotif;

    public Sprite[] arrayCouleurs;

    public GameObject spinner;
    public Canvas canvas;
    public Animator animator;
    private GameObject spinnerObject;


    // Start is called before the first frame update
    void Start()
    {
        //tagAnimal = GameObject.Find("TagAnimal/Canvas");
        //tagAnimal.GetComponent<TagAnimal>();
        //tagAnimal.text = "oui";
        choose(choice);
        adjustScore();
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
        SoundPlayer.instance.PlaySFX(clickBtnFx,2);
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
        SoundPlayer.instance.PlaySFX(clickBtnFx,2);
        
    }

    public void choose(int choice)
    {
        
        tagAnimal.SetText(GameValues.instance.recettesAnimaux[choice].animal);
        requiredColor = GameValues.instance.recettesAnimaux[choice].requiredColor;
        requiredShape = GameValues.instance.recettesAnimaux[choice].requiredShape;
        requiredMotif = GameValues.instance.recettesAnimaux[choice].requiredMotif;
        //on affiche le check ou pas
        if (GameValues.instance.recettesAnimaux[choice].timesCrafted > 0)
        {
            CreatedCheck.GetComponent<Image>().color = Color.white;
        }
        else
        {
            CreatedCheck.GetComponent<Image>().color = Color.black;
        }
        
        if (choice < imagesAnimaux.Length)
        {
            image.GetComponent<Image>().sprite = imagesAnimaux[choice];
            CreatedCheck.GetComponent<Image>().sprite = imagesAnimaux[choice];
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
    }

    private void adjustScore()
    {
        int score = GameValues.instance.score;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        
        float widthScore = scoreText.GetComponent<RectTransform>().sizeDelta.x + 140;
        float widthString = scoreText.GetComponent<TextMeshProUGUI>().GetPreferredValues().x;
        
        //Resize scoreTest
        RectTransform rectTransformNb = scoreText.GetComponent<RectTransform>();
        rectTransformNb.sizeDelta = new Vector2(widthString, rectTransformNb.sizeDelta.y);
        
        // Resize background
        RectTransform rectTransformBackground = backGroundScoreText.GetComponent<RectTransform>();
        rectTransformBackground.sizeDelta = new Vector2(widthScore, rectTransformBackground.sizeDelta.y);
    }

    private void checkForRessources()
    {
        bool notEnough = false;
        if (GameValues.instance.getItem(requiredColor.name, GameValues.instance.inventory) < requiredColor.number)
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
        
        if (GameValues.instance.getItem(requiredShape.name, GameValues.instance.inventory) < requiredShape.number)
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
        
        if (GameValues.instance.getItem(requiredMotif.name, GameValues.instance.inventory) < requiredMotif.number)
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
        SoundPlayer.instance.PlaySFX(addBtnFx,2);
        checkForSplice();
    }
    public void shapeAddClicked()
    {
       
        shapeAdd.GetComponent<Image>().color = Color.gray;
        shapeAdd.GetComponent<Button>().enabled = false;
        shapePlaced = true;
        SoundPlayer.instance.PlaySFX(addBtnFx,2);
        checkForSplice();
    }
    public void motifAddClicked()
    {
       
        motifAdd.GetComponent<Image>().color = Color.gray;
        motifAdd.GetComponent<Button>().enabled = false;
        motifPlaced = true;
        SoundPlayer.instance.PlaySFX(addBtnFx,2);
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
        if (spinnerObject != null)
        {
            Destroy(spinnerObject);
        }
        //on fait afficher le check ou pas

        GameValues.instance.removeItem(requiredMotif.name,requiredMotif.number,GameValues.instance.inventory);
        GameValues.instance.removeItem(requiredShape.name,requiredShape.number,GameValues.instance.inventory);
        GameValues.instance.removeItem(requiredColor.name,requiredColor.number,GameValues.instance.inventory);
        canCraft = false;
        colorPlaced = false;
        shapePlaced = false;
        motifPlaced = false;
        checkForRessources();
        checkForSplice();

        GameValues.instance.updateScore(choice);
        GameValues.instance.recettesAnimaux[choice].timesCrafted++;
        
        if (GameValues.instance.recettesAnimaux[choice].timesCrafted > 0)
        {
            CreatedCheck.GetComponent<Image>().color = Color.white;
        }
        else
        {
            CreatedCheck.GetComponent<Image>().color = Color.black;
        }
        //SoundPlayer.instance.PlaySFX(spliceFx,2);

        //spinnerObject = Instantiate(spinner, image.transform.position, Quaternion.identity, canvas.transform);
        //animator.SetTrigger("Splice");
        


        adjustScore();
    }
    

}

