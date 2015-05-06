using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class EndGameScreen : MonoBehaviour
{
    public GameObject player;
    public GameObject gamePlay;
    public static EndGameScreen endScreen;
    public AudioClip deathSound;

	// Use this for initialization
	void Start ()
	{
	    endScreen = this;
	    gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     public void launchEndGameScreen()
     {
         PauseManager.isPause = true;
         AudioSource.PlayClipAtPoint(deathSound, transform.position);
         gameObject.SetActive(true);
         Time.timeScale = 1;
    }
}
