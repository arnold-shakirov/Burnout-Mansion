using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int spawnAmount;

    // list of potential spawn points for hidden items, im so sleepy
    public Transform[] spawnPoints;

    // list of hidden item prefabs to choose from
    private GameObject[] hiddenItemPrefabs;

    private GameObject activeHiddenItem;
    private bool initialized;

    private void Start()
    {
        hiddenItemPrefabs = ItemManager.instance.itemPrefabs;

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
        if (other.CompareTag("Player") && !initialized)
        {
            initialized = true;
            PlaceRandomHiddenItem();
        }
    }

    private void PlaceRandomHiddenItem()
    {
        if (spawnPoints.Length > 0 && hiddenItemPrefabs.Length > 0)
        {
            // This will make sure someone (me) doesn't put a higher amount then allowed
            if (spawnAmount > spawnPoints.Length)
                spawnAmount = spawnPoints.Length;

            // Create a list to track available spawn points
            List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

            for (int i = 0; i < spawnAmount; i++)
            {
                // Gotta make sure there are available spawn points left
                if (availableSpawnPoints.Count == 0)
                {
                    Debug.LogWarning("No more available spawn points!");
                    break;
                }

                // Select a random spawn point from the available ones
                int randomSpawnIndex = Random.Range(0, availableSpawnPoints.Count);
                Transform spawnPoint = availableSpawnPoints[randomSpawnIndex];

                // Select a random hidden item from the list
                int randomItemIndex = Random.Range(0, hiddenItemPrefabs.Length);
                GameObject selectedHiddenItem = hiddenItemPrefabs[randomItemIndex];

                // Instantiate the hidden item at the selected spawn point
                activeHiddenItem = Instantiate(selectedHiddenItem, spawnPoint.position, Quaternion.identity, spawnPoint.parent);

                // Remove the used spawn point from the list
                availableSpawnPoints.RemoveAt(randomSpawnIndex);
            }
        }
    }

}