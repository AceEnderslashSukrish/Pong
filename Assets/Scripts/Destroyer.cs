using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public bool ballDestroyed = false;
    public GameObject player;
    private GameController gameControllerScript;
    public int scoreValue = 1;
    private Transform origin;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find game controller script on GameController Object");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player = GetComponent<Destroyer>().player;
        gameControllerScript.AddToScore(scoreValue, player);
        if (gameControllerScript.score1Text.text != "Player 1 Score: 3" && gameControllerScript.score2Text.text != "Player 2 Score: 3")
        {
            gameControllerScript.BallCreator();
        }
        
        Destroy(other);
        ballDestroyed = true;

        if (gameControllerScript.score1Text.text == "Player 1 Score: 3")
        {
            gameControllerScript.PlayerWin(gameControllerScript.Player1);
        }
        else if (gameControllerScript.score2Text.text == "Player 2 Score: 3")
        {
            gameControllerScript.PlayerWin(gameControllerScript.Player2);
        }
    }
}
