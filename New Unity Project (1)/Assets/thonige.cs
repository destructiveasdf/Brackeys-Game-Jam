using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thonige : MonoBehaviour {

    public float speed;
    public bool thing, checkHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponentInChildren<Rigidbody2D>().gravityScale = 20;
            GetComponentInChildren<Rigidbody2D>().mass = 30;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (GetComponentInChildren<scam>().didFall == true)
            {

                thing = true;
            }
            else
            {
                Debug.Log("f");
                checkHit = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
     
        if(thing == true)
        {
            GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            float tParam = 0;

            tParam += Time.deltaTime * speed;
            transform.GetChild(0).position = new Vector3(transform.position.x, Mathf.Lerp(transform.GetChild(0).position.y, transform.position.y, tParam), transform.position.z);
        }
        if (transform.GetChild(0).position == transform.position)
        {
            thing = false;
        }
        if (transform.GetChild(0).position.y < 0)
        {
            thing = false;
        }
        if (checkHit == true)
        {
            if (GetComponentInChildren<scam>().didFall == true)
            {
                thing = true;
            }
        }
    }
}
