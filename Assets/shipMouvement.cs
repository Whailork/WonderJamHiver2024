using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMouvement : MonoBehaviour
{

    //public float offsetAngle = 180.0f;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        if (Input.GetKey(KeyCode.A))
            //rb.AddForce(Vector2.left);
            rb.AddTorque(0.1f);
        if (Input.GetKey(KeyCode.D))
            //rb.AddForce(Vector2.right);
            rb.AddTorque(-0.1f);
        if (Input.GetKey(KeyCode.W))
            // rb.AddForce(Vector2.up);
            rb.AddForce(new Vector2(0.5f * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad), 0.5f * Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));
           
        if (Input.GetKey(KeyCode.S))
            //rb.AddForce(Vector2.down);
            rb.AddForce(new Vector2( -1 * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad), -1 * Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));


    }
}
