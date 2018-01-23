using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket2 : MonoBehaviour
{
    Rigidbody rbody;
    AudioSource asource;
    GameObject go1, go2, go3;
    public Transform TargetPad;
    Boolean targetPadCollide = false;
    [SerializeField] Boolean audioCheck = false;
    [SerializeField] float rocketThrust;
    [SerializeField] float RCSThrust;
    Boolean targetCollisionOff = false;
    // Use this for initialization

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        asource = GetComponent<AudioSource>();
        go1 = GameObject.Find("Rocky2");
        go2 = GameObject.Find("TargetPad2");
        rocketThrust = 50f;
        RCSThrust = 25f;
        go3 = GameObject.FindGameObjectWithTag("scene2");
    }

    // Update is called once per frame
    void Update()
    {
        FlyAway();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetCollisionOff == false)
        {
            if (collision.gameObject.tag == "scene2")
            {
                transform.position = new Vector3(19f, 1.5f, 0f);
                transform.rotation = Quaternion.identity;
                rbody.velocity = new Vector3(0f, 0f, 0f);
                rbody.angularVelocity = new Vector3(0f, 0f, 0f);
            }
        }

        if (collision.gameObject.name == "TargetPad2")
        {
            targetPadCollide = true;
            if (targetPadCollide == true)
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
                SceneManager.LoadScene("Game", LoadSceneMode.Single);


            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
       if(collision.gameObject.name == "TargetPad2")
        collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            
    }


    void FlyAway()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            audioCheck = true;
            rbody.AddRelativeForce(Vector3.up * rocketThrust * Time.deltaTime);
            if (audioCheck == true)
            {
                asource.Play();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rbody.AddRelativeForce(Vector3.right);
            transform.Rotate(-Vector3.forward * RCSThrust * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            //rbody.AddRelativeForce(Vector3.left);
            transform.Rotate(Vector3.forward * RCSThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rbody.AddRelativeForce(Vector3.down * rocketThrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.O))
        {
            targetCollisionOff = !targetCollisionOff;
        }
        else
        {
            audioCheck = false;
        }


    }
}
