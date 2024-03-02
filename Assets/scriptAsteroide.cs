using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Drawing;
using Color = System.Drawing.Color;

public class scriptAsteroide : MonoBehaviour
{
    private Color color = new Color();
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

    void assignColor()
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
    }

    void assignForm()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
