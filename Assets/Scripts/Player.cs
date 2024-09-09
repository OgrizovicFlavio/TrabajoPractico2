using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int score;

    [SerializeField] private TMP_Text paddleScoreText;

    public void AddScore()
    {
        score++;
        paddleScoreText.text = score.ToString();
    }
}
