using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Variables for the game
    [Header("Game Objects")]
    public GameObject ball;
    public GameObject Player1;
    public GameObject Player2;
    private Destroyer destroyerScript;

    [Header("UI Objects")]
    public Text score1Text;
    public Text score2Text;
    public GameObject player1WinText;
    public GameObject player2WinText;

    private int score1 = 0;
    private int score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToScore(int scoreValueToAdd, GameObject Player)
    {
        if (Player == Player1)
        {
            score1 += scoreValueToAdd;
        }
        else if (Player == Player2)
        {
            score2 += scoreValueToAdd;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        score1Text.text = $"Player 1 Score: {score1}";
        score2Text.text = $"Player 2 Score: {score2}";
    }

    public void BallCreator()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }
}
