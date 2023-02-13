using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class changeCam : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera cam;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("h");
            foreach (CinemachineVirtualCamera vc in FindObjectsOfType<CinemachineVirtualCamera>())
            {
                vc.Priority = 3;
            }
            transform.parent.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 11;
            transform.parent.GetComponentInChildren<CinemachineVirtualCamera>().Follow = FindObjectOfType<PlatformerMovement>().transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
