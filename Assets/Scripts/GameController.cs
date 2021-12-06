using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject restartTextObject;

    private int score1 = 0;
    private int score2 = 0;
    private bool player1Win = false;
    private bool player2Win = false;
    private bool restart = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
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

    public void PlayerWin(GameObject Player)
    {
        if (Player == Player1)
        {
            player1Win = true;
            player1WinText.SetActive(true);
        }
        else if (Player == Player2)
        {
            player2Win = true;
            player2WinText.SetActive(true);
        }
        restart = true;
        restartTextObject.SetActive(true);
    }
}
