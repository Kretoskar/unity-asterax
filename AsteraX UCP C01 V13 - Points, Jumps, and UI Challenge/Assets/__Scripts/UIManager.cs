using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text jumpsText = null;

    public void SetScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
