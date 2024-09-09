using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] private Rigidbody2D ballRb2D;
    [SerializeField] private float bonusForce = 0.5f;

    [Header("Layers")]
    [SerializeField] private LayerMask paddleMask;
    [SerializeField] private LayerMask goalLine;

    private void Awake()
    {
        ballRb2D = GetComponent<Rigidbody2D>();       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AddBonusForce(other);
    }

    private void AddBonusForce(Collision2D other)
    {
        if (Utilites.CheckLayerInMask(paddleMask, other.gameObject.layer))
        {
            Vector2 direction = ballRb2D.velocity.normalized;
            ballRb2D.AddForce(direction * bonusForce, ForceMode2D.Impulse);
        }
    }

    public Rigidbody2D GetBallRigidBody2D()
    {
        return ballRb2D;
    }
}
