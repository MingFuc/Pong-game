using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSelect : MonoBehaviour
{
    public static RoundSelect instance;
    public int defaultRound { get; private set; } = 3;
    public event Action onPressRoundSelect;
    public void PressRoundSelect()
    {
        if (onPressRoundSelect != null)
        {
            onPressRoundSelect();
        }
    }
    private void Awake()
    {
        instance = this;
    }
    public void ThreeRound()
    {
        defaultRound = 3;
        PressRoundSelect();
    }
    public void FiveRound()
    {
        defaultRound = 5;
        PressRoundSelect();
    }
    public void TenRound()
    {
        defaultRound = 10;
        PressRoundSelect();
    }
}
