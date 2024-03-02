using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Drawing;
using UnityEngine.UIElements;
using Color = System.Drawing.Color;
using UnityEngineColor = UnityEngine.Color;

public class scriptAsteroide : MonoBehaviour
{
    private Color color = new Color();

    private string form;

    private string motif;

    public Sprite[] spriteArray;
    public Color[] colorArray =
    {
        Color.Red,
        Color.Orange,
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Purple
    };
    public Sprite[] motifArray;
    //public Image[] motifArray {};
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setColor(int c)
    {
        color = colorArray[c];

        Color myColor = color;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        UnityEngineColor newColor = new UnityEngine.Color(myColor.R / 255f, myColor.G / 255f, myColor.B / 255f, myColor.A / 255f);
        spriteRenderer.color = newColor;
    }

    Color getColor()
    {
        return color;
    }
    void setForm(int f)
    {
        form = spriteArray[f].name;
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[f];
    }

    string getForm()
    {
        return form;
    }
    
    void setMotif(int m)
    {
        //motif = m;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[m];
    }

    string getMotif()
    {
        return motif;
    }

    public void createAsteroid(int c, int m, int f)
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
