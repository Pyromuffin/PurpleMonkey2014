using UnityEngine;
using System.Collections;

public class SceneState : MonoBehaviour {


    public static SceneState instance;

    public bool stylingMode = false;
    public Material hair, toupee;
    public AudioClip screenieSound;
    int screenieNumber;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Screenie"))
        {
            PlayerPrefs.SetInt("Screenie", 1);
        }

        instance = this;
        screenieNumber = PlayerPrefs.GetInt("Screenie");
    }

    void Start()
    {
        //hair.SetColor("_Color", new Color(Random.value, Random.value, Random.value, .5f));
        //toupee.SetColor("_Color", new Color(Random.value, Random.value, Random.value));
    }


    public void screenie()
    {  
        screenieNumber++;
        PlayerPrefs.SetInt("Screenie", screenieNumber);
        Application.CaptureScreenshot("Super Hairpiece Shameshot " + screenieNumber.ToString() +".png");
        audio.PlayOneShot(screenieSound);
    }

    public void setStyling(bool value)
    {
        stylingMode = value;
    }

    public  void restart()
    {
        Application.LoadLevel(0);
    }

    public  void giveUp()
    {

    }
}
