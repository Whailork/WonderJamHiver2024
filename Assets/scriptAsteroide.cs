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

    private Rigidbody2D rb;

    public string pattern;

    private Vector2 direction;

    public float speed = 5f;

    public int vie;

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
        Random random = new Random();
        //direction = new Vector2((float)random.Next(0, 100) / 100, (float)random.Next(0, 100) / 100);
        direction = new Vector2(0.866f, 0.5f);
        rb = GetComponent<Rigidbody2D>();
        setPattern();
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
        spriteRenderer.sprite = spriteArray[0];
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
        updatePattern();
    }

    private void dropLoot()
    {
        Random random = new Random();
        int colorRnd = random.Next(0, 100);
        if (colorRnd >= 50)
        {
            GameValues.instance.addItem(color.Name,1, GameValues.instance.inventory);
        }

        int formeRnd = random.Next(0, 100);
        if (formeRnd >= 50)
        {
            GameValues.instance.addItem(form,1,GameValues.instance.inventory);
        }
        int motifRnd = random.Next(0, 100);
        if (motifRnd >= 50)
        {
            GameValues.instance.addItem(motif,1,GameValues.instance.inventory);
        }

    }
    public void takeDamage()
    {
        vie--;
        Debug.Log("asteroid Damage");
        if (vie <= 0)
        {
            GameValues.instance.incrementNbGenes(1);
            RunManager.enemiesCleared++;
            Destroy(this.gameObject);
        }
        
        
    }

    public void setPattern()
    {
        pattern = "parabol";
    } 
    
    public void updatePattern()
    {
        switch (pattern)
        {
            case ("straight"):
                //rb.AddForce(new Vector2((float)random.Next(0, 100) / 100, (float)random.Next(0, 100) / 100));
                rb.AddForce(direction);
                rb.velocity = rb.velocity.normalized * speed;
                break;

            case ("sinus"):
             
                //equation traveling wave https://labs.phys.utk.edu/mbreinig/phys221core/modules/m11/traveling_waves.html
                rb.AddForce(new Vector2((float)direction.x, (float)(2.0f * Math.Cos(5.0f * (float)Time.time)) + (float)direction.y));
              
                rb.velocity = rb.velocity.normalized * speed;
                break;


            case ("parabol"):

                rb.AddForce(new Vector2((float)direction.x + 5f , ((float)(-1f * 3f * Time.time)) + 5f + (float)direction.y));

                rb.velocity = rb.velocity.normalized * speed;
                break;
        }
           
    }

}
