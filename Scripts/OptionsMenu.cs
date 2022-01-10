using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public InputField iField;

    public void setItems()
    {
        
        
        string text = iField.text;
        int number = int.Parse(text);
        if(number > 10 || number < 1)
        {
            number = 7;
        }
        PlayerPrefs.SetInt("itemsNumber", number);
    }
}
