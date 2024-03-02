using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class shipMouvement : MonoBehaviour
{

    //public float offsetAngle = 180.0f;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public GameObject projectilePrefab;
    private int cooldown = 0;
    public int vie;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector2.left);
            rb.AddTorque(0.1f);
        }
          
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector2.right);
            rb.AddTorque(-0.1f);
        }
          
        if (Input.GetKey(KeyCode.W))
        {
            // rb.AddForce(Vector2.up);
            rb.AddForce(new Vector2(0.5f * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad), 0.5f * Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));

        }
           
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(Vector2.down);
            rb.AddForce(new Vector2( -1 * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad), -1 * Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));

        }
            
        if (Input.GetKey(KeyCode.Space) && cooldown == 0)
        {
            throwProjectile();
        }

      

    }

    public void throwProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab,  new Vector3(transform.position.x,transform.position.y,transform.eulerAngles.z), Quaternion.identity);
        cooldown = 30;
        projectileScript controller = projectile.GetComponent<projectileScript>();
        controller.setDirection(new Vector2(10*Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad),10*Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));
    }

    private void FixedUpdate()
    {
        if (cooldown != 0)
        {
            cooldown--;
        }
    }
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.collider.CompareTag("asteroid"))
        {
            //vie--; ne pas oublier de le remettre
            if (vie <= 0)
            {
                SceneManager.LoadScene("mainMenuScene");
                Destroy(this.gameObject);
            }
            
        }
    }
}
