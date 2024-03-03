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

    private Vector3 position;

    private float rangeLimit;

    public int vie;

    //public Sprite[] spriteArray;
    
    public Sprite[] arrayAsteroides;
    
    public Sprite[] adnColors;

    private Script imageADN;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setPattern();
    }

    void setColor(Color c)
    {
        color = c;

        // color = colorArray[c];
        // Color myColor = color;
        // SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // UnityEngineColor newColor = new UnityEngine.Color(myColor.R / 255f, myColor.G / 255f, myColor.B / 255f, myColor.A / 255f);
        // spriteRenderer.color = newColor;
    }
    Color getColor()
    {
        return color;
    }
    void setForm(string f)
    {
        form = f;
        
        // SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = spriteArray[f];
    }

    string getForm()
    {
        return form;
    }
    
    void setMotif(string m)
    {
        motif = m;
        
        // SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = spriteArray[0];
    }

    string getMotif()
    {
        return motif;
    }

    public void createAsteroid(int nbRndAsteroid)
    {
        Color c = new Color();
        string m = "";
        string f = "";
        
        switch (nbRndAsteroid)
        {
            case 0 :
                c = Color.Blue;
                m = "vague";
                f = "carree";
                break;
            case 1 :
                c = Color.Yellow;
                m = "pois";
                f = "triangle";
                break;
            case 2 :
                c = Color.Purple;
                m = "carreau";
                f = "losange";
                break;
            case 3 :
                c = Color.Orange;
                m = "carreau";
                f = "pentagone";
                break;
            case 4 :
                c = Color.Red;
                m = "pois";
                f = "cercle";
                break;
            case 5 :
                c = Color.Green;
                m = "ligne";
                f = "hexagone";
                break;
        } 
        
        setColor(c);
        setMotif(m);
        setForm(f);
        
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = arrayAsteroides[nbRndAsteroid];
    }
    
    // Update is called once per frame
    void Update()
    {
        updatePattern();
        position = transform.position;
        if (outOfBound())
        {
            RunManager.enemiesLive--;
            RunManager.enemiesLeft++;
            Destroy(this.gameObject);
        }

    }

    private void dropLoot()
    {
        Random random = new Random();
        int colorRnd = random.Next(0, 100);
        if (colorRnd >= 50)
        {
            Debug.Log("drop" + color.Name);
            GameValues.instance.addItem(color.Name,1, GameValues.instance.currentRunInventory);

            afficheLoot();
        }
        Random randomf = new Random();
        int formeRnd = randomf.Next(0, 100);
        if (formeRnd >= 50)
        {
            Debug.Log("drop" + form);
            GameValues.instance.addItem(form,1,GameValues.instance.currentRunInventory);
            
            afficheLoot();
        }
        Random randomM = new Random();
        int motifRnd = randomM.Next(0, 100);
        if (motifRnd >= 50)
        {
            Debug.Log("drop" + motif);
            GameValues.instance.addItem(motif,1,GameValues.instance.currentRunInventory);
            
            afficheLoot();
        }

    }

    public void afficheLoot()
    {
        
    }
    public void takeDamage()
    {
        vie--;
        Debug.Log("asteroid Damage");
        if (vie <= 0)
        {
            dropLoot();
            RunManager.enemiesLive--;
            RunManager.enemiesCleared++;
            Destroy(this.gameObject);
        }
        
        
    }

    public void setPattern()
    {
        direction = new Vector2(-1f * position.x, -1f * position.y);

        Random random = new Random();
        int rnd = random.Next(0, 3);

        switch (rnd)
        {
            case (0):
                pattern = "straight";
                break;
            case (1):
                pattern = "sinus";
                break;
            case (2):
                
                pattern = "parabol";
                break;


        }
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
                rb.AddForce(new Vector2((float)direction.x, (float)(20.0f * Math.Cos(5.0f * (float)Time.time)) + (float)direction.y));
              
                rb.velocity = rb.velocity.normalized * speed;
                break;


            case ("parabol"):

                rb.AddForce(new Vector2((float)direction.x + 1f , ((float)(-1f * 3f * Time.time)) + 1f + (float)direction.y));
                rb.velocity = rb.velocity.normalized * speed;
                break;
        }
           
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
    }


    public void setRangeLimit(float limit)
    {
        this.rangeLimit = limit;
    }

    private bool outOfBound()
    {
        return position.magnitude > rangeLimit;
    }

}
