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
                // color = Color.orange;
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
                return 1;
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

    public void generateAsteroid()
    {
        Debug.Log("spawn asteroid");
        GameObject newAsteroid = Instantiate(asteroid, new Vector3(0, 0, 0),Quaternion.identity);
        scriptAsteroide myAsteroide = newAsteroid.GetComponent<scriptAsteroide>();
        myAsteroide.createAsteroid(assignColor(), assignMotif(), assignForm());
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
            cooldown = 60;
        }
        else
        {
            cooldown--;
        }
    }
}
