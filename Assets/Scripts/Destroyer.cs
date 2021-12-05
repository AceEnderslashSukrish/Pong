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
        gameControllerScript.BallCreator();
        Destroy(other);
        ballDestroyed = true;        
    }
}
