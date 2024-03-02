using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDirection(Vector2 direction)
    {
        rb.velocity = direction;
        
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.collider.CompareTag("asteroid"))
        {
            // le code pour détruire l'astéroid
        }
    }
}
