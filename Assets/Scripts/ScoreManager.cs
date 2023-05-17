using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform ball; // Reference to the Ball GameObject
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component

    public int score = 0; // Current score
    private float currentLevel = 0f; // Current score

    private void Update()
    {
        
        if (ball.position.y < currentLevel)
        {
            score++;
            currentLevel -= 3f;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
