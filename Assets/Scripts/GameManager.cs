using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] private Ball ball;
    [SerializeField] private float initialSpeed = 5f;

    [Header("Players")]
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    [Header("Transform")]
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;

    private bool isGameOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOn)
        {
            LaunchBall(); 
        }
    }

    private void LaunchBall()
    {
        ball.GetBallRigidBody2D().velocity = Vector2.zero;

        Vector2 randomDirection = GetRandomDirection();

        ball.GetBallRigidBody2D().AddForce(randomDirection * initialSpeed, ForceMode2D.Impulse);

        isGameOn = true;
    }
    private Vector2 GetRandomDirection()
    {
        // Creo una variable angle para definir un ángulo aleatorio.
        float angle;

        // Creo una variable randomChoice para definir un valor entre 0 y 1.
        float randomChoice = Random.Range(0f, 1f);

        if (randomChoice > 0.5f) //Si randomChoice es mayor a 0,5 (50% de probabilidad)...
        {
            // Lanzar hacia la derecha.
            if (randomChoice > 0.75f) //25% de probabilidad de que la bola salga casi horizontal (hacia el jugador 2).
            {
                // Casi horizontal.
                angle = Random.Range(-20f, 20f);
            }
            else
            {
                // Diagonal (hacia arriba o abajo).
                if (Random.value > 0.5f)
                    angle = Random.Range(30f, 60f);  // Diagonal hacia arriba-derecha.
                else
                    angle = Random.Range(-30f, -60f);  // Diagonal hacia abajo-derecha.
            }
        }
        else
        {
            // Lanzar hacia la izquierda.
            if (randomChoice < 0.25f) //25% de probabilidad de que la bola salga casi horizontal (hacia el jugador 1).
            {
                // Casi horizontal.
                angle = Random.Range(160f, 200f);
            }
            else
            {
                // Diagonal (hacia arriba o abajo).
                if (Random.value > 0.5f)
                    angle = Random.Range(120f, 150f);  // Diagonal hacia arriba-izquierda.
                else
                    angle = Random.Range(210f, 240f);  // Diagonal hacia abajo-izquierda.
            }
        }

        // Convierto el ángulo a radianes para luego calcular la nueva dirección aleatoria.
        float angleRad = angle * Mathf.Deg2Rad; //La conversión de grados a radianes es: radianes = grados * π / 180. 

        //Esta función devuelve un vector 2 con dos componentes (x,y). Estos componentes vienen de las funciones seno y coseno aplicadas al ángulo en radianes.
        //Normalizo el vector para asegurarme que siempre tenga una magnitud de 1, así la bola se mueve a una velocidad constante en cualquier dirección.
        return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;
    }
    public void ResetPositions()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
        ball.GetBallRigidBody2D().velocity = Vector2.zero;
        ResetRotation();
        isGameOn = false;
    }

    public void ResetRotation()
    {
        paddle1Transform.eulerAngles = new Vector3(0, 0, 90);
        paddle2Transform.eulerAngles = new Vector3(0, 0, 90);
    }
}
