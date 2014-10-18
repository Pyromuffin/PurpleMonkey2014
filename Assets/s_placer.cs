using UnityEngine;
using System.Collections;

public class s_placer : MonoBehaviour {

	public GameObject toupe;
	public float speed =5;
	public LayerMask headMask;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
//			RaycastHit hitInfo;
//			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, headMask))
//			{
//				Vector3 direction = new Vector3(hitInfo.
//				hairPoint = hitInfo.point;
//				normal = hitInfo.normal;
//				currentHair = Instantiate(hairPrefab) as GameObject;
//			}
			GameObject instantiatedToupe = Instantiate (toupe,
			                                           transform.position,
			                                           transform.rotation)
				as GameObject;
			transform.TransformDirection(new Vector3(0,0,0));
			foreach (Rigidbody rb in instantiatedToupe.GetComponentsInChildren<Rigidbody>()) {
				rb.velocity = transform.TransformDirection(new Vector3(0,0,speed));
			}

//			instantiatedToupe.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,0));
//			instantiatedToupe.velocity = transform.TransformDirection(new Vector3(0,0,speed));
		}
	}
}
