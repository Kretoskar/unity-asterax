using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles reloading game scene
/// and setting up the ui for gameover screen
/// </summary>
public class GameOver : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    private void Start()
    {
        SetScoreUI();
        Invoke("ReloadGameScene", 3);
    }

    /// <summary>
    /// Setup score text 
    /// </summary>
    private void SetScoreUI()
    {
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    /// <summary>
    /// Load the first scene
    /// </summary>
    private void ReloadGameScene()
    {
        SceneManager.LoadScene(0);
    }
}
