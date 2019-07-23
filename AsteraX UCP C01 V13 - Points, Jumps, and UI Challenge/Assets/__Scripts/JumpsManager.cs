using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles managing jumps(player's lifes)
/// Contains player's Jumps property and a method for setting jumps
/// </summary>
public class JumpsManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private int jumps = 3;

    /// <summary>
    /// Player's jumps
    /// </summary>
    public int Jumps
    {
        get { return jumps; }
        set
        {
            jumps = value;
            SetJumps();
        }
    }

    private void Awake()
    {
        SetJumps();
    }

    /// <summary>
    /// Setup jumps UI
    /// </summary>
    private void SetJumps()
    {
        uiManager.SetJumpsUI(jumps);
    }
}
