using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidPinkScrpt : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void changeGravity(int newGravity)
    {
        rb.gravityScale = newGravity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
