using UnityEngine;
using System.Collections;

public class s_loadSceneButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene(string scene){
		Application.LoadLevel (scene);
	}

	public void exitGame() {
		Application.Quit();
	}
}
