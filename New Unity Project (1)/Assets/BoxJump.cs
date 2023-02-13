using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D coll;
    Vector2 pos;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        pos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "spikes")
        {
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
    }
}
