using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scam : MonoBehaviour
{
    // Start is called before the first frame update
    public bool didFall;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        didFall = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
