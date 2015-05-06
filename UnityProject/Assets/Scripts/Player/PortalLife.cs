using UnityEngine;
using System.Collections;

public class PortalLife : Life
{
    public float DestroyDistance;
    private Camera _camera;
    private Portal _portalComponent;
	// Use this for initialization
	void Start ()
	{
	    _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	    _portalComponent = GetComponent<Portal>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_camera.transform.position.z - transform.position.z > DestroyDistance)
	    {
	        death();
	    }
	}

    public override void death()
    {
        for (int i = 0; i < Portal.portals.Count; i++)
        {
            if (Portal.portals[i] == _portalComponent)
            {
                Portal.portals.RemoveAt(i);
                Destroy(gameObject);
            }
        }
    }
}
