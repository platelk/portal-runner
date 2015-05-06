using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public float timeScale;
    public float physicSmooth;
    public Button slowTimeButton;
    public Slider slowTimeBar;
    public float slowTimeScale;

    public float maxTimeRessources;
    public float decreaseRate;
    public float increaseRate;

    private float internalTimeScale;
    private bool isTimeSlow;
    private float timeRessources;
	// Use this for initialization
	void Start ()
	{
	    isTimeSlow = false;
	    internalTimeScale = timeScale;
	    timeRessources = maxTimeRessources;
	    if (slowTimeButton != null)
	    {
	        slowTimeButton.onClick.AddListener(() =>
	        {
                isTimeSlow = !isTimeSlow;
	        });
	    }
        applyChange();
	}

    void SlowTime()
    {
        if (isTimeSlow && timeRessources > 0)
        {
            internalTimeScale = slowTimeScale;
        }
        else
        {
            internalTimeScale = timeScale;
            isTimeSlow = false;
        }
        applyChange();
    }

	// Update is called once per frame
	void Update ()
	{
	    if (PauseManager.isPause)
	        return;
	    if (isTimeSlow)
	    {
	        timeRessources -= decreaseRate*Time.deltaTime;
	    }
	    else
	    {
	        timeRessources = (timeRessources + increaseRate*Time.deltaTime);
	        if (timeRessources > maxTimeRessources)
	            timeRessources = maxTimeRessources;
	    }
	    if (timeRessources <= 0)
	    {
	        timeRessources = 0;
	        isTimeSlow = false;
	    }
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            isTimeSlow = !isTimeSlow;
	    }
        SlowTime();
	}

    public float GetTimeRessources()
    {
        return timeRessources;
    }

    public void applyChange()
    {
        Time.timeScale = internalTimeScale;
        Time.fixedDeltaTime = timeScale*physicSmooth;
        slowTimeBar.value = timeRessources;
    }

    public void backToNormal()
    {
        internalTimeScale = timeScale;
        applyChange();
    }
}
