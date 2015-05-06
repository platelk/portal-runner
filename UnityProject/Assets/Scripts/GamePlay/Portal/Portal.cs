using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Portal : MonoBehaviour
{
    public static List<Portal> portals = new List<Portal>();
    public GameObject quitAnimation;
    public float destroyDelay;
    public AudioClip takePortalSound;

    private int groundMask;
    private bool destroyPortal = false;
    private bool isValid = true;
    private GameObject player;

    public static void ClearPortal()
    {
        while (Portal.portals.Count != 0)
        {
            if (Portal.portals[0] != null && Portal.portals[0].gameObject != null)
            {
                Destroy(Portal.portals[0].gameObject);
            }

            Portal.portals.RemoveAt(0);
        }
    }

    public static void ClearPortalWithAnim()
    {
        foreach (Portal p in portals)
        {
            p.quitAnimation.SetActive(true);
            p.quitAnimation.GetComponent<ParticleSystem>().Play();
        }
        
    }

    public bool FindPortal(Portal p)
    {
        return p == this;
    }
	// Use this for initialization
	void Start () {
	    portals.Add(this);
	    groundMask = LayerMask.GetMask("ground");
	    quitAnimation.SetActive(false);
	    player = GameObject.Find("Player");
	}

    public Portal getLongestDistantPortal()
    {
        float maxDistance = Vector3.Distance(transform.position, transform.position);
        float tmpDistance = maxDistance;
        Portal farPortal = null;

        foreach (Portal p in portals)
        {
            tmpDistance = Vector3.Distance(transform.position, p.transform.position);
            if (tmpDistance > maxDistance && p != this)
            {
                maxDistance = tmpDistance;
                farPortal = p;
            }
        }

        return farPortal;
    }

    public Portal getShortestDistancePortal()
    {
        float minDistance = Vector3.Distance(transform.position, transform.position);
        float tmpDistance = minDistance;
        Portal closePortal = null;

        foreach (Portal p in portals)
        {
            tmpDistance = Vector3.Distance(transform.position, p.transform.position);
            if (tmpDistance < minDistance && p != this)
            {
                minDistance = tmpDistance;
                closePortal = p;
            }
            else if (minDistance == 0 && tmpDistance != 0)
            {
                minDistance = tmpDistance;
                closePortal = p;
            }
        }

        return closePortal;
    }

    public void teleport(Collider collider)
    {
        Vector3 distFromCenter = ((collider as CapsuleCollider).center*2 + collider.transform.root.position) - transform.position;
        
        Portal destination = getLongestDistantPortal();
        

        destination.teleportTo(collider, distFromCenter);
        isValid = false;
    }

    private void teleportTo(Collider collider, Vector3 distFromCenter)
    {
        collider.gameObject.GetComponent<IsPortable>().ChangeState(IsPortable.PortalState.PORTAL_STATE);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.position - (distFromCenter), out hit, groundMask))
        {
            collider.gameObject.transform.position = transform.position;
        }
        else
        {
            collider.gameObject.transform.position = transform.position - (distFromCenter);
            if (Physics.Raycast((collider as CapsuleCollider).center, transform.position, out hit, groundMask))
            {
                collider.gameObject.transform.position = transform.position;
            }
            
        }
        ClearPortalWithAnim();
        destroyPortal = true;
        isValid = false;
        AudioSource.PlayClipAtPoint(takePortalSound, transform.position);
    }

    void OnTriggerStay(Collider c)
    {
        Debug.Log("Something enter inside the portal " + GetInstanceID() + " :" + c.ToString());
        GameObject go = c.gameObject;
        IsPortable isPortable = go.GetComponent<IsPortable>();
        if (c.isTrigger == false && isPortable != null && isValid && isPortable.CurrentState() == IsPortable.PortalState.NORMAL_STATE && portals.Count > 1)
        {
            teleport(c);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        IsPortable isPortable = collider.gameObject.GetComponent<IsPortable>();

        if (isPortable != null)
        {
            if (isPortable.CurrentState() != IsPortable.PortalState.NORMAL_STATE)
                isPortable.ChangeState(IsPortable.PortalState.NORMAL_STATE);
            /*else if (isPortable.CurrentState() == IsPortable.PortalState.PORTAL_STATE)
                isPortable.ChangeState(IsPortable.PortalState.TRANSITION_STATE);*/
        }
    }

	// Update is called once per frame
	void Update ()
	{
	    if (destroyPortal)
	    {
	        if (destroyDelay > 0)
	        {
	            destroyDelay -= Time.deltaTime;
	        }
	        else
	        {
	            ClearPortal();
	        }
	    }
	}

    void FixedUpdate()
    {
        if (player != null && Math.Abs(Vector3.Distance(player.transform.position, transform.position)) < 2)
        {
            OnTriggerStay(player.GetComponent<CapsuleCollider>());
        }
    }
}
