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
           Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(other.gameObject);
        }
    }
}
