using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 0.01f;
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;

    [Header("Rotation")]
    [SerializeField] private float rotationAngle = 10f;
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;

    [Header("Change Color")]
    [SerializeField] private KeyCode randomColor = KeyCode.R;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
            Move();
            Rotate();
            ChangeColor();

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

        if (Input.GetKey(moveRight))
        {
            pos.x += movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(moveLeft))
        {
            pos.x -= movementSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(rotateRight))
        {
            transform.Rotate(0, 0, rotationAngle);
        }

        if (Input.GetKeyDown(rotateLeft))
        {
            transform.Rotate(0, 0, -rotationAngle);
        }
    }
    
    private void ChangeColor()
    {
        if (Input.GetKeyUp(randomColor))
        {
            float red = Random.Range(0, 1.0f);
            float green = Random.Range(0, 1.0f);
            float blue = Random.Range(0, 1.0f);
            float alpha = Random.Range(0, 1.0f);

            spriteRenderer.color = new Color(red, green, blue, alpha);
        }
    }

    public void SetMovementSpeed(float newSpeed)
    {
        movementSpeed = newSpeed;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void SetRotationAngle(float newAngle)
    {
        if (newAngle < 0)
        {
            return;
        }
        rotationAngle = newAngle;
        if (rotationAngle >= 360f)
            rotationAngle -= 360f;
    }

    public float GetRotationAngle ()
    {
        return rotationAngle;
    }
}
