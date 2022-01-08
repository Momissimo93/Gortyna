using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Static as we want do not want to reference this specific pause menu script-we want to check from other script if the game is pause or not
    public bool gameIsPause = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        StartCoroutine(ResumeCoroutine());
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator ResumeCoroutine()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        gameIsPause = false;
    }

}

