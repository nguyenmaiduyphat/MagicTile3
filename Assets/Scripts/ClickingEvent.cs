using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickingEvent : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    [SerializeField] GameObject menu;
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }



    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
