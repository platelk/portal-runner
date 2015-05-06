using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLife : Life
{
    public int retry = 2;
    public CameraController cameraController;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public EndGameScreen endGameScreen;                         // Call end game screen when player die
    public AudioClip deathSound;
    public AudioSource gameMusic;

    private bool damaged = false;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
	}

    public override void hit(int damage)
    {
        base.hit(damage);
        damaged = true;

    }

    public override void death()
    {
        Portal.ClearPortal();
        if (life > 0)
            hit(life);
        gameMusic.Stop();
        EndGameScreen.endScreen.launchEndGameScreen();
        life = -1;
        Destroy(gameObject);
    }

}
