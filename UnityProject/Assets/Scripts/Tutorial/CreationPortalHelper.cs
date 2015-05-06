using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Security.Cryptography;

public class CreationPortalHelper : MonoBehaviour
{

    public GameObject normalHand;
    public GameObject touchHand;

    public Transform endPoint;
    public float speed;
    public float wait;

    private float internalTimer;
    private HelpState internalState;

    private enum HelpState
    {
        START = 0,
        PRESSING = 1,
        MOVING = 2,
        UNPRESS = 3,
        END = 4
    }
	// Use this for initialization
	void Start ()
	{
        normalHand.gameObject.SetActive(true);
        touchHand.gameObject.SetActive(false);
	    internalTimer = wait;
	    internalState = HelpState.START;
	}
	
	// Update is called once per frame
	void Update () {

	    if (internalState == HelpState.MOVING)
	    {
            touchHand.transform.position = Vector3.Lerp(touchHand.transform.position, endPoint.transform.position, speed * Time.deltaTime);
	        if (Vector3.Distance(touchHand.transform.position, endPoint.transform.position) < 0.1)
	        {
	            internalTimer = -1;
	        }
	    }
	    else
	    {
	        internalTimer -= Time.deltaTime;
	    }
	    if (internalTimer <= 0)
	    {
	        internalState += 1;
	        if (internalState == HelpState.PRESSING)
	        {
	            normalHand.gameObject.SetActive(false);
                touchHand.gameObject.SetActive(true);
	            internalTimer = wait;
            }
            else if (internalState == HelpState.MOVING)
            {
                normalHand.transform.position = endPoint.transform.position;
                internalTimer = wait;
            }
            else if (internalState == HelpState.UNPRESS)
            {
                normalHand.gameObject.SetActive(true);
                touchHand.gameObject.SetActive(false);
                internalTimer = wait;
            }
            else if (internalState == HelpState.END)
            {
                Destroy(gameObject);
            }
	    }

	}
}
