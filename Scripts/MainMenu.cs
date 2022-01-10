using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("itemsNumber") == 0)
            PlayerPrefs.SetInt("itemsNumber", 7);
    }
    
    public void QuitGame()
    {
        Debug.Log("Ended");
        Application.Quit();
    }
}
