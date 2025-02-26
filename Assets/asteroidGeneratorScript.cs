using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Color = System.Drawing.Color;
public class asteroidGeneratorScript : MonoBehaviour
{
    private int cooldown = 0;
    private Color color = new Color();

    private string form;

    private string motif;
    
    public GameObject asteroid;
    public RunManager runManager;

    Camera cam;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
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
    
    int assignColor()
    {
        Random random = new Random();
        int nb = random.Next(0, 100);
        
        switch (nb)
        {
            case 0:
                return 5;
                //setColor(Color.Purple);
                break;
            case > 0 and <= 4:
                return 4;
                //setColor(Color.Blue);
                break;
            case > 4 and <= 11:
                return 3;
                //setColor(Color.Green);
                break;
            case > 11 and <= 24:
                return 2;
                //setColor(Color.Yellow);
                break;
            case > 24 and <= 49:
                return 1;
                //setColor(Color.Orange);
                break;
            default:
                return 0;
                //setColor(Color.Red);
                break;
        }
    }

    int assignForm()
    {
        Random random = new Random();
        int nb = random.Next(0, 100);
        
        switch (nb)
        {
            case 0:
                return 5;
                //setForm("cercle");
                break;
            case > 0 and <= 4:
                return 4;
                //setForm("hexagone");
                break;
            case > 4 and <= 14:
                return 3;
                //setForm("losange");
                break;
            case > 14 and <= 24:
                return 2; 
                //setForm("carree");
                break;
            case > 24 and <= 49:
                return 1;// losange pour l'intant
                //setForm("pentagone");
                break;
            default:
                return 0;
                //setForm("triangle");
                break;
        }
    }

    int assignMotif()
    {
        Random random = new Random();
        int nb = random.Next(0, 4);
        
        // 0 = ligne
        // 1 = carreau
        // 2 = point
        // 3 = vague

        return nb;
    }

    private Vector3 generatePosition()
    {
        Random random = new Random();
        int nb = random.Next(0, 4);

        switch (nb)
        {
            case (0):
                //return new Vector3((float)(random.Next(-width / 2, width / 2)), height, 0f);
                return new Vector3((float)(random.Next(0, (int)width)) - width / 2, height/2, 0);

            case (1):
                //return new Vector3(width, (float)(random.Next(-height / 2, height / 2)), 0f);�
              
                return new Vector3(width/2, (float)(random.Next(0, (int)height) - height / 2), 0);

            case (2):
                // return new Vector3((float)(random.Next(-width / 2, width / 2)), -height, 0f);
                return new Vector3((float)(random.Next(0, (int)width)) - width / 2, -height/2, 0);

            case (3):
            
                return new Vector3(-width/2, (float)(random.Next(0, (int)height)) - height / 2, 0);
            
            default:
                return new Vector3(0,0,0);
        }
    }

    int nbRndAsteroide()
    {
        Random random = new Random();
        int nbRnd = random.Next(0, 200);
        switch (nbRnd)
        {
            case > 0 and <= 59:
                return 4;   // rouge - pois - cercle
            case > 59 and <= 119:
                return 1;   // jaune - pois - triangle
            case > 119 and <= 144:
                return 3;   // orange - carreau - pentagone
            case > 144 and <= 169:
                return 2;   // mauve - carreau = losange
            case > 169 and <= 184:
                return 5;   // vert - ligne - hexagone
            default: // case > 184 and <= 199:
                return 0;   // bleu - vague - carré
        }
    }

    public void generateAsteroid()
    {
        
        
        if (RunManager.enemiesLeft != 0 && RunManager.enemiesLive < RunManager.enemiesTogether && !RunManager.endGeneration)
        {
            Vector3 position = generatePosition();
            GameObject newAsteroid = Instantiate(asteroid, position,Quaternion.identity);
            newAsteroid.layer = 9;
            scriptAsteroide myAsteroide = newAsteroid.GetComponent<scriptAsteroide>();
            myAsteroide.createAsteroid(nbRndAsteroide());
            myAsteroide.setRunManager(runManager);
            myAsteroide.setPosition(position);
            myAsteroide.setRangeLimit((float)Math.Sqrt((float)Math.Pow(height / 2, 2) + (float)Math.Pow(width / 2, 2)));
            RunManager.enemiesLive++;
            RunManager.enemiesLeft--;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (cooldown == 0)
        {
            generateAsteroid();
            cooldown = 30;
        }
        else
        {
            cooldown--;
        }
    }
}
