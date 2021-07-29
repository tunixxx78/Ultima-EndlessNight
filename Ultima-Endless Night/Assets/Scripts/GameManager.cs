using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartThisGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitThisGame()
    {
        Application.Quit();
    }

    public void GoBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
