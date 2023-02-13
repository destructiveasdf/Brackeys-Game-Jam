using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crackedwalll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thing;
    public bool ishorizontal;
    public bool ishiding;
    public GameObject hiddenroom;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ishorizontal == false)
        {
            if (collision.transform.GetComponent<PlatformerMovement>().isDashing == true)
            {
                Instantiate(thing, transform.position, transform.rotation);
                Destroy(gameObject);
                if (ishiding)
                {
                    hiddenroom.SetActive(true);
                }
            }
        }
        else
        {
            if (collision.transform.GetComponentInChildren<GroundCheck>().issmash == true)
            {
                Instantiate(thing, transform.position, transform.rotation);
                Destroy(gameObject);
                if (ishiding)
                {
                    hiddenroom.SetActive(true);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
