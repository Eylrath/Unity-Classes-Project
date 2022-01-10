using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuitMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Debug.Log("Ended");
        Application.Quit();
    }
}
