using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreVisual : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public ScoreScriptableObject scoreSO;
    private void Start()
    {
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        Debug.Log(scoreSO.P1Score + ":" + scoreSO.P2Score);
        Score.text = scoreSO.P1Score + ":" + scoreSO.P2Score;
    }

}
