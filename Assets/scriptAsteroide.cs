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
    public int vie;

    public Sprite[] spriteArray;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setColor(Color c)
    {
        color = c;

        //Color newColor = c;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        UnityEngineColor newColor = new UnityEngine.Color(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);

        spriteRenderer.color = newColor;
    }
    Color getColor()
    {
        return color;
    }
    void setForm(string f)
    {
        form = f;
        changeForm(f);
    }

    string getForm()
    {
        return form;
    }
    
    void setMotif(string m)
    {
        motif = m;
        changeMotif(m);
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

    void changeColor(Color c)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        UnityEngineColor newColor = new UnityEngine.Color(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        
        spriteRenderer.color = newColor;
    }

    void changeMotif(string motif)
    {
        Sprite newSprite = null;
        
        switch (form)
        {
            case "ligne":
                break;
            case "vague":
                break;
            case "point":
                break;
            case "carree":
                break;
            case "carreau":
                break;
            default:
                Console.WriteLine("form does not exist");
                break;
        }
        
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
    }

    void changeForm(string form)
    {
        Sprite newSprite = null;
        
        switch (form)
        {
            case "cercle":
                newSprite = spriteArray[0];
                break;
            case "hexagone":
                newSprite = spriteArray[1];
                break;
            case "losange":
                break;
            case "carree":
                newSprite = spriteArray[2];
                break;
            case "pentagone":
                break;
            case "triangle":
                newSprite = spriteArray[3];
                break;
            default:
                Console.WriteLine("form does not exist");
                break;
        }
        
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        vie--;
        if (vie <= 0)
        {
            Destroy(this);
        }
        
        
    }
}
