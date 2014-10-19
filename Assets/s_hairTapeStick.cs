using UnityEngine;
using System.Collections;

public class s_hairTapeStick : MonoBehaviour {
	
	public AudioClip stickSound;
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
		audio.PlayOneShot(stickSound);
	}

}
