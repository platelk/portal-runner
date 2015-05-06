using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


/*
 * Create portal script
 * It will create a first portal on mouse down then the player can move (like a drag & drop) then will create the second one on the release
 * During the operation, the hint point will appear
 */
public class CreatePortal : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public GameObject portalHint;
    public AudioSource takePortalSource;

    private int groundMask;
    private int clicZoneMask;
    private int uiClicZoneMask;
    private float camRayLength = 100f;

	// Use this for initialization
	void Start ()
	{
	    groundMask = LayerMask.GetMask("ground");
	    clicZoneMask = LayerMask.GetMask("cliczone");
	    uiClicZoneMask = LayerMask.GetMask("UIClic");
        Portal.ClearPortal();
	}
	
	/*
     * Check if the "Fire1" button is DOWN to create a portal
     * Check if the "Fire1" button is active to display the touch indication
     */
	void LateUpdate ()
	{
        if (Input.GetButtonDown("Fire1") && (!EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject == null) && PauseManager.isPause == false)
	    {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (!Physics.Raycast(camRay, out floorHit, camRayLength, groundMask) &&
                Physics.Raycast(camRay, out floorHit, camRayLength, clicZoneMask) &&
                !Physics.Raycast(camRay, out floorHit, camRayLength, uiClicZoneMask))
            {
                if (Portal.portals.Count >= 2)
                {
                    Portal.ClearPortal();
                }
                
                Vector3 playerToMouse = floorHit.point;
                playerToMouse.x = 0f;
                Instantiate(portal, playerToMouse, portal.transform.rotation);
            }
	    }
	    if (Input.GetButton("Fire1"))
	    {
	        portalHint.SetActive(true);
	        portalHint.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	    }
	    else
	    {
	        portalHint.SetActive(false);
	    }
	}
}
