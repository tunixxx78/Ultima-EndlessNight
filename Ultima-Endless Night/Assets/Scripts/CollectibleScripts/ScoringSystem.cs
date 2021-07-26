using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public static int theScore;
    [SerializeField] Text scoreText, highScoreText;
    [SerializeField] GameObject gameOverStuff, scoreTextObject;

    private void Update()
    {
        scoreText.text = theScore.ToString();

        highScoreText.text = theScore.ToString();

        if (theScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", theScore);
        }
    }

    public void ShowGameOverStuff()
    {
        gameOverStuff.SetActive(true);
        scoreTextObject.SetActive(false);
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("Level1");
    }
}
