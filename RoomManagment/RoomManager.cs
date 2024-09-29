using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour

{
    // list of potential spawn points for hidden items, im so sleepy 
    public Transform[] spawnPoints;

    // list of hidden item prefabs to choose from
    public GameObject[] hiddenItemPrefabs; 

    private GameObject activeHiddenItem;
    private bool playerInRoom = false;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned!");
        }
        if (hiddenItemPrefabs.Length == 0)
        {
            Debug.LogWarning("No hidden item prefabs assigned!");
        }
    }

    // trigger when player enters the room
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInRoom)
        {
            playerInRoom = true;
            PlaceRandomHiddenItem();
        }
    }

    void PlaceRandomHiddenItem()
{
    if (spawnPoints.Length > 0 && hiddenItemPrefabs.Length > 0)
    {
        // select a random spawn point
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // select a random hidden item from the list
        int randomItemIndex = Random.Range(0, hiddenItemPrefabs.Length);
        GameObject selectedHiddenItem = hiddenItemPrefabs[randomItemIndex];

        // instantiate the hidden item at the selected spawn point relative to the room
        activeHiddenItem = Instantiate(selectedHiddenItem, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
    }
}

    // trigger when the player exits the room
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRoom = false;

            // optionally remove the hidden item when player exits the room
            if (activeHiddenItem != null)
            {
                Destroy(activeHiddenItem);
            }
        }
    }
}