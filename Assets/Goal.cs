using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Goal;

public class Goal : MonoBehaviour
{
    /// When the opposite player triggers the collider while holding a ball,
    /// the opponent gains one point
    /// everything resets too <summary>
    /// When the opposite player triggers the collider while holding a ball,
    /// </summary>

    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    public enum Player
    {
        player1,
        player2
    }

    public Player myPlayerId;

    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.gameObject.CompareTag("Player")) return;
        if (!coll.gameObject.GetComponent<GrabBall>().ballIsGrabbed) return;

        if (myPlayerId == Player.player1)
        {
            scoreManager.AddP1();
        } else
        {
            scoreManager.AddP2();
        }

        SceneManager.LoadScene(0);
    }


}
