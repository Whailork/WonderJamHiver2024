using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Drawing;
using System.Net.Mime;
using UnityEngine.UIElements;
using Color = System.Drawing.Color;
using UnityEngineColor = UnityEngine.Color;

public class scriptAsteroide : MonoBehaviour
{
    public Canvas canvas;
    private Color color = new Color();

    private string form;
    public RunManager runManager;
    

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

    private Sprite imageADN;
    
    public GameObject adnImage;

    public GameObject test;
    
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

    public void setRunManager(RunManager runManager)
    {
        this.runManager = runManager;
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
                m = "Vague";
                f = "Carree";
                break;
            case 1 :
                c = Color.Yellow;
                m = "Pois";
                f = "Triangle";
                break;
            case 2 :
                c = Color.Purple;
                m = "Carreau";
                f = "Losange";
                break;
            case 3 :
                c = Color.Orange;
                m = "Carreau";
                f = "Pentagone";
                break;
            case 4 :
                c = Color.Red;
                m = "Pois";
                f = "Cercle";
                break;
            case 5 :
                c = Color.Green;
                m = "Ligne";
                f = "Hexagone";
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
            if (!RunManager.endGeneration)
            {
                RunManager.enemiesLeft++;
            }
            RunManager.enemiesLive--;
            
           Destroy(this.gameObject);
        }

    }

    private void dropLoot(Vector3 position)
    {
        Random random = new Random();
        int colorRnd = random.Next(0, 100);
        bool lootEarned = false;
        if (colorRnd >= 50)
        {
            Debug.Log("drop" + color.Name);
            GameValues.instance.addItem(color.Name,1, GameValues.instance.currentRunInventory);

            lootEarned = true;
        }
        Random randomf = new Random();
        int formeRnd = randomf.Next(0, 100);
        if (formeRnd >= 50)
        {
            Debug.Log("drop" + form);
            GameValues.instance.addItem(form,1,GameValues.instance.currentRunInventory);

            lootEarned = true;
        }
        Random randomM = new Random();
        int motifRnd = randomM.Next(0, 100);
        if (motifRnd >= 50)
        {
            Debug.Log("drop" + motif);
            GameValues.instance.addItem(motif,1,GameValues.instance.currentRunInventory);

            lootEarned = true;
        }

        if (lootEarned)
        {
            afficheLoot(color.Name,position);
        }

    }

    public void afficheLoot(string loot,Vector3 position)
    {
        // Image invisible
        GameObject imageLoot = Instantiate(adnImage, position, Quaternion.identity);
            imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[6];
            imageLoot.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
        
        switch (loot)
        {
            case "Red":
                imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[0];
                break;
            case "Orange":
                imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[1];
                break;
            case "Yellow":
                imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[2];
                break;
            case "Green":
                imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[3];
                break;
            case "Blue":
                imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[4];
                break;
            case "Purple":
                imageLoot.GetComponent<SpriteRenderer>().sprite = adnColors[5];
                break;
        }
    }
    public void takeDamage()
    {
        vie--;
        Debug.Log("asteroid Damage");
        if (vie <= 0)
        {
            dropLoot(this.gameObject.transform.position);
            RunManager.enemiesLive--;
            runManager.enemiKilled();
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
