using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Color = System.Drawing.Color;
public class asteroidGeneratorScript : MonoBehaviour
{
    
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
    
    Color assignColor()
    {
        Random random = new Random();
        int nb = random.Next(0, 100);
        
        switch (nb)
        {
            case 0:
                setColor(Color.Purple);
                break;
            case > 0 and <= 4:
                setColor(Color.Blue);
                break;
            case > 4 and <= 11:
                setColor(Color.Green);
                break;
            case > 11 and <= 24:
                setColor(Color.Yellow);
                break;
            case > 24 and <= 49:
                // color = Color.orange;
                setColor(Color.Orange);
                break;
            default:
                setColor(Color.Red);
                break;
        }

        return getColor();
    }

    string assignForm()
    {
        Random random = new Random();
        int nb = random.Next(0, 100);
        
        switch (nb)
        {
            case 0:
                setForm("cercle");
                break;
            case > 0 and <= 4:
                setForm("hexagone");
                break;
            case > 4 and <= 14:
                setForm("losange");
                break;
            case > 14 and <= 24:
                setForm("carree");
                break;
            case > 24 and <= 49:
                // color = Color.orange;
                setForm("pentagone");
                break;
            default:
                setForm("triangle");
                break;
        }
        return getForm();
    }

    string assignMotif()
    {
        Random random = new Random();
        int nb = random.Next(0, 4);
        
        switch (nb)
        {
            case 0:
                setForm("ligne");
                break;
            case 1:
                setForm("vague");
                break;
            case 2:
                setForm("point");
                break;
            default:
                setForm("carreau");
                break;
        }
        return getForm();
    }

    public void generateAsteroid()
    {
        GameObject newAsteroid = Instantiate(asteroid, new Vector3(0, 0, 0),Quaternion.identity);
        scriptAsteroide myAsteroide = newAsteroid.GetComponent<scriptAsteroide>();
        myAsteroide.createAsteroid(assignColor(), assignMotif(), assignForm());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
