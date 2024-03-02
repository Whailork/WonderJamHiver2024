using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A))
            //rb.AddForce(Vector2.left);
            rb.AddTorque(-1);
        if (Input.GetKey(KeyCode.D))
            //rb.AddForce(Vector2.right);
            rb.AddTorque(1);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector2.up);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector2.down);


    }
}
