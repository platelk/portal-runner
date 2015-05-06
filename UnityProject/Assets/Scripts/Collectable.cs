using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerLife>() != null)
        {
            ScoreManager.ScoreManagerInst.AddPoint(500);
            Destroy(gameObject);
        }
    }
}
