using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour
{
    public int maxLife = 3;
    public int life = 3;
    public float invicibilityTime = 1f;
    public AudioSource hitSound;

    private float hitTimer;
	// Use this for initialization
	void Start ()
	{
	    hitTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (hitTimer > 0f)
	    {
	        hitTimer -= Time.deltaTime;
	    }
	}

    public virtual void hit(int damage)
    {
        if (hitTimer > 0)
            return;
        if (hitSound)
            hitSound.Play();
        life -= damage;
        if (life < 0)
            life = 0;
        if (life <= 0)
            death();
        hitTimer = invicibilityTime;
    }

    public virtual void death()
    {
        Destroy(this.gameObject);
    }
}
