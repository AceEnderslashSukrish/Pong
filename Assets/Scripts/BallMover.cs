using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Vector2 speed;
    private Vector2 directionMove;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //Vector2 directionMove = new Vector2(1, 0);
        //speed = new Vector2(2, 1);

        directionMove = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));

        while (directionMove == Vector2.zero || directionMove == Vector2.down || directionMove == Vector2.up)
        {
            directionMove = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        }
        
        speed = new Vector2(Random.Range(3, 5), Random.Range(3, 5));

        rBody.velocity = directionMove * speed;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            directionMove = new Vector2(-directionMove.x, directionMove.y);
            rBody.velocity = directionMove * speed;
        }
        else
        {
            directionMove = new Vector2(directionMove.x, -directionMove.y);
            rBody.velocity = directionMove * speed;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
