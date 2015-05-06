using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // Check if something enter inside the DeadZone, and destroy it
    void OnTriggerEnter(Collider c)
    {
        Life l = c.gameObject.GetComponent<Life>();
        if (l)
        {
            l.death();
        }
        /*else
        {
            Destroy(c.gameObject);  
        }*/
    }
}
