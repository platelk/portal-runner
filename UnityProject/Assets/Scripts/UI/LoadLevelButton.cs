using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class LoadLevelButton : MonoBehaviour
{
    public String levelToLoad;
    static GameObject LoadingScreen;

	// Use this for initialization
	void Start ()
	{
	    if (LoadingScreen == null)
	        LoadingScreen = GameObject.Find("LoadingScreen");
        if (LoadingScreen != null)
            LoadingScreen.SetActive(false);
	    GetComponent<Button>().onClick.AddListener(LoadLevel);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void LoadLevel()
    {
        LoadingScreen.SetActive(true);
        Application.LoadLevelAsync(levelToLoad);   
    }

    void OnPointerEnter(PointerEventData eventData)
    {
        LoadLevel();
    }
}
