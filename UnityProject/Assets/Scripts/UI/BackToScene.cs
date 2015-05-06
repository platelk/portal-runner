using System;
using UnityEngine;
using System.Collections;

public class BackToScene : MonoBehaviour
{

    public String sceneToLoad;
    public bool quit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Escape))
	    {
            if (quit)
                Application.Quit();
            else
	            Application.LoadLevel(sceneToLoad);
	    }
	}
}
