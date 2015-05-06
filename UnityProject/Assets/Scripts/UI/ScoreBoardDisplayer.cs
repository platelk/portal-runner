using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ScoreBoardDisplayer : MonoBehaviour
{

    public GameObject[] ScoreTextEntry;
    public Vector3 StartPosition;
    public float LineSpace;
	// Use this for initialization
	void Start ()
	{
	    ScoresData scores = GetComponent<ScoreManager>().LoadScore();

        scores.scores.Sort(ScoreComparaison);

	    for (int i = 0; i < ScoreTextEntry.Count(); i++)
	    {
	        if (i < scores.scores.Count)
	            ScoreTextEntry[i].GetComponent<Text>().text = (i+1) + ". " + scores.scores[i].name + ": " + scores.scores[i].score;
	        else
	        {
	            ScoreTextEntry[i].SetActive(false);
	        }
	    }
	}

    private int ScoreComparaison(ScoreEntry scoreEntry, ScoreEntry entry)
    {
        return entry.score - scoreEntry.score;
    }

    // Update is called once per frame
	void Update () {
	
	}
}
