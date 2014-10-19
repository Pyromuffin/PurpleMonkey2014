using UnityEngine;
using System.Collections;

public class HairRemover : MonoBehaviour {

    public LayerMask hairLayer;
    public LayerMask headLayer;
    public float radius;
    public GameObject sphere;
    public Collider[] hairs;



    public void Start()
    {
        Balden();
    }

	// Use this for initialization
	public void Balden () {
	
        //create random point on sphere. cast toward center, if hit, then sphere overlap and destroy

        Vector3 spherePoint = Random.onUnitSphere * .75f;
        Vector3 centerDir = -spherePoint.normalized;

        spherePoint += sphere.transform.position;
        
        RaycastHit hit;
        while (!Physics.Raycast(spherePoint, centerDir, out hit, 1000, headLayer))
        {
            spherePoint = Random.onUnitSphere * .75f;
            centerDir = -spherePoint.normalized;

            spherePoint += sphere.transform.position;
        }

        hairs = Physics.OverlapSphere(hit.point, radius, hairLayer);
        foreach (var hair in hairs)
        {
            Destroy(hair.transform.gameObject);
        } 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
