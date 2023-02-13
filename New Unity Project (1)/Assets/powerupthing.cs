using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupthing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cmvcam,canv;
    public bool isdashallow;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            cmvcam.SetActive(true);
            canv.SetActive(true);
            if (isdashallow) {
                collision.GetComponent<PlatformerMovement>().canDash = true;
            } 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cmvcam.SetActive(false);
        canv.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
