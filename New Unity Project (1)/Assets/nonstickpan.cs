using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonstickpan : MonoBehaviour
{
    // Start is called before the first frame update
    public PhysicsMaterial2D thing;
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GetComponentInParent<Rigidbody2D>().sharedMaterial = thing;
        if (collision.transform.tag == "jumper")
        {
            transform.parent.GetComponentInChildren<GroundCheck>().isgrounded = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<Rigidbody2D>().sharedMaterial = null;
        if(collision.transform.tag == "jumper")
        {
            transform.parent.GetComponentInChildren<GroundCheck>().isgrounded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
