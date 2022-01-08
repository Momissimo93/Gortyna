using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    [SerializeField] private HeartsHealthVisual heartsHealthVisual;

    // Update is called once per frame
    void Update()
    {
        if(heartsHealthVisual)
        {
            if(heartsHealthVisual.CheckLifePoint() == 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        gameOverMenuUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
