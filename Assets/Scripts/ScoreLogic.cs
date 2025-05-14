using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    private int score;
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void IncreaseScore()
    {
        score++;
    }
}


