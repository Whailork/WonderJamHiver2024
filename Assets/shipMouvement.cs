using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using RunManager;

public class shipMouvement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D bc;
    private SpriteRenderer sprite;
    public GameObject projectilePrefab;
    private bool boxUp = true;
    private int cooldown = 0;
    private int cooldownBC = 0;
    public int vie;
    public Image Barre1;
    public Image Barre2;
    public Image Barre3;
    public RunManager runManager;

    public AudioClip shootFx;
    public AudioClip onHitFx;
    public AudioClip shipmoveFx;
    //public GameObject alertMort;


    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 1.0f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 200f;
    public bool startBlinking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        vie = 3;
        //alertMort.setAcitve(false);
    }

    
    private void Update()
    {
       



    }

    public void throwProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.eulerAngles.z), Quaternion.identity);
        cooldown = 30;
        projectileScript controller = projectile.GetComponent<projectileScript>();
        controller.setDirection(new Vector2(10*Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad),10*Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));
        controller.setRotation(transform.eulerAngles.z);
        SoundPlayer.instance.PlaySFX(shootFx,2);
    }

    private void FixedUpdate()
    {
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector2.left);
            rb.AddTorque(1.1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector2.right);
            rb.AddTorque(-1.1f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            // rb.AddForce(Vector2.up);
            rb.AddForce(new Vector2(6f * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad), 6f * Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));
            //SoundPlayer.instance.PlaySFX(shipmoveFx,1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(Vector2.down);
            rb.AddForce(new Vector2(-6 * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad), -6 * Mathf.Sin(rb.rotation * Mathf.Deg2Rad + 90f * Mathf.Deg2Rad)));

        }

        if (Input.GetKey(KeyCode.Space) && cooldown == 0)
        {
            throwProjectile();
        }

        if (cooldownBC == 0 && !boxUp)
        {
            //bc.enabled = true;
            boxUp = true;

        }
        else if (!boxUp)
        {
            cooldownBC--;
        }

        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }

        
        if (cooldown != 0)
        {
            cooldown--;
        }

    }
  

    private void OnCollisionEnter2D(Collision2D colision)
    {
       
        if (colision.collider.CompareTag("asteroid") && boxUp)
        {
            SoundPlayer.instance.PlaySFX(onHitFx, 3);
            vie--;
           
            boxUp = false;
            cooldownBC = 90;
            startBlinking = true;
           
           
            if (vie <= 0)
            {
                //SceneManager.LoadScene("sceneLaboratory");

                //alertMort.setActive(true);
                RunManager.enemiesLeft = 0;
                RunManager.endGeneration = true;
                runManager.askAfterDead();

                RunManager.currentRun = 0;
                RunManager.roundNumber = 1;
                Destroy(this.gameObject);
            }
            //SoundPlayer.instance.PlaySFX(onHitFx, 3);

        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += 1;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            sprite.enabled = true;   // according to 

            if (vie == 2)
            {
                Barre3.enabled = false;
            }

            else if (vie == 1)
            {
                Barre2.enabled = false;
            }

            //your sprite
            return;
        }

        spriteBlinkingTimer += 1;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (sprite.enabled == true)
            {
                sprite.enabled = false;  //make changes

                if (vie == 2)
                {
                    Barre3.enabled = false;
                }

                else if (vie == 1)
                {
                    Barre2.enabled = false;
                }
            }
            else
            {
                sprite.enabled = true;   //make changes

                if (vie == 2)
                {
                    Barre3.enabled = true;
                }

                else if (vie == 1)
                {
                    Barre2.enabled = true;
                }
            }
        }
    }


}
