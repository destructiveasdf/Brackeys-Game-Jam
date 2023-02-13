using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public float RateOfAttack;
    float rate;
    
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rate += Time.deltaTime;
        if(rate >= RateOfAttack)
        {
            Instantiate(bullet, transform.GetChild(0).position, transform.rotation);
            rate = 0;
        }
    }
}
