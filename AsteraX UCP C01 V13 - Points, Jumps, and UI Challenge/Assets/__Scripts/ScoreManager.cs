using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles managing score
/// Contains the score property and a method for setting score
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private int score = 0;
    /// <summary>
    /// Player's score
    /// </summary>
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

    /// <summary>
    /// Setup score UI and playerprefs
    /// </summary>
    public void SetScore()
    {
        uiManager.SetScoreUI(score);
        PlayerPrefs.SetInt("Score", score);
    }
}
