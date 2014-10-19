using UnityEngine;
using System.Collections;

public class HairAdder : MonoBehaviour {

    public GameObject hairPrefab;
    public bool hairPutting;
    public Vector3 hairPoint;
    public Vector3 normal;
    public GameObject currentHair;
    public LayerMask headMask, hairMask;
    public float maxLength, minLength;
    public float maxWidth, minWidth;
    public float deletionRadius;
    public float sprayTimer, sprayInterval;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!SceneState.instance.stylingMode)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, headMask))
            {
                hairPoint = hitInfo.point;
                var hairs = Physics.OverlapSphere(hairPoint, deletionRadius, hairMask);
                foreach (var hair in hairs)
                {

                    if (hair.tag == "Sticker")
                    {
                        Destroy(hair.transform.parent.gameObject);
                    }
                    else
                    {
                        Destroy(hair.transform.gameObject);

                    }
                }
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            hairPutting = true;
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, headMask))
            {
                hairPoint = hitInfo.point;
                normal = hitInfo.normal;
                currentHair = Instantiate(hairPrefab) as GameObject;
                currentHair.layer = LayerMask.NameToLayer("Hairs");
                currentHair.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Hairs");

                currentHair.transform.parent = transform;
                currentHair.transform.localScale = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minLength, maxLength), 1);
            }
            return;
        }


        if (Input.GetMouseButton(0) && hairPutting && sprayTimer > sprayInterval)
        {
            sprayTimer = 0;
            currentHair = Instantiate(hairPrefab) as GameObject;
            currentHair.layer = LayerMask.NameToLayer("Hairs");
            currentHair.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Hairs");
            currentHair.transform.parent = transform;
            currentHair.transform.localScale = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minLength, maxLength), 1);
          
        }


        if (hairPutting)
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, headMask))
            {
                //Debug.Log(Input.mousePosition);

                hairPoint = hitInfo.point;
                normal = hitInfo.normal;

                currentHair.transform.position = hairPoint + .01f * normal;
                currentHair.transform.forward = -normal;
            }

            sprayTimer += Time.deltaTime;   
        }

        if (Input.GetMouseButtonUp(0))
        {
            hairPutting = false;
        }


       


	}
}
