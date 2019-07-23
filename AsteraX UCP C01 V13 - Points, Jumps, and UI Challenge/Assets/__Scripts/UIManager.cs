using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains methods for setting up the UI
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text jumpsText = null;

    /// <summary>
    /// Setup score UI
    /// </summary>
    /// <param name="score">player's score</param>
    public void SetScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Setup jumps UI
    /// </summary>
    /// <param name="jumps">player's jumps</param>
    public void SetJumpsUI(int jumps)
    {
        jumpsText.text = jumps.ToString();
    }
}
