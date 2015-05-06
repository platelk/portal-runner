using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundButtonScript : MonoBehaviour
{
    public Text buttonText;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
                buttonText.text = "Activate\nSound";
            }
            else
            {
                AudioListener.volume = 1;
                buttonText.text = "Mute\nSound";
            }
        });
	}

    void Awake()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
