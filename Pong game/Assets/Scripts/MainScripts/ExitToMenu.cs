using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(1);
    }
}
