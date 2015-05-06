using System;
using System.Collections.Generic;
//using System.IO;
// using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

/*
 * ScoreManager is a unique class that will record the score of the player base on :
 *      - The distance from the start of the player
 *      - The bonus earn by the player
 */

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager ScoreManagerInst;    // Singleton
    public int BonusPoint;                          // Bonus point earn by the player
    public int Multiplicator;                       // Multiplcator
    public GameObject Player;                       // Reference of the player
    public Button SaveScoreButton;
    public InputField ScoreNameInput;
    public Text ScoreText;                          // Text element
    public String Text;                             // Text to display before the score

    private int _score;
    private ScoresData _scores;
    // Use this for initialization
    private void Start()
    {
        if (ScoreManagerInst == null)
        {
            ScoreManagerInst = this;
            _scores = LoadScore();
            if (SaveScoreButton)
            {
                SaveScoreButton.onClick.AddListener(() =>
                {
                    SaveScore(ScoreNameInput.text);
                    SaveScoreButton.gameObject.SetActive(false);
                    ScoreNameInput.gameObject.SetActive(false);
                });   
            }
        }
        else if (ScoreManagerInst != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (ScoreText)
            ScoreText.text = Text + GetScore();
    }

    // Total score
    public int GetScore()
    {
        return BasePoint() + BonusPoint;
    }

    // Add bonus point
    public void AddPoint(int value)
    {
        BonusPoint += value;
    }

    // Point earn base on the distance from the start
    public int BasePoint()
    {
        if (Player != null)
        {
            var tmpScore = (int) (Player.transform.position.z*Multiplicator);
            if (tmpScore >_score)
                _score = tmpScore;
        }

        return _score;
    }

    // Save
    public void SaveScore(String name)
    {
        _scores.AddScore(new ScoreEntry(name, GetScore()));

        for (int i = 0; i < _scores.scores.Count; i++)
        {
            PlayerPrefs.SetString("name" + i, _scores.scores[i].name);
            PlayerPrefs.SetInt("score" + i, _scores.scores[i].score);
        }

        PlayerPrefs.Save();
        /*
         * Comment this part to be compatible with windows phone 8.1 because Formatter doesn't exist
            var bf = new BinaryFormatter();
            var file = File.Open(Application.persistentDataPath + "/scoreBoard.data", FileMode.OpenOrCreate);

            bf.Serialize(file, _scores);
            file.Close();
         */
    }

    // Loading recorded scores
    public ScoresData LoadScore()
    {
        var data = new ScoresData();

        String name = PlayerPrefs.GetString("name" + 0);
        for (int i = 0; !string.IsNullOrEmpty(name); i++)
        {

            data.AddScore(new ScoreEntry(PlayerPrefs.GetString("name" + i), PlayerPrefs.GetInt("score" + i)));
            name = PlayerPrefs.GetString("name" + (i+1));
        }
        /* bf = new BinaryFormatter();
        var file = File.Open(Application.persistentDataPath + "/scoreBoard.data", FileMode.Open);
        var data = (ScoresData) bf.Deserialize(file);
        file.Close();*/
        return data;
    }
}

[Serializable]
public class ScoresData
{
    public List<ScoreEntry> scores;

    public ScoresData()
    {
        scores = new List<ScoreEntry>();
    }

    public void AddScore(ScoreEntry se)
    {
        scores.Add(se);
    }
}

[Serializable]
public class ScoreEntry
{
    public String name;
    public int score;

    public ScoreEntry(String name, int score)
    {
        this.name = name;
        this.score = score;
    }
}