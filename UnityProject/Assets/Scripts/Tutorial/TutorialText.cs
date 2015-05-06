using UnityEngine;
using System.Collections;
using System.Linq;

public class TutorialText : MonoBehaviour {

    public float speed;
    public float wait;

    public GameObject[] textToDisplay;
    public PauseManager pm;

    private float internalTimer;
    private int internalIdx;

    // Use this for initialization
    void Start()
    {
        internalTimer = wait;
        internalIdx = 0;
        foreach (GameObject g in textToDisplay)
        {
            g.SetActive(false);
        }
        textToDisplay[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer -= Time.deltaTime;
        if (internalTimer <= 0)
        {
            internalTimer = wait;
            if (internalIdx < textToDisplay.Count())
                textToDisplay[internalIdx].SetActive(false);
            internalIdx += 1;
            if (internalIdx < textToDisplay.Count())
                textToDisplay[internalIdx].SetActive(true);
            if (internalIdx >= textToDisplay.Count())
            {
                pm.pauseGame();
                Destroy(gameObject);
            }
        }

    }
}
