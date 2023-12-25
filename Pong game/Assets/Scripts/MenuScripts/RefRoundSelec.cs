using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefRoundSelec : MonoBehaviour
{
    public static RefRoundSelec instance;
    public int refDefaultRound;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }
    private void Start()
    {
        UpdateRound();
        
    }
    private void Update()
    {
        RoundSelect.instance.onPressRoundSelect += UpdateRound;
    }
    void UpdateRound()
    {
        refDefaultRound = RoundSelect.instance.defaultRound;
    }
    private void OnDestroy()
    {
        RoundSelect.instance.onPressRoundSelect -= UpdateRound;
    }
}
