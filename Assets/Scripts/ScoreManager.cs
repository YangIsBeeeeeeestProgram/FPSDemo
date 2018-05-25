using UnityEngine;

public class ScoreManager: Singleton<ScoreManager> {

    public int score = 0;



    public void AddScore(int value)
    {
        score += value;
    }
}