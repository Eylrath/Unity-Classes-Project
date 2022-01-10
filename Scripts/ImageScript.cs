using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    public Sprite[] spriteList;
    public Image foundLetters;
    public Text pressN;
    public Text pressP;

    private int foundItems;
    private int allItems;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        allItems = PlayerPrefs.GetInt("itemsNumber");
        foundItems = PlayerPrefs.GetInt("foundItems");
        foundLetters.enabled = false;
        index = 0;
        pressP.enabled = false;
        pressN.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        foundItems = PlayerPrefs.GetInt("foundItems");
        
        if (Input.GetKeyDown(KeyCode.I) && foundItems > 0)
        {
            foundLetters.enabled = !foundLetters.enabled;
        }

        if (foundLetters.enabled)
        {
            pressP.enabled = true;
            pressN.enabled = true;
            foundLetters.sprite = spriteList[index];
            if (Input.GetKeyDown(KeyCode.N))
            {
                index++;
                //Debug.Log("n pressed");
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                index--;
                //Debug.Log("p pressed");
            }
            if (index < 0)
                index = foundItems - 1;
            if (index >= foundItems)
                index = 0;
        }
        else
        {
            pressP.enabled = false;
            pressN.enabled = false;
        }
    }
}
