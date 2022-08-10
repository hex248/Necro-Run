using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartScreen()
    {
        SceneManager.LoadScene("Start");
    }
    public void PlayScreen()
    {
        SceneManager.LoadScene("Play");
    }
    public void DeathScreen()
    {
        SceneManager.LoadScene("Death");
    }
}
