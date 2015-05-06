using UnityEngine;
using System.Collections;

public class SaveCheckPoint : MonoBehaviour
{
    public CheckPoint lastCheckPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void saveCheckPoint(CheckPoint cp)
    {
        lastCheckPoint = cp;
    }

    public void loadLastCheckPoint()
    {
        gameObject.transform.position = lastCheckPoint.gameObject.transform.position;
    }
}
