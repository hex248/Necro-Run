using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ScreenType
{
    start,
    death,
    play
}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject newHighScore;

    public ScreenType screen;

    void Start()
    {
        if (screen != ScreenType.play)
        {
            highScoreText.text = $"High\nScore: {PlayerPrefs.GetInt("highScore")}";
            if (screen == ScreenType.death)
            {
                scoreText.text = $"You\nScored: {PlayerPrefs.GetInt("recentScore")}";
                if (PlayerPrefs.GetString("newHighScore") == "true")
                {
                    newHighScore.SetActive(true);
                }
                else
                {
                    newHighScore.SetActive(false);
                }
            }
            else
            {
                scoreText.gameObject.SetActive(false);
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
