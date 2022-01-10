using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{

    public AudioClip audioFar;
    public AudioClip audioClose;


    public AudioSource farPlayer;
    public AudioSource closePlayer;

    public GameObject player;
    private GameObject[] Items;

    private Vector3 playerPosition;
    private Vector3 itemPosition;
    private float distance;
    public float maxDistance = 40f;



    // Start is called before the first frame update
    void Start()
    {
        Items = GameObject.FindGameObjectsWithTag("Items");
        
        closePlayer.clip = audioClose;
        closePlayer.volume = 0;
        closePlayer.Play();

        farPlayer.clip = audioFar;
        farPlayer.volume = 0.5f;
        farPlayer.Play();
        

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        float minDistance = maxDistance;
        foreach (GameObject item in Items)
        {
            if (item.activeSelf)
            {
                itemPosition = item.transform.position;
                distance = Vector3.Distance(playerPosition, itemPosition);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }
        if(minDistance < maxDistance)
            closePlayer.volume = (maxDistance - minDistance) / maxDistance;
        else
            closePlayer.volume = 0f;
        //Debug.Log((maxDistance - minDistance) / maxDistance);
        if (!farPlayer.isPlaying && !closePlayer.isPlaying)
        {
            farPlayer.Play();
            closePlayer.Play();
        }
    }
}
