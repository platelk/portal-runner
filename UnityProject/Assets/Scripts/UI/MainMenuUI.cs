using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button quit;

	// Use this for initialization
	void Start () {
        quit.onClick.AddListener(QuitGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Start the game
    void StartGame()
    {
        Application.LoadLevel("MyGame");
    }


    // Quit the entire application
    void QuitGame()
    {
        Application.Quit();
    }
}
