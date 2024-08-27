using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    //[SerializeField] private KeyCode moveRight = KeyCode.D;
    //[SerializeField] private KeyCode moveLeft = KeyCode.A;

    void Update()
    {
       Move();
    }

    private void Move()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(moveUp))
        {
            pos.y += movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(moveDown))
        {
            pos.y -= movementSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }

    public void SetMovementSpeed(float newSpeed)
    {
        movementSpeed = newSpeed;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    /* Movimiento en eje X
    
    if (Input.GetKey(moveRight))
        {
            pos.x += movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(moveLeft))
        {
            pos.x -= movementSpeed * Time.deltaTime;
        }
    */
}
