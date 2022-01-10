using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Static as we want do not want to reference this specific pause menu script-we want to check from other script if the game is pause or not
    [HideInInspector] public bool gameIsPause = false;
    [SerializeField] private HeartsHealthVisual heartsHealthVisual;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && heartsHealthVisual.CheckLifePoint() > 0)
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
        Time.timeScale = 1f;
        OrbTextScript.OrbAmount = 0;
        ScoreTextScript.coinAmount = 0;
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

