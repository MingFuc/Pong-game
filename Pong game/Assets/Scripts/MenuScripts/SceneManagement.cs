using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    private Button startButton;

    void Start()
    {
        startButton = GetComponent<Button>();
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
