using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int Highscore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI HighscoreUI;

     void Start()
    {
        
        Highscore = PlayerPrefs.GetInt("highscore"); 
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString();
        HighscoreUI.text = Highscore.ToString();

        if (score > Highscore)
        {
            Highscore = score;
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "ScoreUp")
        {
            score++;
        }
    }
}
