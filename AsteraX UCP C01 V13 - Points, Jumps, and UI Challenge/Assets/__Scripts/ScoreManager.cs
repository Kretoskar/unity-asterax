using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            SetScore();
        }
    }

    private void Awake()
    {
        SetScore();
    }

    public void SetScore()
    {
        uiManager.SetScoreUI(score);
    }
}
