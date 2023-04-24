using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreScriptableObject scoreSO;
    public ScoreVisual scoreVisual;

    public void AddP1()
    {
        scoreSO.P1Score += 1;
        scoreVisual.UpdateScoreText();
    }
    public void AddP2()
    {
        scoreSO.P2Score += 1;
        scoreVisual.UpdateScoreText();
    }
    public void ResetScore()
    {
        scoreSO.P1Score = 0;
        scoreSO.P2Score = 0;
        scoreVisual.UpdateScoreText();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
