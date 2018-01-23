using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPad : MonoBehaviour
{
    Material material;
    // Use this for initialization
    void Start()
    {
        material = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "rocket")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;  
        }
    }

}
