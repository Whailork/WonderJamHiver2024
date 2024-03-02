using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Drawing;
using Color = System.Drawing.Color;
using UnityEngineColor = UnityEngine.Color;

public class scriptAsteroide : MonoBehaviour
{
    private Color color = new Color();

    private string form;

    private string motif;

    public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setColor(Color c)
    {
        color = c;
    }

    Color getColor()
    {
        return color;
    }
    void setForm(string f)
    {
        form = f;
        changeForm();
    }

    void changeForm()
    {
        Sprite newSprite = null;
        
        switch (getForm())
        {
            case "cercle":
                newSprite = 
                break;
            case "hexagone":
                break;
            case "losange":
                break;
            case "carree":
                newSprite = spriteArray[0];
                break;
            case "pentagone":
                break;
            case "triangle":
                break;
            default:
                Console.WriteLine("form does not exist");
                break;
        }
        
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
    }

    string getForm()
    {
        return form;
    }
    
    void setMotif(string m)
    {
        motif = m;
    }

    string getMotif()
    {
        return motif;
    }

    public void createAsteroid(Color c, string m, string f)
    {
        setColor(c);
        setMotif(m);
        setForm(f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
