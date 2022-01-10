using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckingItems : MonoBehaviour
{
    // Start is called before the first frame update
    public Text displayText;
    public AudioSource musicPlayer;

    public AudioClip good;
    public AudioClip bad;
    void Start()
    {
        int foundItems = PlayerPrefs.GetInt("foundItems");
        int itemsNumber = PlayerPrefs.GetInt("itemsNumber");
        if(foundItems != itemsNumber)
        {
            musicPlayer.clip = bad;
            musicPlayer.Play();
            int leftItems = itemsNumber - foundItems;
            displayText.text = "You have failed! Not only you have not found";
            if (leftItems == 1)
                displayText.text += "1 last piece ";
            else
                displayText.text += leftItems.ToString() + " pieces ";
            displayText.text += "But also witnessed the flood take the city. With you within its walls.";
        }
        else
        {
            musicPlayer.clip = good;
            musicPlayer.Play();
         
        }
    }



}
