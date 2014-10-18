﻿using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public GameObject target;
    public float swivelSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * swivelSpeed * Time.deltaTime;
            transform.LookAt(target.transform);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * swivelSpeed * Time.deltaTime;
            transform.LookAt(target.transform);
        }


	}
}
