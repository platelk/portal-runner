using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseManager : MonoBehaviour
{

    public Button resumeButton;
    public Button pauseButton;
    public static bool isPause = false;

    private float saveTimeScale;
	// Use this for initialization
	void Start ()
	{
	    isPause = false;
        gameObject.SetActive(false);
	    pauseButton.onClick.AddListener(pauseGame);
        resumeButton.onClick.AddListener(resumeGame);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void pauseGame()
    {
        if (isPause)
            return;
        isPause = true;
        saveTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        //Time.fixedDeltaTime = 1 * 0.01f;
        gameObject.SetActive(true);
    }

    public void resumeGame()
    {
        isPause = false;
        Time.timeScale = saveTimeScale;
        gameObject.SetActive(false);
    }
} 
