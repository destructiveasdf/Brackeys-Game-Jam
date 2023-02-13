using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupAble : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D thing;
    public bool held;
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                held = true;
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (held == true)
        {
            transform.parent.parent = FindObjectOfType<PlatformerMovement>().transform.GetChild(2);
            transform.parent.position = FindObjectOfType<PlatformerMovement>().transform.GetChild(2).position;
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                held = false;
            }
        }
        else
        {
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            transform.parent.parent = null;
        }
    }
    
}
