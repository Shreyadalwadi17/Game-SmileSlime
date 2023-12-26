using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreValueText;
    public TMP_Text actualValueText;
    public int scoreValue;
    public int actualValue;
    public LevelManager levelManager;
    public Ball ball;

    private void Update()
    {
        LevelScore();
        if(scoreValue==actualValue)
        {
            levelManager.ChangeLevel();
            ball.ResetBallPosition();

        }
    }
    public void ScoreIncrese()
    {
        Debug.Log("Increase score");
        scoreValue = scoreValue + 1;
        scoreValueText.text = scoreValue.ToString();
    }
    public void ResetScore()
    {
        scoreValue = 0;
        scoreValueText.text = scoreValue.ToString();
    }
    public void LevelScore()
    {
        switch (levelManager.lvlCount)
        {
            case 0:
                actualValue = 1;
                actualValueText.text = actualValue.ToString();
                break;

            case 1:
                actualValue = 2;
                actualValueText.text = actualValue.ToString();
                break;


        }
    }
}
