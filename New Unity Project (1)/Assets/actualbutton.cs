using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isstaying;
    public Animator door;
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        isstaying = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isstaying = false;
    }
    
    // Update is called once per frame
    public void Door()
    {
        door.SetBool("open", isstaying);
    }
    void Update()
    {
        if(isstaying == true)
        {
            
            GetComponent<Animator>().SetBool("isstaying", true);
        }
        else
        {
            
            GetComponent<Animator>().SetBool("isstaying", false);

        }
    }
}
