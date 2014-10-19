using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CoverageCalculator : MonoBehaviour {

    public GameObject MeshGO;
    public LayerMask hairMask;
    List<int> indices = new List<int>();
    List<int> baldSpotIndices = new List<int>();
    bool first = true;
    public Text shameText;
    public Text percent;
    public Text shamePhrase;
    public int baldVertices;
    public float blinkTime;
    string[] fates = new string[] { "Don't go outside today.", "Nice... try.", "meh.", "You're not fooling anyone with that", "Hat weather.", "At least your mom still likes you.", "Distressing!" };

    void Start()
    {
        Coverage();
        first = false;
    }


    public void Coverage()
    {
        Mesh mesh = MeshGO.GetComponent<MeshCollider>().sharedMesh;

        int hairsCount = 0;
        baldSpotIndices.Clear();

        

        for (int i = 0; i < mesh.vertices.Length; i++)
		{
            var worldPos = MeshGO.transform.TransformPoint(mesh.vertices[i]);
            var worldNormal = MeshGO.transform.TransformDirection(mesh.normals[i]);


            //Debug.DrawRay(worldPos, worldNormal, Color.white, 10);

            //RaycastHit info;

            if (Physics.Raycast(worldPos + worldNormal * 5, -worldNormal * 10, 1000, hairMask)) 
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
        
    }


    public int baldVertexCount()
    {
        Mesh mesh = MeshGO.GetComponent<MeshCollider>().sharedMesh;

        int hairsCount = 0;
        baldSpotIndices.Clear();



        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            var worldPos = MeshGO.transform.TransformPoint(mesh.vertices[i]);
            var worldNormal = MeshGO.transform.TransformDirection(mesh.normals[i]);


            //Debug.DrawRay(worldPos, worldNormal, Color.white, 10);

            //RaycastHit info;

            if (Physics.Raycast(worldPos + worldNormal * 5, -worldNormal * 10, 1000, hairMask))
            {
                if (first)
                    indices.Add(i);

                hairsCount++;
            }
            else if (indices.Contains(i))
            {
                baldSpotIndices.Add(i);
            }


        }

        return baldSpotIndices.Count;
    }


    IEnumerator blinkThatText()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkTime);
            percent.gameObject.SetActive(false);
            yield return new WaitForSeconds(blinkTime);
            percent.gameObject.SetActive(true);
        }
      

    }

    public void reallyCalculateShame()
    {
        Coverage();
        var ratio = (float)baldSpotIndices.Count / (float)baldVertices;
        shameText.gameObject.SetActive(true);
        percent.text = ( (1-ratio) * 100).ToString() + "%";
        shamePhrase.gameObject.SetActive(true);
        shamePhrase.text = fates[Random.Range(0, fates.Length)];
        StartCoroutine(blinkThatText());

    }

	
}
