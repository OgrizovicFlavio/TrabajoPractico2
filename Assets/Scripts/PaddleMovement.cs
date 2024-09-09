using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private float movementSpeed;

    private int multiplier = 100;
    private float yBound = 3.4f;
    private Rigidbody2D paddleRb2D;

    private void Awake()
    {
        paddleRb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(moveUp))
        {
            paddleRb2D.AddForce(Vector3.up * movementSpeed * Time.deltaTime * multiplier, ForceMode2D.Impulse);
        }

        if (Input.GetKey(moveDown))
        {
            paddleRb2D.AddForce(Vector3.down * movementSpeed * Time.deltaTime * multiplier, ForceMode2D.Impulse);
        }

        //Limito la posición de las paletas entre los límites de la variable yBound.
        pos.y = Mathf.Clamp(pos.y, -yBound, yBound);

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

    //[SerializeField] private KeyCode moveRight = KeyCode.D;
    //[SerializeField] private KeyCode moveLeft = KeyCode.A;
    
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
