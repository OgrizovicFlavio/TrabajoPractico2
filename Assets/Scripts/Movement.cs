using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.01f;
    public float angle = 10f;

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode rotateRight = KeyCode.E;
    public KeyCode rotateLeft = KeyCode.Q;
    public KeyCode randomColor = KeyCode.R;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKeyDown(rotateRight))
        {          
            transform.Rotate(0,0, -angle);
        }

        if (Input.GetKeyDown(rotateLeft))
        {
            transform.Rotate(0, 0, angle);
        }

        if (Input.GetKey(moveUp))
        {
            pos.y += speed;
        }

        if (Input.GetKey(moveDown))
        {
            pos.y -= speed;
        }

        if (Input.GetKey(moveRight))
        {
            pos.x += speed;
        }

        if (Input.GetKey(moveLeft))
        {
            pos.x -= speed;
        }

        if (Input.GetKeyUp(randomColor))
        {
            float red = Random.Range(0,1.0f);
            float green = Random.Range(0, 1.0f);
            float blue = Random.Range(0, 1.0f);

            spriteRenderer.color = new Color(red, green, blue);
        }

        transform.position = pos;
    }
}
