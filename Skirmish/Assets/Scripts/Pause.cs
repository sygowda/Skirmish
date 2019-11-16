using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseButton, pausePanel;
    // Update is called once per frame
    public void OnPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Pause was clicked");
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    
}
