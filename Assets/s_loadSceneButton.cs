using UnityEngine;
using System.Collections;

public class s_fancyButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene(int scene){
		Application.LoadLevel (scene);
	}
}
