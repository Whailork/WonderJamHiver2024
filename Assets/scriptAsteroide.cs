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
                newSprite = ChangeSpriteToCircle();
                break;
            case "hexagone":
                break;
            case "losange":
                break;
            case "carree":
                
                float taille = 5f;
                
                newSprite = Sprite.Create(new Texture2D(1, 1),
                    new Rect(0, 0, taille, taille),
                    new Vector2(0.5f, 0.5f));
                
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
    
    Sprite ChangeSpriteToCircle()
    {
        Sprite newSprite = null;
        // Ensure the object has a SpriteRenderer component
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Create a new sprite representing a circle
            Texture2D texture =circleTexture(64, getColor());

            newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        }
        else
        {
            Debug.LogError("SpriteRenderer not assigned.");
        }

        return newSprite;
    }

    // Function to create a simple circle texture
    Texture2D circleTexture(int size, Color color)
    {
        Texture2D texture = new Texture2D(size, size);
        Vector2 center = new Vector2(size / 2, size / 2);
        float radius = size / 2;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Color pixelColor = (new Vector2(x, y) - center).magnitude < radius ? color : Color.Transparent;
                
                float r = pixelColor.R / 255f;
                float g = pixelColor.G / 255f;
                float b = pixelColor.B / 255f;
                float a = pixelColor.A / 255f;

                UnityEngineColor col = new UnityEngine.Color(r, g, b, a);
                
                texture.SetPixel(x, y, col);
            }
        }

        texture.Apply();
        return texture;
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
