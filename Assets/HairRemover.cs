using UnityEngine;
using System.Collections;

public class HairRemover : MonoBehaviour {

    public LayerMask hairLayer;
    public LayerMask headLayer;
    public float radius;
    public Collider[] hairs;


	// Use this for initialization
	public void Balden () {
	

        Vector3 randomScreenPoint = new Vector3(Random.Range(0,Camera.main.pixelWidth), Random.Range(0,Camera.main.pixelHeight),0);

        Ray randomRay = Camera.main.ScreenPointToRay(randomScreenPoint);

        RaycastHit hit;
        while (!Physics.Raycast(randomRay, out hit, 10000, headLayer))
        {

             randomScreenPoint = new Vector3(Random.Range(0, Camera.main.pixelWidth), Random.Range(0, Camera.main.pixelHeight), 0);

             randomRay = Camera.main.ScreenPointToRay(randomScreenPoint);
           
        }

        hairs = Physics.OverlapSphere(hit.point, radius, hairLayer);
        foreach (var hair in hairs)
        {
            Destroy(hair.transform.gameObject);
        }

        //hairs = Physics.SphereCastAll(randomRay,radius, 10000, hairLayer);

        /*
        while (hairs.Length == 0)
        {
            randomScreenPoint = new Vector3(Random.Range(0, Camera.main.pixelWidth), Random.Range(0, Camera.main.pixelHeight), 0);
            randomRay = Camera.main.ScreenPointToRay(randomScreenPoint);
            hairs = Physics.SphereCastAll(randomRay, radius, 10000, hairLayer);
        }
        */
       

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
