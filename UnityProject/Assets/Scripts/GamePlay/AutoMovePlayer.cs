using UnityEngine;
using System.Collections;

public class AutoMovePlayer : MonoBehaviour
{
    public Vector3 direction;
    public PlayerController playerController;
    public Life playerLife;
    public ScoreManager scoreManager;
    public float speedIncrease;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (playerLife.life == 0)
	        return;
	    Vector3 tmp = direction + SpeedModifier()+SpeedModifier() / 2;
        if (playerController != null)
	        playerController.move(tmp);
	}

    public Vector3 SpeedModifier()
    {
        if (playerController == null)
            return direction;
        return (direction*(speedIncrease*(playerController.transform.position.z/200f)%5));
    }
}
