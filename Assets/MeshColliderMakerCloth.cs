using UnityEngine;
using System.Collections;

public class MeshColliderMakerCloth : MonoBehaviour {

    public InteractiveCloth cloth;
    public Mesh mesh;


    void Start()
    {
        mesh = (Mesh)Instantiate(cloth.mesh);
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void Update()
    {
        GetComponent<MeshCollider>().sharedMesh = null;
        mesh.vertices = cloth.vertices;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
