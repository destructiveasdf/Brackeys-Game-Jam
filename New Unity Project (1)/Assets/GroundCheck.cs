using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isgrounded, issmash, smashable;
    public Rigidbody2D rb;
    public float grav, multiplyer;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        grav = rb.gravityScale;
    }

    private void Update()
    {

        if(isgrounded == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (smashable)
                {
                    issmash = true;
                }
            }
        }
        if (issmash == true)
        {
            rb.gravityScale = grav * multiplyer;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            isgrounded = true;
            GetComponentInParent<PlatformerMovement>().CanDoubleJump = true;

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "ground" || collision.transform.tag == "elevator")
        {
            isgrounded = false;
            issmash = false;
            rb.gravityScale = grav;
        }
    }
}
