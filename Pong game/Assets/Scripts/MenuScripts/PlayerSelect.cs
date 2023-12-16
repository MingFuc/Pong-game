using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public bool choose1Player;
    public static PlayerSelect instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnePLayer()
    {
        choose1Player = true;
        SceneManager.LoadScene(1);
    }
    public void TwoPlayer()
    {
        choose1Player = false;
        SceneManager.LoadScene(1);
    }
}
