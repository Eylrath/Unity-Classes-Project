using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    private GameObject[] Items;

    public float maxDistance;
    public int maxTime = 120;
    public Text pressE;

    private Vector3 playerPosition;
    private Vector3 itemPosition;
    private float distance;
    private int foundItems;
    private int itemsNumber;
    private bool closeTo;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Items = GameObject.FindGameObjectsWithTag("Items");
        foundItems = 0;
        PlayerPrefs.SetInt("foundItems", foundItems);
        itemsNumber = PlayerPrefs.GetInt("itemsNumber");
        timer = 0f;
        pressE.enabled = false;
        closeTo = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        RaycastHit hit = new RaycastHit();
        bool stillClose = false;

        foreach (GameObject item in Items)
        {
            
            if (item.activeSelf)
            {
                playerPosition = transform.position;
                itemPosition = item.transform.position;
                distance = Vector3.Distance(playerPosition, itemPosition);
                if (distance < maxDistance && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    stillClose = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        item.SetActive(false);
                        foundItems++;
                        PlayerPrefs.SetInt("foundItems", foundItems);
                        stillClose = false;
                        //pressE.enabled = false;
                    }
                }
            }
            if (closeTo)
            {
                pressE.enabled = true;
            }
            else
            {
                pressE.enabled = false;
            }
            closeTo = stillClose;

        }

      
        if((int) timer >= maxTime || itemsNumber == foundItems)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("foundItems", foundItems);
        }
    }
}
