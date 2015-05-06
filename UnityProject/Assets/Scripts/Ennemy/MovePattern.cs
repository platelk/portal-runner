using UnityEngine;
using System.Collections;

/**
 * MovePattern is a generic class to implement Monster moving pattern
 */
public class MovePattern : MonoBehaviour
{
    
    public Vector3 direction; // the global direction
    public float speed; // The speed of the monster
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    move();
	}

    public virtual void move()
    {
        transform.position += (direction*speed*Time.deltaTime);
    }
}
