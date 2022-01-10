using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextMod : MonoBehaviour
{
    public Text updateText;
    public string message;
    private int foundItems;
    private int allItems;

    void Start()
    {
        allItems = PlayerPrefs.GetInt("itemsNumber");
        foundItems = PlayerPrefs.GetInt("foundItems");
        updateText.text = foundItems.ToString() + " / " + allItems.ToString();
    }
    void Update()
    {
        if (foundItems != PlayerPrefs.GetInt("foundItems"))
        {
            foundItems = PlayerPrefs.GetInt("foundItems");
            updateText.text = foundItems.ToString() + " / " + allItems.ToString();
        }
    }
}