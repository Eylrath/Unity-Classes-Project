using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeItems : MonoBehaviour
{
    private GameObject[] Items;
    private GameObject[] ItemPlacements;
    // Start is called before the first frame update
    void Start()
    {
        int itemsToRender = PlayerPrefs.GetInt("itemsNumber");
        //Random.InitState((System.DateTime.Now.Millisecond));
        List<int> ItemsToPlaces;
        Items = GameObject.FindGameObjectsWithTag("Items");
        ItemPlacements = GameObject.FindGameObjectsWithTag("ItemPlacement");

        int itemNumb = Items.Length;
        int placesNumb = ItemPlacements.Length;
        //Debug.Log(itemNumb.ToString() + " " +  placesNumb.ToString());

        ItemsToPlaces = createRandomList(itemNumb, placesNumb);
        //Debug.Log(ItemsToPlaces.ToArray().Length);
        int i;
        for(i = 0; i < itemsToRender; i++)
        {
            RaycastHit ray;
            
            GameObject ActPlace = ItemPlacements[ItemsToPlaces[i]];
            GameObject ActItem = Items[i];
            if (ActItem.activeSelf)
            {
                Vector3 rayPos = new Vector3(ActPlace.transform.position.x, ActPlace.transform.position.y + 3, ActPlace.transform.position.z);
                if (Physics.Raycast(rayPos, -Vector3.up, out ray))
                {
                    ActItem.transform.position = ray.point;
                }
            }

        }
        for (; i < itemNumb; i++)
            Items[i].SetActive(false);

    }

    // Update is called once per frame
    public List<int> createRandomList(int itemNumb, int maxRange)
    {
        List<int> retList = new List<int>();
        int addedNumbers = 0;
        for(int item = 0; item < itemNumb; item++)
        {
            int randNumb = Random.Range(0, maxRange - 1);
            while(retList.Contains(randNumb))
            {
                randNumb = Random.Range(0, maxRange - 1);
            }
            retList.Add(randNumb);
            //Debug.Log(randNumb);
            addedNumbers++;
            
        }
        return retList;
    }

}
