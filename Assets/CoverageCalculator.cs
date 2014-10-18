using UnityEngine;
using System.Collections;

public class CoverageCalculator : MonoBehaviour {

    public GameObject MeshGO;
    public LayerMask hairMask;

    public float Coverage()
    {
        Mesh mesh = MeshGO.GetComponent<MeshCollider>().sharedMesh;

        int hairsCount = 0;

        

        for (int i = 0; i < mesh.vertices.Length; i++)
		{
            var worldPos = MeshGO.transform.TransformPoint(mesh.vertices[i]);
            var worldNormal = MeshGO.transform.TransformDirection(mesh.normals[i]);


            Debug.DrawRay(worldPos, worldNormal, Color.white, 10);

            if (Physics.CheckSphere(worldPos, .01f, hairMask)) 
            {
                hairsCount++;
            }


		}

        float ratio = (float)hairsCount / (float)mesh.vertices.Length;

        Debug.Log(ratio);
        return ratio;
    }


	
}
