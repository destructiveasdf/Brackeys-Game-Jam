using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultEnemy : MonoBehaviour
{
    public Transform place;
    public float speed, distance;
    public bool movingRight;

    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        RaycastHit2D right = Physics2D.Raycast(place.position, Vector2.right, distance);
        
        

        
        if(right.transform != null) { 
            if (right.transform.tag == "ground")
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);

                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);

                    movingRight = true;
                }
            }
        }
    }
}
