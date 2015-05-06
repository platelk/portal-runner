using UnityEngine;
using System.Collections;

public class TutorialPortalCreation : MonoBehaviour
{
    public GameObject normalHand;
    public GameObject touchHand;
    public GameObject player;
    public GameObject portal;
    public AutoMovePlayer amp;

    public PauseManager pm;

    public Transform endPoint;
    public float speed;
    public float wait;

    private float internalTimer;
    private HelpState internalState;

    private enum HelpState
    {
        BEFORE_START = -1,
        START = 0,
        PRESSING = 1,
        MOVING = 2,
        UNPRESS = 3,
        END = 4
    }
    // Use this for initialization
    void Start()
    {
        normalHand.gameObject.SetActive(false);
        touchHand.gameObject.SetActive(false);
        internalTimer = wait;
        internalState = HelpState.BEFORE_START;
    }

    // Update is called once per frame
    void Update()
    {

        if (internalState == HelpState.MOVING)
        {
            normalHand.transform.position = Vector3.Lerp(normalHand.transform.position, endPoint.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(normalHand.transform.position, endPoint.transform.position) < 0.1)
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
            internalTimer = wait;
            if (internalState == HelpState.START)
            {
                normalHand.gameObject.SetActive(true);
                touchHand.gameObject.SetActive(false);
            }
            else if (internalState == HelpState.PRESSING)
            {
                normalHand.gameObject.SetActive(false);
                touchHand.gameObject.SetActive(true);
            }
            else if (internalState == HelpState.MOVING)
            {
                Vector3 v = touchHand.transform.position;
                v.x = 0;
                Instantiate(portal, v, portal.transform.rotation);
                normalHand.gameObject.SetActive(true);
                touchHand.gameObject.SetActive(false);
                touchHand.transform.position = endPoint.transform.position;
                amp.direction = new Vector3(0, 0, 0.5f);
            }
            else if (internalState == HelpState.UNPRESS)
            {
                normalHand.gameObject.SetActive(false);
                touchHand.gameObject.SetActive(true);
                
            }
            else if (internalState == HelpState.END)
            {
                Vector3 v = touchHand.transform.position;
                v.x = 0;
                Instantiate(portal, v, portal.transform.rotation);
                normalHand.gameObject.SetActive(true);
                touchHand.gameObject.SetActive(false);
                //pm.pauseGame();
                Destroy(gameObject);
            }
        }

    }
}
