using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backOneScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            AppQuit();
        }
    }

    public void AppQuit()
    {
        Application.Quit();
    }

    public void enableCanvas(Button button, Canvas canvas)
    {
        //button.onClick.AddListener(canvas.gameObject.SetActive(true));
    }

    public void DisableCanvas(Canvas canvas)
    {

    }
}
