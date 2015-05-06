using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    private Animator anim;
    private bool sideCollision = false;
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponentInChildren<Animator>();
	}

    public float move(Vector3 direction)
    {
        Vector3 oldPotition = transform.position;

        
        if (sideCollision)
        {
            return 0.0f;
        }
        anim.SetBool("IsWalking", (direction.x != 0f || direction.y != 0f || direction.z != 0f));
        transform.position = transform.position + (direction*speed) * Time.deltaTime;
        return transform.position.z - oldPotition.z;
    }

    public void launchPortalAnim()
    {
        anim.SetTrigger("Shoot");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.isTrigger)
            sideCollision = true;
    }

    void OnTriggerExit(Collider collider)
    {
        if (!collider.isTrigger)
            sideCollision = false;
    }
}
