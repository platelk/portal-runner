using UnityEngine;
using System.Collections;

public class PortalLimitation : MonoBehaviour
{

    public int limit = 2;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        limitPortal();
	}

    public void limitPortal()
    {
        while (Portal.portals.Count > limit && Portal.portals.Count > 0)
        {
            if (Portal.portals[0].gameObject != null && Portal.portals[0].gameObject.activeSelf == true)
            {
                Portal.portals[0].gameObject.SetActive(false);
                Destroy(Portal.portals[0].gameObject);
            }

            Portal.portals.RemoveAt(0);
        }
    }
}
