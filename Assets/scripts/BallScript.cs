using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inplay;
    public Transform ballbridge;
    public float speed;
    public Transform explosion;
    public Transform powerup;
    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.up * 700);
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver)
        {
            return;
        }
        if (!inplay)
        {
            transform.position = ballbridge.position;
        }
        if (Input.GetButtonDown("Jump") && !inplay)
        {
            inplay = true;
            rb.AddForce(Vector2.up * speed);
        }
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            Debug.Log("bottom hit");
            rb.velocity = Vector2.zero;
            inplay = false;
            gm.UpdateLives(-1);
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Bricks"))
        {
            BrickScript brickscript = other.gameObject.GetComponent<BrickScript>();
            if (brickscript.hitsToBreak > 1)
            {
                // ball is calling the broken break through the below given function 
                brickscript.BreakBrick();
            }
            else
            {
                int randchance = Random.Range(1, 101);
                if (randchance > 75)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }
                Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                //adding points in below line 
                gm.UpdateScore(brickscript.points);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
        }
    }
}
