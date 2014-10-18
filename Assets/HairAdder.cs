using UnityEngine;
using System.Collections;

public class HairAdder : MonoBehaviour {

    public GameObject hairPrefab;
    public bool hairPutting;
    public Vector3 hairPoint;
    public Vector3 normal;
    public GameObject currentHair;
    public LayerMask headMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            hairPutting = true;
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, headMask))
            {
                hairPoint = hitInfo.point;
                normal = hitInfo.normal;
                currentHair = Instantiate(hairPrefab) as GameObject;
            }
            return;
        }

        if (hairPutting)
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, headMask))
            {
                hairPoint = hitInfo.point;
                normal = hitInfo.normal;

                currentHair.transform.position = hairPoint + .01f * normal;
                currentHair.transform.forward = -normal;
            }

            
        }

        if (Input.GetMouseButtonUp(0))
        {
            hairPutting = false;
        }


	}
}
