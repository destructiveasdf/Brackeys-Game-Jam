using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomspawner : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isleft, isright, isup;
    void Start()
    {
        if (isup == true)
        {
            Instantiate(FindObjectOfType<rooms>().uproom[Random.Range(0, FindObjectOfType<rooms>().uproom.Length)], transform.position, transform.rotation);
        }
        if (isleft == true)
        {
            Instantiate(FindObjectOfType<rooms>().leftroom[Random.Range(0, FindObjectOfType<rooms>().leftroom.Length)], transform.position, transform.rotation);

        }
        if(isright == true)
        {
            Instantiate(FindObjectOfType<rooms>().uproom[Random.Range(0, FindObjectOfType<rooms>().uproom.Length)], transform.position, transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
