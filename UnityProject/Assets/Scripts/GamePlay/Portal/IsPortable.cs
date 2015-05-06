using UnityEngine;
using System.Collections;

public class IsPortable : MonoBehaviour {

    public enum PortalState
    {
        PORTAL_STATE,
        TRANSITION_STATE,
        NORMAL_STATE
    }

    public float timeInState;
    private float internalStateTimer;

    private PortalState state;
	// Use this for initialization
	void Start ()
	{
	    internalStateTimer = timeInState;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (internalStateTimer > 0f)
	    {
	        internalStateTimer -= Time.deltaTime;
	    }
	    if (internalStateTimer <= 0f)
	    {
	        state = PortalState.NORMAL_STATE;
	    }
	}

    public PortalState CurrentState()
    {
        return state;
    }

    public void ChangeState(PortalState newState)
    {
        if (newState == PortalState.PORTAL_STATE)
        {
            internalStateTimer = timeInState;
        }
        state = newState;
    }
}
