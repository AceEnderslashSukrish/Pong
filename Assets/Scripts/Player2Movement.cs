using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private Rigidbody2D rBody;
    public Vector2 speed;
    public float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = GetComponent<Transform>().position.x;
        float vert = Input.GetAxis("Vertical2");
        // Debug.Log(vert);

        Vector2 newVelocity = new Vector2(0, vert);
        rBody.velocity = newVelocity * speed.y;

        // Restrict the player from leaving the play area
        float newY;

        newY = Mathf.Clamp(rBody.position.y, minY, maxY);

        rBody.position = new Vector2(horiz, newY);
    }
}
