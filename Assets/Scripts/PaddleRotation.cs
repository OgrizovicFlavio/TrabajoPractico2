using UnityEngine;

public class PaddleRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private KeyCode rotateToRight = KeyCode.Q;
    [SerializeField] private KeyCode rotateToLeft = KeyCode.E;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D paddleRb2D;
    private int multiplier = 100;

    private void Awake()
    {
        paddleRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetKey(rotateToRight))
        {
            paddleRb2D.AddTorque(-rotationSpeed * Time.deltaTime * multiplier, ForceMode2D.Impulse);
        }

        if (Input.GetKey(rotateToLeft))
        {
            paddleRb2D.AddTorque(rotationSpeed * Time.deltaTime * multiplier, ForceMode2D.Impulse);
        }
    }

    public void SetRotationSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }
}
