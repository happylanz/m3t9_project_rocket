using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {
    Rigidbody rbody;
    AudioSource asource;
    GameObject go1, go2, go3, go4;
    Boolean targetCollisionOff = false;
    public Transform TargetPad;
    Boolean targetPadCollide = false;
    [SerializeField]Boolean audioCheck = false;
    [SerializeField]float rocketThrust;
    [SerializeField] float RCSThrust;
    
    // Use this for initialization

    void Start () {
        rbody = GetComponent<Rigidbody>();
        asource = GetComponent<AudioSource>();
        go1 = GameObject.Find("Rocky");
        go2 = GameObject.Find("TargetPad");
        rocketThrust = 50f;
        RCSThrust = 25f;
        go3 = GameObject.FindGameObjectWithTag("scene2");

    }
	
	// Update is called once per frame
	void Update () {
        FlyAway();

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (targetCollisionOff == false)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                SceneManager.LoadScene("Game2", LoadSceneMode.Single);
            }
        }

        if (collision.gameObject.name == "TargetPad")
        {
            targetPadCollide = true;
            if (targetPadCollide == true)
            {
                SceneManager.LoadScene("Game3", LoadSceneMode.Single);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.name.Equals("TargetPad"))
        {
            targetPadCollide = false;
            if (targetPadCollide == false)
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
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
        }if (Input.GetKey(KeyCode.D))
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
        if(Input.GetKey(KeyCode.O))
        {
            targetCollisionOff = !targetCollisionOff;
        }

        else
        {
            audioCheck = false;
        }
        
    }
}
