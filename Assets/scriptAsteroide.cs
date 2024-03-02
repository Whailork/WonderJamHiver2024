using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class scriptAsteroide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void assignColor()
    {
        Random random = new Random();
        int nb = random.Next(0, 100);
        Color color = new Color();
        
        if (nb == 0)
        {
            color = Color.magenta;
        }
        else if (nb is > 0 or < 5)
        {
            color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
