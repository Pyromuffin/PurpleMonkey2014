using UnityEngine;
using System.Collections;

public class s_hairTapeStick : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col)
	{
		//Debug.LogError("collided");
		rigidbody.isKinematic = true;
	}

}
