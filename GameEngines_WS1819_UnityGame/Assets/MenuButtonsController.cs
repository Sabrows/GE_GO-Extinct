using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsController : MonoBehaviour
{

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(0);
    }
}