using UnityEngine;
using System.Collections;

public class SceneState : MonoBehaviour {


    public static SceneState instance;

    public bool stylingMode = false;
    public Material hair, toupee;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
       // hair.SetColor()
    }

    public  void restart()
    {

    }

    public  void giveUp()
    {

    }
}
