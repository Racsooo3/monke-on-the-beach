using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObject/Score")]
public class ScoreScriptableObject : ScriptableObject
{
    public int P1Score;
    public int P2Score;
}
