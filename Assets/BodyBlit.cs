using UnityEngine;
using System.Collections;

public class BodyBlit : MonoBehaviour {

    public RenderTexture bodyTex;
    public Camera effectCamera;
    public Material blitMat;


    void Start()
    {
        bodyTex = new RenderTexture(Screen.width, Screen.height, 32);
        bodyTex.Create();
        effectCamera.targetTexture = bodyTex;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, bodyTex, blitMat);
        Graphics.Blit(bodyTex, dest);
    }
}
