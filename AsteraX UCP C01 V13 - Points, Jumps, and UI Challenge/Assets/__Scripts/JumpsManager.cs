using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpsManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    private int jumps = 3;
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

    private void SetJumps()
    {
        uiManager.SetJumpsUI(jumps);
    }
}
