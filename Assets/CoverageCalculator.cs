using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoverageCalculator : MonoBehaviour {

    public GameObject MeshGO;
    public LayerMask hairMask;
    List<int> indices = new List<int>();
    List<int> baldSpotIndices = new List<int>();
    bool first = true;


    void Start()
    {
        Coverage();
        first = false;
    }


    public float Coverage()
    {
        Mesh mesh = MeshGO.GetComponent<MeshCollider>().sharedMesh;

        int hairsCount = 0;

        

        for (int i = 0; i < mesh.vertices.Length; i++)
		{
            var worldPos = MeshGO.transform.TransformPoint(mesh.vertices[i]);
            var worldNormal = MeshGO.transform.TransformDirection(mesh.normals[i]);


            //Debug.DrawRay(worldPos, worldNormal, Color.white, 10);

            //RaycastHit info;

            if (Physics.Raycast(worldPos + worldNormal, -worldNormal, 1000, hairMask)) 
            {
                if(first)
                    indices.Add(i);

                hairsCount++;
            }
            else if (indices.Contains(i))
            {
                baldSpotIndices.Add(i);
            }

		}

        float ratio = (float)hairsCount / (float)mesh.vertices.Length;

        Debug.Log(baldSpotIndices.Count);
        baldSpotIndices.Clear();
        return ratio;
    }


	
}
