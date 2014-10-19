using UnityEngine;
using System.Collections;

public class s_titleText : MonoBehaviour {

	public GameObject text;
	// Use this for initialization
	void Start () {
		StartCoroutine(wobble());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator wobble() {
		float rot = 0;
		float scale = 10;
		while (true) {
			rot++;
			text.transform.Rotate(new Vector3(0,0,Mathf.Sin (rot/scale)/2));
			yield return null;
		}
	}
}
