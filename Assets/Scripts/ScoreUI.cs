using UnityEngine;
using UnityEngine.UI;

public class ScoreUI: MonoBehaviour {

    [SerializeField]
    Text scoreText;



    private void Update()
    {
        scoreText.text = ScoreManager.Instance.score.ToString();
    }
}