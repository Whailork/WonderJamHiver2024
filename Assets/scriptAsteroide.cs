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

    private Rigidbody2D rb;

    public string pattern;

    private Vector2 direction;

    public float speed = 5f;

    public int vie;

    public Sprite[] spriteArray;
    
    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
        //direction = new Vector2((float)random.Next(0, 100) / 100, (float)random.Next(0, 100) / 100);
        direction = new Vector2(0.866f, 0.5f);
        rb = GetComponent<Rigidbody2D>();
        setPattern();
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
                newSprite = spriteArray[4];
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
        updatePattern();
    }

    private void dropLoot()
    {
        Random random = new Random();
        int colorRnd = random.Next(0, 100);
        if (colorRnd >= 50)
        {
            GameValues.instance.addItem(color.Name,1);
        }

        int formeRnd = random.Next(0, 100);
        if (formeRnd >= 50)
        {
            GameValues.instance.addItem(form,1);
        }
        int motifRnd = random.Next(0, 100);
        if (motifRnd >= 50)
        {
            GameValues.instance.addItem(motif,1);
        }

    }
    public void takeDamage()
    {
        vie--;
        Debug.Log("asteroid Damage");
        if (vie <= 0)
        {
            GameValues.instance.incrementNbGenes(1);
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
