using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airthing : MonoBehaviour
{
    // Start is called before the first frame update
    public float grav, urgrav, maxurgrav;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
        {
            grav = collision.GetComponent<Rigidbody2D>().gravityScale;
            collision.GetComponent<Rigidbody2D>().gravityScale = -urgrav;
        }
        if (collision.transform.tag == "Player")
        {
            GetComponentInChildren<GroundCheck>().smashable = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        collision.GetComponent<Rigidbody2D>().gravityScale = grav;
        if (collision.transform.tag == "Player")
        {
            GetComponentInChildren<GroundCheck>().smashable = true;
        }
    }
    void Update()
    {
        
    }
}
