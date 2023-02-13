using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumporb : MonoBehaviour
{
    // Start is called before the first frame update
    float thing, thing2;
    bool jump;
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                
                collision.GetComponent<PlatformerMovement>().Jump(20);
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            jump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
