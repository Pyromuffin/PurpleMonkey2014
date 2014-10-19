using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public GameObject target;
    public float swivelSpeed;
    public float distance;

	// Use this for initialization
	void Start () {

        transform.LookAt(target.transform);
        transform.position = target.transform.position - transform.forward * distance;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * swivelSpeed * Time.deltaTime;
            transform.LookAt(target.transform);
            transform.position = target.transform.position - transform.forward * distance;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * swivelSpeed * Time.deltaTime;
            transform.LookAt(target.transform);
            transform.position = target.transform.position - transform.forward * distance;
        }


	}
}
