using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class HealthBar : MonoBehaviour
{

    public GameObject healthImage;
    public Life player;

    public GameObject[] healthIcon;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
	{
	    displayLife();
	}

    void displayLife()
    {
        for (int i = 0; i < healthIcon.Count(); i++)
        {
            healthIcon[i].SetActive((i < player.life) ? true : false);
        }
    }
}
