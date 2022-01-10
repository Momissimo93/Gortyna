using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    [SerializeField] private HeartsHealthVisual heartsHealthVisual;
    [SerializeField] private Door door;

    // Update is called once per frame
    void Update()
    {
        CheckLifePoints();
        CheckOrbsAmount();
    }

    private void CheckLifePoints()
    {
        if (heartsHealthVisual)
        {
            if (heartsHealthVisual.CheckLifePoint() <= 0)
            {
                GameOver();
            }
        }
    }
    private void CheckOrbsAmount()
    {
        if (door)
        {
            if (door.enoughOrbs == true)
            {
                MainMenu();
            }
        }
    }
    void GameOver()
    {
        OrbTextScript.OrbAmount = 0;
        ScoreTextScript.coinAmount = 0;
        gameOverMenuUI.SetActive(true);
    }

    public void Restart()
    {
        OrbTextScript.OrbAmount = 0;
        ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        OrbTextScript.OrbAmount = 0;
        ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
