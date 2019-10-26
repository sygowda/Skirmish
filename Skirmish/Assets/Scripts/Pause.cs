using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseButton, pausePanel;
    // Update is called once per frame
    public void OnPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }
}
