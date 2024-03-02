using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chanColorScript : MonoBehaviour
{
    
    public Color newColor;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
