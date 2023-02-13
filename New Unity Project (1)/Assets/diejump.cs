using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diejump : MonoBehaviour
{
    // Start is called before the first frame update
    public float force;
    public float smashInc;
    public bool used;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            if (collision.transform.position.y > transform.position.y)
            {
                if (collision.transform.GetComponent<PlatformerMovement>().isDashing == false)
                {
                    if (used == false)
                    {
                        if (collision.transform.GetComponentInChildren<GroundCheck>().issmash == true)
                        {
                            collision.transform.GetComponent<PlatformerMovement>().Jump(force + smashInc);
                            used = true;
                        }
                        else
                        {
                            collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                            collision.transform.GetComponent<PlatformerMovement>().Jump(force);
                            used = true;
                        }
                    }
                    collision.transform.GetComponent<Rigidbody2D>().gravityScale = collision.transform.GetComponentInChildren<GroundCheck>().grav;
                    collision.transform.GetComponentInChildren<GroundCheck>().issmash = false;
                    if (transform.parent != null)
                    {
                        if (transform.parent.tag == "enemy")
                        {
                            Destroy(transform.parent.gameObject);
                        }
                    }
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponentInChildren<GroundCheck>().isgrounded = false;
            used = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
