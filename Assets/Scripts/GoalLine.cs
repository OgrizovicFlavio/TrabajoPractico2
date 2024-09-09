using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] Player otherPlayer;
    [SerializeField] GameManager gameManager;
    [SerializeField] LayerMask ballLayerMask;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Utilites.CheckLayerInMask(ballLayerMask, other.gameObject.layer))
        {
            otherPlayer.AddScore();
            gameManager.ResetPositions();
        }
    }
}
