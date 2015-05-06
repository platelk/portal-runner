using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

    public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider collider)
    {
        Life life = collider.gameObject.GetComponent<Life>();

        if (life != null)
        {
            life.hit(damage);
        }
    }
}
